import React from 'react';
import styles from './styles.css';
import Field from '../Field';
import Cell from '../Cell';

export default class App extends React.Component {
    constructor () {
        super();
        this.state = {
            score: 50,
        };
    }

    render () {
        return (
            <div className={ styles.root }>
                <div className={ styles.score }>
                    Ваш счет: { this.state.score }
                </div>
                <Field />
                <Cell />
            </div>
        );
    }
}
