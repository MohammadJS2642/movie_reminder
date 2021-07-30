import { React } from "react";
import "./headerStyle.css";

function HeaderBar() {
  return (
    <>
      <header className={"mainHeader"}>
        <div></div>
        <h1 className={"headerTitle"}>Movie Reminder</h1>
        <div className={"searchBar"}></div>
      </header>
    </>
  );
}

export default HeaderBar;
