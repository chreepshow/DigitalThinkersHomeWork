import React from 'react'
import styles from './layout.module.css'

export const Layout = (props) => (
  <section className={styles.container}>{props.children}</section>
)
