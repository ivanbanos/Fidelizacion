import configData from '../../config.json'

const UpdateFidelizado = async (fidelizado) => {
  try {
    const response = await fetch(configData.SERVER_URL + '/api/Fidelizados/' + fidelizado.id, {
      method: 'PUT',
      mode: 'cors',
      body: JSON.stringify(fidelizado),
      headers: {
        'Access-Control-Allow-Origin': '*',
        accept: 'text/plain',
        'Content-Type': 'application/json',
        'sec-fetch-mode': 'cors',
        'Access-Control-Allow-Headers': 'Content-Type',
        'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
      },
    })
    if (response.status === 200) {
      let fidelizado = await response.json()
      return fidelizado
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default UpdateFidelizado
