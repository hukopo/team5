import React from 'react';
import styles from './styles.css'

export default class Field extends React.Component {

    componentDidMount = () => {
        fetch("http://localhost:5000/api/game/map")
            .then(response => {
                response.json()
                debugger;
            })
            .then(response => console.log(response));
    }

    render() {
        return (
            <div className={styles.root}>
                sd;lfls;ldmf</div>
        );
    }
}
