import { Routes, Route, Navigate } from 'react-router-dom'
import SchemaEditor from './pages/SchemaEditor'
import './App.css'

function App() {
  return (
    <Routes>
      <Route path="/" element={<Navigate to="/editor" replace />} />
      <Route path="/editor" element={<SchemaEditor />} />
    </Routes>
  )
}

export default App
