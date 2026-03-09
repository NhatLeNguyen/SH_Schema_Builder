import { Routes, Route, Navigate } from 'react-router-dom';
import SchemaEditor from './pages/SchemaEditor';
import Login from './pages/Login';

function App() {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/editor" element={<SchemaEditor />} />
      <Route path="/" element={<Navigate to="/editor" replace />} />
    </Routes>
  );
}

export default App;
