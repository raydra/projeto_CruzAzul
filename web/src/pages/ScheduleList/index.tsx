import React, { useState, FormEvent } from 'react';

import PageHeader from '../../components/PageHeader';
import ScheduleItem, {Schedule} from '../../components/ScheduleItem'
import Input from '../../components/Input/Index';
import Select from '../../components/Select/Index';
import api from '../../services/api';

import './styles.css';


function ScheduleList() {

    const [doctor_schedule, setDoctorSchedule] = useState([]);

    const [specialty, setSpecialty] = useState('');
    const [week_day, setWeekDay] = useState('');
    const [time, setTime] = useState('');

    async function searchSchedules(e: FormEvent) {
        e.preventDefault();

        const response = await api.get('schedule', {
            params: {
                specialty,
                week_day,
                time,
            }
        });

        setDoctorSchedule(response.data);
    };

    return (
        <div id="page-schedule-list" className="container">
            <PageHeader title="Confira nossa agenda">
                <form id="search-schedule" onSubmit={searchSchedules}>
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
                     <Select 
                        name="week_day" 
                        label="Dia da semana"
                        value={week_day}
                        onChange={(e) => { setWeekDay(e.target.value)}}
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
                    <Input type="time" name="time" label="Hora" value={time}
                        onChange={(e) => { setTime(e.target.value)}}/>
                    
                    <button type="submit">
                        Buscar
                    </button>
                </form>
            </PageHeader>

            <main>
                {doctor_schedule.map((doctor_schedule: Schedule) => {
                    return <ScheduleItem key={doctor_schedule.id} schedule={doctor_schedule} />
                })}    
            </main>
        </div>
    )
}

export default ScheduleList;