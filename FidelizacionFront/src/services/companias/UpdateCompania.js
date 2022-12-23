import configData from '../../config.json'

const UpdateCompania = async (compania) => {
  try {
    const token = localStorage.getItem('token')
    const response = await fetch(configData.SERVER_URL + '/api/Companias', {
      method: 'PUT',
      mode: 'cors',
      body: JSON.stringify(compania),
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
      let compania = await response.json()
      return compania
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default UpdateCompania
