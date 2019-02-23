import React from 'react';
import styles from './styles.css'
import PropTypes from 'prop-types'

export default class Cell extends React.Component {
    constructor(props) {
        super(props)
        let style;
        switch (this.props.value) {
            case 2:
                style = styles.tile2
                break;
            case 4:
                style = styles.tile4
                break;
        }
//debugger;
        this.className = styles.cell + " " + styles.tile + " " + styles.tile2

    }
    render() {
        return (
            <div className={this.className}>{this.props.value == 0 ? null : this.props.value}</div>
        );
    }
}

Cell.PropTypes = {
    value: PropTypes.number.isRequired
}
