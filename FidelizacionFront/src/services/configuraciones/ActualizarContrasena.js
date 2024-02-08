import configData from '../../config.json'

const ActualizarContrasena = async (contrasenaNueva) => {
  try {
    const token = localStorage.getItem('token')
    const usuarioId = localStorage.getItem('idUsuario')
    const body = {
      usuario: usuarioId,
      contrasena: contrasenaNueva,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Configuracion/Contrasena', {
      method: 'PUT',
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
      let contrasena = await response.json()
      return { status: response.status, response: contrasena }
    }
    if (response.status === 400 || response.status === 403 || response.status === 500) {
      return { status: response.status, response: await response.text() }
    }
    return { status: response.status, response: await response.text() }
  } catch (error) {
    return { status: 500, response: error }
  }
}

export default ActualizarContrasena
