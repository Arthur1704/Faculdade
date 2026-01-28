import logo from './logo.svg';
import './App.css';

function Login() {
    return (
    <div className="tarefa">
      <form action="">
        <input type="text" name="login" id="login" />
        <input type="text" name="senha" id="senha" />
      </form>
    </div>
  )
}


function App() {
  return (
    <div className="App">
        <h1>Hello Word</h1>
        <Login />
    </div>
  )
}




export default App;
