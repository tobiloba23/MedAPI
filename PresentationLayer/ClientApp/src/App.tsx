import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import BloodWorkReport from './components/BloodWorkReport';
import BloodWorkForm from './components/BloodWorkForm';
import BloodWorkList from './components/BloodWorkList';

import './custom.css'

export default () => (
    <Layout>
        <Route exact path='/' component={BloodWorkList} />
        <Route path='/fetch-data/:pageIndex?' component={BloodWorkList} />
        <Route path='/view-data/:id' component={BloodWorkList} />
        <Route path='/add-data/' component={BloodWorkForm} />
        <Route path='/edit-data/:id' component={BloodWorkForm} />
        <Route path='/view-report/' component={BloodWorkReport} />
    </Layout>
);
