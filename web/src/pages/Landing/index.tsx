import React from 'react';
import { Link } from 'react-router-dom';

import logoImg from '../../assets/images/logo.png';

import patientIcon from '../../assets/images/icons/patientIcon.svg';
import doctorIcon from '../../assets/images/icons/doctorIcon.svg';
// import { Alert } from 'react-bootstrap';
import './styles.css';


function Landing() {

    return (
        <div id="page-landing">
            <div id="page-landing-content">
                <div className="logo-container">
                    <img src={logoImg} alt="CruzAzul"/>
                    <h2>Sua plataforma de agendamento online</h2>
                </div>
                <div className="buttons-container">
                    <Link to="/schedule" className="primario">
                        <img src={patientIcon} alt="Listar agenda"/>
                        Agendar
                    </Link>
                    <Link to="/doctor" className="secundario">
                        <img src={doctorIcon} alt="Cadastrar médico"/>
                        Cadastrar médico
                    </Link>
                    <Link to="/patient" className="primario">
                        <img src={patientIcon} alt="Cadastrar paciente"/>
                        Cadastrar paciente
                    </Link>
                </div>
            </div>
        </div>
    
    )
}

export default Landing;