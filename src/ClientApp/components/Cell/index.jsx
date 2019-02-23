import React from 'react';
import styles from './styles.css'
import PropTypes from 'prop-types'

export default class Cell extends React.Component {
    render() {
        return (
            <div className={styles.cell + " " + styles.tile + " " + styles["tile" + this.props.value]}>{this.props.value == 0 ? null : this.props.value}</div>
        );
    }
}

Cell.PropTypes = {
    value: PropTypes.number.isRequired
}
