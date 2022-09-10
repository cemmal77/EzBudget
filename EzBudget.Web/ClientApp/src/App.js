import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Dashboard } from './pages/Dashboard';

import './custom.css';

export default class App extends Component {
  render() {
    return (
      <Layout>
        <Route exact path="/" component={Dashboard} />
      </Layout>
    );
  }
}
