import { useState, useContext, useRef } from "react";
import { Button } from "../components/Button";
import { useForm } from "../hooks/useForm";
import { useFetch } from "../hooks/useFetch";
import  endPoints  from "../endPoints/endPoints";
import { MilesCarContext } from "../context/MilesCarContext";
import moment from "moment";

export const Formulario = ({ userId }) => {

  const refLocalidadIni = useRef(null);
  const refLocalidadDevo = useRef(null);
  const { dataObjectCar,setDataMilesCar, setDataVehiculos } = useContext(MilesCarContext);
  const { get, post } = useFetch();

  const [siguiente, setSiguiente] = useState(false);
  const [iniLocalidad, setIniLocalidad] = useState("");
  const [devoLocaliad, setDevoLocalidad] = useState("");
  const [localIni, setLocalIni] = useState("");
  const [localDevo, setLocalDevo] = useState("");

  const { 
    recogida, 
    devolucion, 
    onChange 
  } = useForm();

  const mapValuesToSave = () => {
    const dataForm = {
      clienteid: userId,
      vehiculoid: dataObjectCar.id,
      localidadrecogidaid: localIni,
      localidadevolucionid: localDevo,
      fechaderecogida: moment(recogida).format('YYYY-MM-DD'),
      fechadevolucion: moment(devolucion).format('YYYY-MM-DD')
    }
    return dataForm;
  }

  const submit = async (e) => {
    e.preventDefault();
    const token = localStorage.getItem("tokenApp");
    if (!token) {
      alert("debe autenticarse")
    }

    try {
      const mapedValues = mapValuesToSave();
      await post(endPoints.Reserva.base, mapedValues);
     
    } catch (err) {
      console.error(err);
    } finally {
      alert("Reserva exitosa!")
    }
  };

  const onChangeLocalidadIni = () => {
    setIniLocalidad(refLocalidadIni.current.value);
  }

  const onChangeLocalidadDevo = () => {
    setDevoLocalidad(refLocalidadDevo.current.value);
  }

  const getVehiculos = async (idLocalidad) => {
    try {
      const result = await get(`${endPoints.Vehiculo.vehiculoByLocalidad}/${idLocalidad}`);
      setDataMilesCar(result)
      setDataVehiculos(result)
    } catch (err) {
      console.error(err)
    }
  }

  const getLocalidad = async () => {
    try {
      if (iniLocalidad) {
        const resultIni = await get(`${endPoints.Localidad.localidadByName}/${iniLocalidad}`);
        getVehiculos(resultIni.id)
        setLocalIni(resultIni.id)
      }
      if (devoLocaliad) {
        const resultDevo = await get(`${endPoints.Localidad.localidadByName}/${devoLocaliad}`);
        setLocalDevo(resultDevo.id)
      }
      
    } catch (err) {
      console.err(err);
    } finally {
      setSiguiente(true)
    }
  }

  return (
    <>
      <div className="row mt-4 mb-4">
        <div className="col-2">
          <input
            type="text"
            className="form-control"
            placeholder="Localidad inicio"
            name="localidadIni"
            ref={refLocalidadIni}
            onChange={onChangeLocalidadIni}
          />
        </div>
        <div className="col-2">
          <input
            type="text"
            className="form-control"
            placeholder="Localidad final"
            name="localidadDevo"
            ref={refLocalidadDevo}
            onChange={onChangeLocalidadDevo}
          />
        </div>
        <div className="col-2">
          <input
            type="datetime-local"
            className="form-control"
            name="recogida"
            onChange={({ target }) => onChange(target.value, "recogida")}
          />
        </div>
        <div className="col-2">
          <input
            type="datetime-local"
            className="form-control"
            name="devolucion"
            onChange={({ target }) => onChange(target.value, "devolucion")}
          />
        </div>
        {!siguiente ? (
          <div className="col">
            <button
              type="button"
              className="btn btn-success"
              onClick={getLocalidad}
            >
              Seguir
            </button>
          </div>
        ) : <div className="col mr-5">
          <Button
              btnType="button"
              btnClass="btn btn-success mr-3"
              btnText="Reserva"
              onClick={submit}
            />
          </div>}
      </div>
    </>
  );
};
