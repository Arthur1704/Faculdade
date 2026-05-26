import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'

import { ConstContextProvider } from './context/CounterContext.jsx'
import { TitleColorContextProvider } from './context/TitleColorContext.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    {/* 2 - Criando Provider */}
    <ConstContextProvider>
      <TitleColorContextProvider>
        <App />
      </TitleColorContextProvider>
    </ConstContextProvider>
  </StrictMode>,
)
