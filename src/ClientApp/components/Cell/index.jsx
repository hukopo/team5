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
            case 8:
                style = styles.tile8
                break;
            case 16:
                style = styles.tile16
                break;
            case 32:
                style = styles.tile32
                break;
            case 64:
                style = styles.tile64
                break;
            case 128:
                style = styles.tile128
                break;
        }
        this.className = styles.cell + " " + styles.tile + " " + style

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
