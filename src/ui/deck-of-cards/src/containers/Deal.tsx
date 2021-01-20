import React from "react";
import Button from "@material-ui/core/Button";
import "./Deal.css";

export interface IDealProps {}

const Deal = (props: IDealProps) => {
  return (
    <div className="Deal">
      <div className="Table">
        <header>
          <Button variant="contained" color="primary">
            New Deck
          </Button>
          <Button variant="contained" color="primary" disabled>
            Shuffle Deck
          </Button>
        </header>
      </div>
    </div>
  );
};

export default Deal;
