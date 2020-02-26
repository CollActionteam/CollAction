import React from "react";
import { Hidden } from "@material-ui/core";
import styles from "./style.module.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Link } from "react-router-dom";

interface INavigationProps {
  items: { name: string, link: string }[];
}

interface INavigationState {
  collapsed: boolean;
}

export default class Navigation extends React.Component<
  INavigationProps,
  INavigationState
> {
  constructor(props: INavigationProps) {
    super(props);
    this.toggleNavigation = this.toggleNavigation.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavigation() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <div className={this.state.collapsed ? styles.collapsed : ""}>
        <nav className={styles.navigation}>
          <ul className={styles.navigationList}>
            {this.props.items.map((link) => (
              <li key={link.name} className={styles.navigationItem}>
                <Link className={styles.navigationLink} to={link.link}>
                  {link.name}
                </Link>
              </li>
            ))}
          </ul>
          <ul className={styles.navigationList}>
            <li className={styles.navigationItem}>
              <Link className={styles.navigationButton} to="/donate">
                <FontAwesomeIcon icon="heart" />
                Donate
              </Link>
            </li>
            <li className={styles.navigationItem}>
              <Link className={styles.navigationButton} to="/login">
                <FontAwesomeIcon icon="sign-in-alt" />
                Login
              </Link>
            </li>
          </ul>
        </nav>
        <Hidden mdUp>
          <button
            className={styles.navigationToggle}
            onClick={this.toggleNavigation}
          >
            {this.state.collapsed ? (
              <FontAwesomeIcon icon="bars" />
            ) : (
              <FontAwesomeIcon icon="times" />
            )}
          </button>
        </Hidden>
      </div>
    );
  }
}