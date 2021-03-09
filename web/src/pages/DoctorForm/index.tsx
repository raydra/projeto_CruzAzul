import React, { useState, FormEvent } from 'react';
import { useHistory } from 'react-router-dom';
import PageHeader from '../../components/PageHeader';
import Input from '../../components/Input/Index';
import Select from '../../components/Select/Index';
import api from '../../services/api';
import warningIcon from '../../assets/images/icons/warning.svg';

import './styles.css';

function DoctorForm() {

    const history = useHistory();

    const [name, setName] = useState('');
    const [crm, setCrm] = useState('');
    const [specialty, setSpecialty] = useState('');
    const [id, setId] = useState('');

    const [scheduleItems, setScheduleItems] = useState([
        { week_day: 0, from: '', to: ''},
    ]);

    function addNewScheduleItem() {
        setScheduleItems([
            ...scheduleItems,
            { week_day: 0, from: '', to: ''}, 
        ]);

    };

    function handleCreateClass(e: FormEvent) {
        e.preventDefault();

            api.post('doctor', {
                name,
                crm,
                specialty
            }).then(response => {

                setId(response.data.id);

                api.post('schedule', {
                    id,
                    schedule: scheduleItems
                }).then(() => {
                    alert('Cadastro realizado com sucesso.');
                    history.push('/');
                }).catch(() => {
                    alert('Erro no cadastro de agenda.')
                })

            }).catch(() => {
                alert('Erro no cadastro de médico.')
            })
        
    }

    function setScheduleValue(position: number, field: string, value: string) {
        const updatedScheduleItems = scheduleItems.map((scheduleItem, index) => {
            if (index === position) {
                return {...scheduleItem, [field]: value}
            }

            return scheduleItem;
        })

        setScheduleItems(updatedScheduleItems);
    };

    return (
        <div id="page-doctor-form" className="container">
            <PageHeader 
                title="Que incrível seu interesse por nós."
                description="Por favor, preencha o formulário de inscrição."/>

            <main>
                <form onSubmit={handleCreateClass}>
                <fieldset>
                    <legend>Seus dados</legend>

                    <Input name="name" label="Nome Completo" 
                    value={name} onChange={(e)=> { setName(e.target.value )}}/>

                    <Input name="CRM" label="CRM"
                    value={crm} onChange={(e)=> { setCrm(e.target.value)}}/>

                    <Select 
                        name="specialty" 
                        label="Especialidade"
                        value={specialty}
                        onChange={(e) => { setSpecialty(e.target.value)}}
                        options={[
                            { value: 'Clínica médica', label: 'Clínica médica' },
                            { value: 'Geriatria', label: 'Geriatria' },
                            { value: 'Oftalmologia', label: 'Oftalmologia' },
                            { value: 'Oncologia', label: 'Oncologia' },
                            { value: 'Dermatologia', label: 'Dermatologia' },
                            { value: 'Urgência e emergência', label: 'Urgência e emergência' },
                            { value: 'Infectologia', label: 'Infectologia' },
                            { value: 'Cirurgia', label: 'Cirurgia' },
                        ]}
                    />

                </fieldset>

                <fieldset>
                    <legend>
                        Horários disponíveis
                        <button type="button" onClick={addNewScheduleItem}>
                        + Novo horário
                        </button>
                    </legend>

                {scheduleItems.map((scheduleItem, index) => {
                    return (
                        <div key={scheduleItem.week_day} className="schedule-item">
                        <Select 
                            name="week_day" 
                            label="Dia da semana"
                            value={scheduleItem.week_day}
                            onChange={e => setScheduleValue(index, 'week_day', e.target.value)}
                            options={[
                                { value: '0', label: 'Domingo' },
                                { value: '1', label: 'Segunda-feira' },
                                { value: '2', label: 'Terça-feira' },
                                { value: '3', label: 'Quarta-feira' },
                                { value: '4', label: 'Quinta-feira' },
                                { value: '5', label: 'Sexta-feira' },
                                { value: '6', label: 'Sábado' }      
                                ]}
                        />
                        <Input name="from" label="Das" type="time" value={scheduleItem.from}
                        onChange={e => setScheduleValue(index, 'from', e.target.value)}/>

                        <Input name="to" label="Até" type="time" value={scheduleItem.to}
                        onChange={e => setScheduleValue(index, 'to', e.target.value)}/>
                    </div>
                    );
                })}                
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

export default DoctorForm;