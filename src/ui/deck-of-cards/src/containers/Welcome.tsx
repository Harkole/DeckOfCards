import React from "react";
import Button from "@material-ui/core/Button";

import logo from "./../images/cards/1B.svg";
import "./Welcome.css";
import { PageState } from "../App";

export interface IWelcomeProps {
    setPageState: (pageState: PageState) => void;
}

const Welcome = (props: IWelcomeProps) => {

  return (
    <div className="Welcome">
      <header className="Welcome-header">
        <img src={logo} className="Welcome-logo" alt="logo" />
        <p>Get a deck to start</p>
        <Button
          variant="contained"
          color="primary"
          onClick={() => props.setPageState(PageState.Deal)}
        >
          Get Deck
        </Button>
      </header>
    </div>
  );
}

export default Welcome;
