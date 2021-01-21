import React from "react";
import "./App.css";
import Deal, { IDealProps } from "./containers/Deal";
import Welcome, { IWelcomeProps } from "./containers/Welcome";
import Axios from 'axios';

export enum PageState {
  Welcome,
  Deal,
}

export enum SuiteType {
  Hearts,
  Diamonds,
  Clubs,
  Spades,
}

export enum FaceType {
  Two = 2,
  Three,
  Four,
  Five,
  Six,
  Seven,
  Eight,
  Nine,
  Ten,
  Jack,
  Queen,
  King,
  Ace,
}

export interface ICard {
  playingCard: IPlayingCard;
}

export interface IPlayingCard {
  key: number;
  value: number;
};

export interface IAppProps {}

export interface IAppState {
  pageState: PageState;
  cards: ICard[];
}

export default class App extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps, context: IAppState) {
    super(props);

    this.state = {
      pageState: PageState.Welcome,
      cards: []
    };
  }

  /**
   * Gets a new deck of cards from the API
   */
  getNewDeck = () => {
    Axios.get('https://localhost:44372/api/Deck')
    .then(response => {
      // Cast the response data to javascript object
      const cards: ICard[] = response.data

      // Set the state of the cards object
      this.setState({
        cards: cards,
      });

      // Check we set cards to the state
      console.debug(this.state.cards);
    });
  }

  /**
   * Shuffles the supplied deck of cards
   * @param cards The cards to shuffle
   */
  shuffleDeck = () => {
    Axios.post("https://localhost:44372/api/Deck", this.state.cards)
    .then(response => {
      console.log("Shuffled deck");

      // Cast the response data to javascript object
      const shuffledCards: ICard[] = response.data

      // Apply the shuffled deck to the state
      this.setState({
        cards: shuffledCards,
      });

      // Check the cards are shuffled
      console.debug(this.state.cards);
    });
  }

  /**
   * Sets which "page" will be displayed by the render()
   * @param pageState The page state to set
   */
  setPageSate = (pageState: PageState) => {
    // Only update the state if we need to change page
    if (this.state.pageState !== pageState) {
      this.setState({
        pageState: pageState,
      });
    }
  }

  /**
   * Render method
   */
  render() {
    // Set welcome page props
    const welcomeProps: IWelcomeProps = {
      setPageState: this.setPageSate,
    };

    // Set the deal page props
    const dealProps: IDealProps = {
      cards: this.state.cards,
      getDeck: this.getNewDeck,
      shuffleDeck: this.shuffleDeck,
    };

    // Render the relevant container
    return this.state.pageState === PageState.Welcome ? (
      <Welcome {...welcomeProps} />
    ) : (
      <Deal {...dealProps} />
    );
  }
}
