import configData from '../../config.json'

const GetUsuariosPorCompania = async () => {
  try {
    const token = localStorage.getItem('token')
    const compania = localStorage.getItem('idCompania')
    const response = await fetch(configData.SERVER_URL + '/api/Usuarios/Compania/' + compania, {
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

export default GetUsuariosPorCompania
