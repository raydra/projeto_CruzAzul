import React, { useState, FormEvent } from 'react';
import { useHistory } from 'react-router-dom';
import PageHeader from '../../components/PageHeader';
import Input from '../../components/Input/Index';
import api from '../../services/api';
import warningIcon from '../../assets/images/icons/warning.svg';

import './styles.css';

function PatientForm() {

    const history = useHistory();
    const [name, setName] = useState('');
    const [cpf, setCpf] = useState('');
    const [email, setEmail] = useState('');
    const [whatsapp, setWhatsapp] = useState('');

    function handleCreateClass(e: FormEvent) {
   
        e.preventDefault();

        api.post('patient', {
            name,
            cpf,
            email,
            whatsapp
        }).then(() => {
            alert('Cadastro realizado com sucesso.');
            history.push('/');
        }).catch(() => {
            alert('Erro no cadastro.')
        })
    }

    return (
        <div id="page-patient-form" className="container">
            <PageHeader 
                title="Que incrível seu interesse por nós."
                description="Por favor, preencha o formulário de inscrição."/>

            <main>
                <form onSubmit={handleCreateClass}>
                <fieldset>
                    <legend>Seus dados</legend>

                    <Input name="name" label="Nome Completo" 
                    value={name} onChange={(e)=> { setName(e.target.value )}}/>

                    <Input name="CPF" label="CPF"
                    value={cpf} onChange={(e)=> { setCpf(e.target.value)}}/>

                    <Input name="Email" label="Email"
                    value={email} onChange={(e)=> { setEmail(e.target.value )}}/>

                    <Input name="whatsapp" label="Whatsapp"
                    value={whatsapp} onChange={(e)=> { setWhatsapp(e.target.value )}}/>

                </fieldset>
                <footer>
                    <p>
                        <img src={warningIcon} alt="Aviso importante"/>
                        Importante! <br />
                        Preencha todos os campos.
                    </p>
                    <button type="submit">
                        Salvar cadastro
                    </button>
                </footer>
            </form>
            </main>
        </div>
    )
}

export default PatientForm;