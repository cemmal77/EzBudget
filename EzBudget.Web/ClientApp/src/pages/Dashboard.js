import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Card, CardBody, CardTitle, CardSubtitle, Spinner, Button } from 'reactstrap';
import { isFetching, isIdle } from '../state/CommunicationSlice';
import config from '../config.json';

const formatDate = (dateString) => {
  return new Date(dateString).toLocaleDateString('en-us');
};

export const Dashboard = () => {
  const communicationState = useSelector((state) => state.communication);
  const dispatch = useDispatch();
  const [budgetSummaries, setBudgetSummaries] = useState([]);

  useEffect(() => {
    dispatch(isFetching());
    const url = `${config.API_BASE_URL}/BudgetSummaries`;
    fetch(url)
      .then((response) => {
        dispatch(isIdle());
        if (!response.ok) throw new Error();
        return response.json();
      })
      .then((json) => {
        console.log(json);
        setBudgetSummaries(json);
      });
  }, [dispatch]);

  return (
    <React.Fragment>
      <h1>Dashboard</h1>

      <p>Welcome to the EZ Budget Dashboard!</p>

      {communicationState.isFetching && <Spinner color="primary">Loading...</Spinner>}
      {!communicationState.isFetching && (
        <div>
          {budgetSummaries.map((item, index) => (
            <Card key={index}>
              <CardBody>
                <CardTitle>{item.name}</CardTitle>
                <CardSubtitle>
                  {formatDate(item.startDate)} - {formatDate(item.endDate)}
                </CardSubtitle>
                <Button>Edit</Button>
              </CardBody>
            </Card>
          ))}
        </div>
      )}
    </React.Fragment>
  );
};
