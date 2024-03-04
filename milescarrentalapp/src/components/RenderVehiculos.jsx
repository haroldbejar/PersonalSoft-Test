import React, { useState, useContext } from 'react';
import "../css/RenderVehiculos.css";
import { MilesCarContext } from '../context/MilesCarContext';

const RenderVehiculos = ({ data }) => {
  const {setDataObjectCar} = useContext(MilesCarContext);
  const [selectedCard, setSelectedCard] = useState([]);

  const toggleCardSelection = (car) => {
    if (selectedCard === car) {
      setSelectedCard(null);
    } else {
      setSelectedCard(car);
      setDataObjectCar(car);
    }
  };

  const renderCars = () => {
    const chunkedData = [];
    for (let i = 0; i < data.length; i += 4) {
      chunkedData.push(data.slice(i, i + 4));
    }

    return chunkedData.map((chunk, index) => (
      <div key={index} className="row">
        {chunk.map((car, carIndex) => (
          <div key={carIndex} className="col-md-3">
            <div className="card">
              <img src={car.urlImage} alt={car.marca} className="card-img-top" />
              <div className="card-body">
                <input 
                  type="checkbox" 
                  className="form-check-input ml-1" 
                  onChange={() => toggleCardSelection(car)} 
                  checked={selectedCard === car}/>
                <h3 className="card-title mb-2 ml-4">
                  {car.marca} {car.modelo}
                </h3>
              </div>
            </div>
          </div>
        ))}
      </div>
    ));
  }
    
    return (
      <div className="container mt-5">
        {renderCars()}
      </div>
  )
}

export default RenderVehiculos