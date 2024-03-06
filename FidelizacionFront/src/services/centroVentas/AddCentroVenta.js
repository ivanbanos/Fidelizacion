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
      ciudadId: ciudad,
      companiaId: idCompania,
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
      return { status: response.status, response: centroVentas }
    }
    if (response.status === 400 || response.status === 403 || response.status === 500) {
      return { status: response.status, response: await response.text() }
    }
    return { status: response.status, response: await response.text() }
  } catch (error) {
    return { status: 500, response: error }
  }
}

export default AddCentroVenta
