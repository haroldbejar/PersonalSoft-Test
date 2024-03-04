import { createContext, useState } from "react";

export const MilesCarContext = createContext();

export const MilesCarProvider = ({ children }) => {

  const [ dataMilesCar, setDataMilesCar ] = useState({});
  const [ dataLocalidad, setDataLocalidad ] = useState({});
  const [ dataVehiculos, setDataVehiculos] = useState({});
  const [ dataObjectCar, setDataObjectCar] = useState("");
  
  const contextValues = {
    dataMilesCar,
    dataLocalidad,
    dataVehiculos,
    dataObjectCar,
    setDataVehiculos,
    setDataMilesCar,
    setDataLocalidad,
    setDataObjectCar
  }
  
  return (
    <MilesCarContext.Provider value={contextValues}>
        { children }
    </MilesCarContext.Provider>
  );
};
