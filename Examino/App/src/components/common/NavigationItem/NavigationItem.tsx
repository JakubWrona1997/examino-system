import React from "react";
import { NavLink } from "react-router-dom";
import "./NavigationItem.scss";

interface Props {
  to: string;
  label: string;
  icon: React.ReactNode;
  onClick?: () => void;
}

const NavigationItem = ({ to, label, icon, onClick }: Props) => {
  return (
    <NavLink
      to={to}
      className={(navData) => (navData.isActive ? "link active" : "link")}
      onClick={onClick}
    >
      <span className="link-icon">{icon}</span>
      {label}
    </NavLink>
  );
};

export default NavigationItem;
