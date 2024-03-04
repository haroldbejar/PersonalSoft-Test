const baseUrl = "https://localhost:7030/api/"; //http://localhost:5159
const endPoints = {
    Account: {
        login: `${baseUrl}Account/login`,
        register: `${baseUrl}Account/register`
    },
    Reserva: {
        base: `${baseUrl}Reservacion`,
        findVehicles: `${baseUrl}`
    },
    Cliente: {
        base: `${baseUrl}Cliente`,
    },
    Localidad: {
        base: `${baseUrl}Localidad`,
        localidadByName: `${baseUrl}Localidad/localidadbyname`
    },
    Vehiculo: {
        base: `${baseUrl}Vehiculo`,
        vehiculoByParam: `${baseUrl}Vehiculo/vehiculosbyparam`,
        vehiculoByLocalidad: `${baseUrl}Vehiculo/vehiculosbylocalidad`
    }
};

export default endPoints;