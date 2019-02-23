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
        fetch("http://localhost:5000/api/game/score")
            .then(response => {
                return response.json()
            })

        window.addEventListener("keydown", e => {
            if (e.keyCode >= 37 && e.keyCode <= 40)
                e.preventDefault();
        });
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
