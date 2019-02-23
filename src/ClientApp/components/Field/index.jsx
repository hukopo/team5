import React from 'react';
import styles from './styles.css'
import Cell from '../Cell';


export default class Field extends React.Component {

    state = {
        cells: [],
        lastDirection: null
    }

    componentDidMount = () => {
        fetch("/api/game/1/map")
            .then(response => {
                return response.json()
            })
            .then(response => this.setState({ cells: response }))
        fetch("/api/game/score")
            .then(response => {
                return response.json()
            })

        window.addEventListener("keydown", e => {
            let side;
            switch (e.keyCode) {
                case 37:
                    side = 'left';
                    break;
                case 38:
                    side = 'up'
                    break;
                case 39:
                    side = 'right'
                    break;
                case 40:
                    side = 'down'
                    break;
                default:
                    e.preventDefault();
            }
            this.setState({lastDirection: side})
            return fetch('/api/game/1/move/' + side, {method: 'POST'})
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
