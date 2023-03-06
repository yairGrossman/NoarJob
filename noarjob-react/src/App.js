import "./App.css";
import Header from "./Components/Header";
import Login from "./Components/Login";
import Signup from "./Components/Signup";
import Search from "./Components/Search";
import { BrowserRouter } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Header />
      </BrowserRouter>
    </div>
  );
}

export default App;
