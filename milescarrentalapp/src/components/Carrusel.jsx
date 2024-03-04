import React, { useState, useContext, useEffect } from 'react'
import { MilesCarContext } from '../context/MilesCarContext';
import RenderVehiculos from './RenderVehiculos';
import "../css/Carrusel.css"

const Carrusel = () => {

  const { dataVehiculos } = useContext(MilesCarContext);
  
  return (
    <>
    {Object.keys(dataVehiculos).length !== 0  ? (
      <RenderVehiculos data={dataVehiculos}/>
       ) :
       <div id="demo" className="carousel slide mt-5" data-ride="carousel">
        {/* <!-- Indicators --> */}
        <ul className="carousel-indicators">
          <li data-target="#demo" data-slide-to="0" className="active"></li>
          <li data-target="#demo" data-slide-to="1"></li>
          <li data-target="#demo" data-slide-to="2"></li>
        </ul>

        {/* <!-- The slideshow --> */}
        <div className="carousel-inner">
          <div className="carousel-item active">
            <img src="src\assets\img\fiesta2015.jpg" alt="Fiesta" width="1100" height="500" />
          </div>
          <div className="carousel-item">
            <img src="src\assets\img\skyactive2021.jpg" alt="Skyactive" width="1100" height="500" />
          </div>
          <div className="carousel-item">
            <img src="src\assets\img\onix2018.jpg" alt="Onix" width="1100" height="500" />
          </div>
        </div>

        {/* <!-- Left and right controls --> */}
        <a className="carousel-control-prev" href="#demo" data-slide="prev">
          <span className="carousel-control-prev-icon"></span>
        </a>
        <a className="carousel-control-next" href="#demo" data-slide="next">
          <span className="carousel-control-next-icon"></span>
        </a>
      </div>
      }
    </>
  );
}

export default Carrusel