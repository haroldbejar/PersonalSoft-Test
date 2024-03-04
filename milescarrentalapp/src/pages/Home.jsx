import React, { useState } from 'react'
import "../css/Home.css";
import { Formulario } from './Formulario';
import Carrusel from '../components/Carrusel';
import { ModalLogin } from '../components/ModalLogin';

export const Home = () => {

  const [modal, setModal] = useState(false);
  const [userName, setUserName] = useState('Ingresar');
  const [userId, setUserId] = useState();

  const openModal = () => {
    setModal(true)
  }

  const closeModal = () => {
    setModal(false)
  }

  const updateUserName = (name) => {
    setUserName(name)
  }

  const getUserId = (id) => {
    setUserId(id)
  }
  
  return (
    <>
      <div className="content-home">
        <div className="navbar-home">
          <div className='left-items'>
            <h2 className="ml-5 mr-4">MilesCarRental</h2>
          </div>
          <div className='right-items'>
            <li className="nav-item mr-5">
              <a 
                className="nav-link" 
                data-toggle="modal" 
                data-target="#login" 
                data-backdrop="false"
                onClick={openModal}
              >
                {userName}
              </a>
            </li>
          </div>
        </div>
        <div className="container">
          <Formulario userId={userId}/>
          <Carrusel />
        </div>
      </div>
      {modal && (
        <ModalLogin 
          close={closeModal} 
          updateUserName={updateUserName} 
          getUserId={getUserId}
        />
      )}
    </>
    
  );
}
