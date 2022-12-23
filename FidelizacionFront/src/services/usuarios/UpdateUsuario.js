import configData from '../../config.json'

const UpdateUsuario = async (usuario) => {
  try {
    const token = localStorage.getItem('token')
    const response = await fetch(configData.SERVER_URL + '/api/Usuarios', {
      method: 'PUT',
      mode: 'cors',
      body: JSON.stringify(usuario),
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

export default UpdateUsuario
