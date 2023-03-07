import React, { useEffect, useState } from 'react'
import styles from './DriverCard.module.css'

export function DriverCard(props) {
  return (
    <div className={styles.cardContainer}>
      <img src={props.driver.imageUrl} width={206} height={206} />
      <div>
        <h3>
          <b>
            {props.driver.firstName} {props.driver.lastName}
          </b>
        </h3>
        <h4>{props.driver.team}</h4>
        <p>{props.driver.place}.</p>
        <p>{props.driver.code}</p>
        {props.driver.place > 1 && (
          <button
            onClick={() => props.handleItemClick(props.driver.id)}
            disabled={props.isLoading}
          >
            Overtake
          </button>
        )}
      </div>
    </div>
  )
}
