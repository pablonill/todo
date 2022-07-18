import 'bootstrap/dist/css/bootstrap.min.css';
import { Navigation } from './components/NavigationBar';
import { TodoGrid } from './components/TodosGrid';

function App() {
  return (
   <>
    <Navigation/>
    <TodoGrid/>
   </>
  );
}

export default App;
