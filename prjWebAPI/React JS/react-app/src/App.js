import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import DCandidateForm from './components/DCandidateForm';

function App() {
  return (
    <Provider store={store}>
      <DCandidateForm />
    </Provider>    
  );
}

export default App;
