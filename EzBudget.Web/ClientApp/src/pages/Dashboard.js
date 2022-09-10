import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Spinner } from 'reactstrap';
import { isFetching, isIdle } from '../state/CommunicationSlice';
import config from '../config.json';

export const Dashboard = () => {
  const communicationState = useSelector((state) => state.communication);
  const dispatch = useDispatch();
  const [budgetSummaries, setBudgetSummaries] = useState([]);

  const loadBudgetSummaries = () => {};

  useEffect(() => {
    //dispatch(isFetching());
    const url = `${config.API_BASE_URL}/BudgetSummaries`;
    console.log(url);
    fetch(url)
      .then((response) => {
        //dispatch(isIdle());
        if (!response.ok) throw new Error();
        return response.json();
      })
      .then((json) => {
        console.log('json: ', json);
        setBudgetSummaries(json);
      });
  }, []);

  return (
    <React.Fragment>
      <h1>Dashboard</h1>

      <p>Welcome to the EZ Budget Dashboard!</p>

      {communicationState.isFetching && <Spinner color="primary">Loading...</Spinner>}
      {communicationState.isIdle && (
        <div>
          <p>Show summaries</p>
        </div>
      )}
    </React.Fragment>
  );
};
