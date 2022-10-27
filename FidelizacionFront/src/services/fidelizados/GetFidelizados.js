import configData from '../../config.json'

const GetFidelizados = async () => {
  try {
    const response = await fetch(configData.SERVER_URL + '/api/Fidelizados', {
      method: 'GET',
      mode: 'cors',
      headers: {
        'Access-Control-Allow-Origin': '*',
        accept: 'text/plain',
        'sec-fetch-mode': 'cors',
        'Access-Control-Allow-Headers': 'Content-Type',
        'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
      },
    })
    if (response.status === 200) {
      let fidelizados = await response.json()
      return fidelizados
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default GetFidelizados
