import React from 'react';

import api from '../../services/api';

import './styles.css';

export interface Schedule {
    id: number;
    name: string;
    crm: number;
    specialty: string;
    hour_begin: string;
    hour_end: string;
    weekDay: string;
}

interface ScheduleItemProps {
    schedule: Schedule;
}

const ScheduleItem: React.FC<ScheduleItemProps> = ({schedule}) => {

    function CreateNewConnection() {
        api.post('connections', {
            user_id: schedule.id,
        });
    };

    return (
        <article className="schedule-item">
        <header>
            <img src="/" alt={schedule.name}/>
            <div>
                <strong>{schedule.name}</strong>
                <span>{schedule.specialty}</span>
            </div>
        </header>
            <p>
                Início da consulta: {schedule.hour_begin}
            </p>
            <p>
               Término da consulta: {schedule.hour_end}
            </p>
        <footer>
            <p>
                {schedule.weekDay}
            </p>
            <a onClick={CreateNewConnection} href={"/"}>
                Marcar consulta
            </a>
        </footer>
    </article>
    );
}

export default ScheduleItem;