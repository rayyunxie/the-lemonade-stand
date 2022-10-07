import axios, { AxiosInstance } from 'axios';
import React, { createContext, useState } from 'react';

interface Props {
  children: React.ReactNode;
}

interface Client {
  client: AxiosInstance;
}

const HttpContext = createContext({} as Client);

const HttpProvider = ({ children }: Props): JSX.Element | null => {
  const axiosInstance = () =>
    axios.create({
      baseURL: process.env.REACT_APP_API_HOST,
      headers: {
        'Content-type': 'application/json',
      },
    });

  const [client] = useState(axiosInstance);

  return (
    <HttpContext.Provider value={{ client }}>{children}</HttpContext.Provider>
  );
};

export { HttpContext, HttpProvider };
