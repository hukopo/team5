import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {

    componentDidMount = () => {
        fetch("http://localhost:5000/api/game/map")
            .then(response => {
                return response.json()
            })
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
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>

                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>

                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                        <div className={styles.cell}></div>
                    </div>
                </div>
            </div>
        );
    }
}
