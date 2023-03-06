import React, { Component } from 'react'

export class DriverList extends Component {
  constructor(props) {
    super(props)
    this.state = {
      isLoading: true,
      error: null,
      drivers: [],
    }
  }

  componentDidMount() {
    document.title = 'DT-HW Drivers'
    this.getDriverListAsync()
  }

  render() {
    const { isLoading, error, drivers } = this.state
    console.log(drivers)
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

  async getDriverListAsync() {
    fetch('api/drivers')
      .then((res) => res.json())
      .then(
        (result) => {
          this.setState({
            isLoading: false,
            drivers: result,
          })
          console.log(result)
        },
        (error) => {
          this.setState({
            isLoading: false,
            error,
          })
        }
      )
  }
}
