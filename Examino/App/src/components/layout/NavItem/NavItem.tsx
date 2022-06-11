import React from "react";
import { NavLink } from "react-router-dom";
import styles from "./NavItem.module.scss";

interface Props {
  to: string;
  label: string;
  icon: React.ReactNode;
  onClick?: () => void;
}

const NavItem = ({ to, label, icon, onClick }: Props) => {
  return (
    <NavLink
      to={to}
      className={(navData) =>
        navData.isActive ? `${styles.navlink} ${styles.active}` : styles.navlink
      }
      onClick={onClick}
    >
      <span className={styles.icon}>{icon}</span>
      {label}
    </NavLink>
  );
};

export default NavItem;
