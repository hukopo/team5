import React from 'react';
import styles from './styles.css'
import Cell from '../Cell';
import PropTypes from 'prop-types'


export default class Field extends React.Component {

    state = {
        cells: [],
        lastDirection: null,
        id: 0
    }

    getMap = () => {
        fetch("/api/game/" + this.state.id + "/map")
            .then(response => {
                return response.json()
            })
            .then(response => this.setState({ cells: response }))
    }

    createUser = () => {
        return fetch("/api/game/create/" + this.props.size, { method: 'POST' })
            .then(response => {
                return response.json()
            })
            .then(response => this.setState({ id: response }))
    }

    getScore = () => {
        return fetch("/api/game/" + this.state.id + "/score")
            .then(response => {
                return response.json()
            }).then(response => this.props.scoreCallback(response))
    }

    componentDidMount = () => {
        this.createUser().then(() => this.getMap());


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
                    return;
            }
            this.setState({ lastDirection: side })
            this.getScore();
            this.getMap();
            fetch('/api/game/' + this.state.id + '/move/' + side, { method: 'POST' })
        });
    }

    render() {
        return (
            <div className={styles.center}>
                <div className={styles.fieldWrapper}>
                    <div className={this.props.size == 3 ? styles.field3x3 : styles.field}>
                        {this.state.cells.map(row =>
                            row.map(cell =>
                                <Cell value={cell} />))}
                    </div>
                </div>
            </div>
        );
    }
}

Field.PropTypes = {
    scoreCallback: PropTypes.func.isRequired
}
