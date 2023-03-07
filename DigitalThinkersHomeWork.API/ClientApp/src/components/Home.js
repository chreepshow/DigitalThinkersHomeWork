import React, { useEffect } from 'react'
import styles from './home.module.css'

export function Home() {
  useEffect(() => {
    document.title = 'DT-HW Home'
  }, [])

  return (
    <section className={styles.container}>
      <h1>Welcome, Digital Thinkers</h1>
      <a href="/drivers">Let's see the drivers!</a>
    </section>
  )
}
