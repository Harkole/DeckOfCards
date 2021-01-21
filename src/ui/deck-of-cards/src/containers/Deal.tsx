import React from "react";
import Button from "@material-ui/core/Button";
import "./Deal.css";
import { ICard } from "./../App";

export interface IDealProps {
  cards: Array<ICard>;
  getDeck: () => void;
  shuffleDeck: () => void;
};

const Deal = (props: IDealProps) => {
  console.log(props.cards.length);
  
  return (
    <div className="Deal">
      <div className="Table">
        <header>
          <Button variant="contained" color="primary" onClick={props.getDeck}>
            New Deck
          </Button>
          <Button variant="contained" color="primary" disabled={(props.cards.length === 52)} onClick={props.shuffleDeck}>
            Shuffle Deck
          </Button>
        </header>
      </div>
    </div>
  );
};

export default Deal;
