import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';
import Landing from './pages/Landing';
import ScheduleList from './pages/ScheduleList';
import DoctorForm from './pages/DoctorForm';
import PatientForm from './pages/PatientForm';

function Routes() {
    return (
        <BrowserRouter>
            <Route path="/" exact component={Landing} />
            <Route path="/schedule" component={ScheduleList} />
            <Route path="/doctor" component={DoctorForm} />
            <Route path="/patient" component={PatientForm} />

        </BrowserRouter>

    );
}

export default Routes;