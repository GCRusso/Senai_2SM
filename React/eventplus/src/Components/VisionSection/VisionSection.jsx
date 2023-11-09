import React from 'react';
import './VisionSection.css'
import Title from '../Title/Title';

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>

                <Title
                titleText="Visão"
                color='white'
                className='vision__title'
                />
                <p className='vision__text' >Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iure modi magni repudiandae ad sit doloribus, impedit facilis facere quas quod inventore enim consequuntur sed maxime obcaecati architecto, eaque minima error.</p>
            </div>
        </section>
    );
};

export default VisionSection;