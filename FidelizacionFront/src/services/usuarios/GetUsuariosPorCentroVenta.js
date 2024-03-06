import configData from '../../config.json'

const GetUsuariosPorCentroVenta = async () => {
  try {
    const token = localStorage.getItem('token')
    const centroVenta = localStorage.getItem('idCentroVenta')
    const response = await fetch(
      configData.SERVER_URL + '/api/Usuarios/CentroVenta/' + centroVenta,
      {
        method: 'GET',
        mode: 'cors',
        headers: {
          'Access-Control-Allow-Origin': '*',
          accept: 'text/plain',
          Authorization: 'Bearer ' + token,
          'sec-fetch-mode': 'cors',
          'Access-Control-Allow-Headers': 'Content-Type',
          'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
        },
      },
    )
    if (response.status === 200) {
      let usuario = await response.json()
      return { status: response.status, response: usuario }
    }
    if (response.status === 400 || response.status === 403 || response.status === 500) {
      return { status: response.status, response: await response.text() }
    }
    return { status: response.status, response: await response.text() }
  } catch (error) {
    return { status: 500, response: error }
  }
}

export default GetUsuariosPorCentroVenta
