import React from "react";
import "./App.css";
import Deal, { IDealProps } from "./containers/Deal";
import Welcome, { IWelcomeProps } from "./containers/Welcome";

export enum PageState {
  Welcome,
  Deal,
}

export interface IAppProps {}

export interface IAppState {
  pageState: PageState;
}

export default class App extends React.Component<IAppProps, IAppState> {
  constructor(props: IAppProps, context: IAppState) {
    super(props, context);

    this.state = {
      pageState: PageState.Welcome,
    };
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
    const welcomeProps: IWelcomeProps = {
      setPageState: this.setPageSate,
    };

    const dealProps: IDealProps = {}

    return this.state.pageState === PageState.Welcome ? (
      <Welcome {...welcomeProps} />
    ) : (
      <Deal {...dealProps} />
    );
  }
}
