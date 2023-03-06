import React, { Component } from 'react'

export class Home extends Component {
  componentDidMount() {
    document.title = 'DT-HW Home'
  }

  static displayName = Home.name

  render() {
    return (
      <div>
        <h1>Hello, world!</h1>
        <a href="/drivers">Let's see the drivers!</a>
      </div>
    )
  }
}
