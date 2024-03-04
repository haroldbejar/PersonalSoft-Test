import React, { useState } from 'react';
import { useForm } from '../hooks/useForm';
import endPoints from '../endPoints/endPoints';
import axios from 'axios';

export const ModalLogin = ({ close, updateUserName, getUserId }) => {

  const { formulario, username, password, onChange } = useForm();

  const submit = async () => {
    const data = {
      username,
      password
    };
    try {
      const response = await axios.post(endPoints.Account.login, data);
      const token = response.data.token;
      const nameUser = response.data.userName;
      const userId = response.data.id;

      updateUserName(nameUser)
      getUserId(userId)
      if ( token ) {
        localStorage.setItem("tokenApp", token);
      } else {
        console.error("Token no encontrado");
      }
    } catch (err) {
      console.log("Error de inicio de sesión: ", err);
    } finally {
      close();
    }
  };

  return (
    <>
      <div className="modal" id="login">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <h4 style={{color: 'black'}} className="modal-title">Autenticarse</h4>
              <button type="button" className="close" data-dismiss="modal">
                &times;
              </button>
            </div>
            <div className="modal-body">
              <form>
                <div className="row">
                  <div className='col'>
                    <input 
                      type="text" 
                      className="form-control" 
                      placeholder="Usuario" 
                      name="username" 
                      onChange={({target}) => onChange(target.value, "username")}
                    />
                  </div>
                </div>
                <div className="row">
                  <div className='col'>
                  <input 
                      type="password" 
                      className="form-control" 
                      placeholder="Contraseña" 
                      name="password" 
                      onChange={({target}) => onChange(target.value, "password")}
                    />
                  </div>
                </div>
              </form>
            </div>
            <div className="modal-footer">
              <button 
                type="button" 
                className="btn btn-success" 
                onClick={submit}
              >
                Ingresar
              </button>
              <button 
                type="button" 
                className="btn btn-danger" 
                data-dismiss="modal"
              >
                Close
              </button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
