import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { ThemeProvider } from '@emotion/react';
import { common, yellow } from '@mui/material/colors';
import { createTheme } from '@mui/material';
import { QueryClient, QueryClientProvider } from 'react-query';
import { ErrorBoundary } from 'react-error-boundary';
import { ErrorBoundaryFallBack } from './ErrorBoundaryFallBack';
import './index.css';
import { HttpProvider } from './HttpContext';
import { BrowserRouter } from 'react-router-dom';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const theme = createTheme({
  palette: {
    primary: {
      main: common.black,
    },
    secondary: {
      main: yellow[600],
    },
  },
});

const queryClient = new QueryClient({
  defaultOptions: {
    queries: { refetchOnWindowFocus: false, staleTime: Infinity },
  },
});

root.render(
  <React.StrictMode>
    <BrowserRouter basename={process.env.REACT_APP_BASE_URL}>
      <HttpProvider>
        <ThemeProvider theme={theme}>
          <QueryClientProvider client={queryClient}>
            <ErrorBoundary FallbackComponent={ErrorBoundaryFallBack}>
              <App />
            </ErrorBoundary>
          </QueryClientProvider>
        </ThemeProvider>
      </HttpProvider>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
