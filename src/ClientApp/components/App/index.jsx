import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor () {
        super();
        this.state = {
            score: 0,
        };
    }

    render () {
        return (
            <div className={ styles.root }>
                <div className={ styles.score }>
                    Ваш счет: { this.state.score }
                </div>
                <Field scoreCallback={(s) => this.setState({score: s})}/>
            </div>
        );
    }
}
