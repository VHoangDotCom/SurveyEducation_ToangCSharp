import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import "react-toastify/dist/ReactToastify.css";
import { StateProvider } from "./StateProvider";
import reducer, { initialState } from "./redux/reducer";
import { Auth0Provider } from "@auth0/auth0-react";
const domain = process.env.REACT_APP_AUTH0_DOMAIN;
const clientId = process.env.REACT_APP_AUTH0_CLIENT_ID;

ReactDOM.render(
  <Auth0Provider
    domain="bqminh30.us.auth0.com"
    clientId="6GE9Md86O4A6uGNQUZGCHayvEqOBsZ91"
    redirectUri={window.location.origin}
  >
    <React.StrictMode>
      <StateProvider initialState={initialState} reducer={reducer}>
        <App />
      </StateProvider>
    </React.StrictMode>
  </Auth0Provider>,

  document.getElementById("root")
);
