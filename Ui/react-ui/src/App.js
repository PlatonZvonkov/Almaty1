import logo from './logo.svg';
import './App.css'
import {PostForm} from './Components/PostForm'
import {Stylesheet} from './Components/Stylesheet'
import { GoodsList } from './Components/GoodsList';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <Stylesheet/>
      </header>
     <PostForm/>
      <GoodsList/>
    </div>
  );
}

export default App;
