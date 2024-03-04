import { BrowserRouter as Router } from "react-router-dom"
import { RoutesApp } from "./routes/RoutesApp"
import { MilesCarProvider } from "./context/MilesCarContext"


function App() {

  return (
    <MilesCarProvider>
     <Router>
      <RoutesApp/>
     </Router>
    </MilesCarProvider>
  )
}

export default App
