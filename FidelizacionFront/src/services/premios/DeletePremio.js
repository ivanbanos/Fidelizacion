import configData from '../../config.json'

const DeletePremio = async (premioId) => {
  try {
    const token = localStorage.getItem('token')
    const body = {
      guid: premioId,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Premios', {
      method: 'DELETE',
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
      let respuesta = await response.json()
      return respuesta
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default DeletePremio
