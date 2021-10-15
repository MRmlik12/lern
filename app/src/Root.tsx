import { registerRootComponent } from "expo";
// eslint-disable-next-line no-use-before-define
import React, { ReactElement } from "react";
import App from "./App";

function Root(): ReactElement {
  return <App />;
}

export default registerRootComponent(Root);
