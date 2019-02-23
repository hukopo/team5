import React from 'react';
import styles from './styles.css'
import Cell from '../Cell';


export default class Field extends React.Component {

    state = {
        cells: []
    }

    componentDidMount = () => {
        fetch("http://localhost:5000/api/game/map")
            .then(response => {
                return response.json()
            })
            .then(response => this.setState({ cells: response }))
            .then(response => console.log(response));
        fetch("http://localhost:5000/api/game/score")
            .then(response => {
                return response.json()
            })
            .then(response => console.log(response));
    }

    render() {
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <div className={styles.field}>
                        {this.state.cells.map(row =>
                            row.map(cell =>
                                <Cell value={cell} />))}
                    </div>
                </div>
            </div>
        );
    }
}
