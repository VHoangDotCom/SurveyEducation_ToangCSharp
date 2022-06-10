import React from "react";
import { BrowserRouter as Router, Switch, Route,Redirect } from "react-router-dom";
import Formheader from "../src/component/Survey/Formheader";
import Header from "../src/component/SurveyList/Header";
import Mainbody from "../src/component/SurveyList/Mainbody";
import SubmitForm from "./component/View/QuestionPaper";
// import Question_form from './Question_form';
import CenteredTabs from "./component/Survey/Tab_survey_create";
import Tabs_update from "./component/Survey/Tab_survey_action";
import Templates from "./component/SurveyList/Templates";
import User_form from "./component/View/User_form";
import Home from './component/ViewUser/Pages/Home/index'
import Blog from './component/ViewUser/Pages/Blog/index'
import Profile from './component/ViewUser/Pages/Profile/Profile'
import ListProfile from "./component/ViewUser/Pages/Profile/ListProfile";
import Dashboard from "./component/Dashboard/Dashboard";
// import ProfileUser from './component/ViewUser/Pages/Login/ProfileUser'
// import LoginForm from './component/ViewUser/Pages/Login/LoginForm'
// import LogoutForm from './component/ViewUser/Pages/Login/LogoutForm'
// import Register from './component/ViewUser/Pages/Register/Register'

function App() {
  return (
    <div className="app">
     
      <Router>
      
        <Switch>
          <Route path="/survey/:id">
            <Formheader />
            <Tabs_update />
          </Route>
          <Route path="/form/:id">
            <Formheader />
            <CenteredTabs />
          </Route>

          <Route path="/report/:id">
            <Formheader />
            <User_form />
          </Route>

          <Route path="/response/:id">
            <User_form />
          </Route>

          <Route path="/submitted">
            <SubmitForm />
          </Route>

          <Route path="/admin">
            {/* <Header />
            <Templates />
            <Mainbody /> */}
            <Dashboard/>
          </Route>
          <Route path="/profile">
            <ListProfile />
          </Route>

          <Route path="/">
            <Home />
          </Route>
         
          {/* <Route path='/' exact component={Home} /> */}
          <Route path='/blog/:id' component={Blog} />
         
        </Switch>
      </Router>
    </div>
  );
}

export default App;
