import React, { useEffect, useState } from 'react'

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
      <section>
        <h1>Drivers page works!</h1>

        <ul>
          {drivers.map((driver) => (
            <li key={driver}>{driver}</li>
          ))}
        </ul>

        <a href="/">Home</a>
      </section>
    )
  }
}
