import React, { useEffect, useState } from 'react'
import { DriverCard } from './DriverCard'

import styles from './DriverList.module.css'

export function DriverList() {
  const [isLoading, setLoading] = useState(true)
  const [error, setError] = useState(null)
  const [drivers, setDrivers] = useState([])

  useEffect(() => {
    document.title = 'DT-HW Drivers'

    fetch('api/drivers')
      .then((res) => res.json())
      .then(
        (result) => {
          setLoading(false)
          result.sort((f, s) => (f.place > s.place ? 1 : -1))
          setDrivers(result)
        },
        (error) => {
          setLoading(false)
          setError(error)
        }
      )
  }, [])

  if (error) {
    return <section>Sorry we encountered some error</section>
  } else if (isLoading) {
    return <section>Loading...</section>
  } else {
    return (
      <section className={styles.container}>
        <h1>State of the race</h1>

        <div className={styles.driverCardContainer}>
          {drivers.map((driver) => (
            <DriverCard key={driver.id} driver={driver} />
          ))}
        </div>

        <a href="/">Home</a>
      </section>
    )
  }
}
