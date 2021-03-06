import React from 'react';
import styles from './styles.css';
import Field from '../Field';

export default class App extends React.Component {
    constructor() {
        super();
        this.state = {
            score: 0,
            size: 4
        };
    }

    render() {
        return (
            <div className={styles.root}>
                <div className={styles.score}>
                    Ваш счет: {this.state.score}
                    <span style={{ marginLeft: 50 }}>
                        Рaзмерность:
                        <select onChange={(e) => this.setState({size: e.target.value})}>
                            <option>4</option>
                            <option>3</option>
                        </select>
                        нужно снять курсор иначе select будет листать...
                    </span>
                </div>
                {this.state.size == 3 && <Field size={this.state.size} scoreCallback={(s) => this.setState({ score: s })} />}
                {this.state.size == 4 && <Field size={this.state.size} scoreCallback={(s) => this.setState({ score: s })} />}
            </div>
        );
    }
}
