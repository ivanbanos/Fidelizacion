import configData from '../../config.json'

const AddUsuario = async (nombreUsuario, perfil, centroVentaId) => {
  try {
    const token = localStorage.getItem('token')
    const body = {
      nombreUsuario: nombreUsuario,
      perfil: perfil,
      centroVentaId: centroVentaId,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Usuarios', {
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
      let usuario = await response.json()
      return usuario
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default AddUsuario
