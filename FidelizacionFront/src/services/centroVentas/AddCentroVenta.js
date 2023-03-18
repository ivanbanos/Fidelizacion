import configData from '../../config.json'

const AddCentroVenta = async (
  nit,
  nombre,
  direccion,
  telefono,
  valorPorPunto,
  ciudad,
  idCompania,
) => {
  try {
    const token = localStorage.getItem('token')
    const body = {
      nit: nit,
      nombre: nombre,
      direccion: direccion,
      telefono: telefono,
      valorPorPunto: valorPorPunto,
      companiaId: idCompania,
      ciudadId: ciudad,
    }
    const response = await fetch(configData.SERVER_URL + '/api/CentroVentas', {
      method: 'POST',
      mode: 'cors',
      body: JSON.stringify(body),
      headers: {
        'Access-Control-Allow-Origin': '*',
        accept: 'text/plain',
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + token,
        'sec-fetch-mode': 'cors',
        'Access-Control-Allow-Headers': 'Content-Type',
        'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
      },
    })
    if (response.status === 200) {
      let centroVentas = await response.json()
      return centroVentas
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default AddCentroVenta
