import configData from '../../config.json'

const GetCentroVentaPorCompania = async () => {
  try {
    const token = localStorage.getItem('token')
    const compania = localStorage.getItem('idCompania')
    const response = await fetch(configData.SERVER_URL + '/api/CentroVentas/Compania/' + compania, {
      method: 'GET',
      mode: 'cors',
      headers: {
        'Access-Control-Allow-Origin': '*',
        accept: 'text/plain',
        'sec-fetch-mode': 'cors',
        Authorization: 'Bearer ' + token,
        'Access-Control-Allow-Headers': 'Content-Type',
        'Access-Control-Allow-Methods': 'OPTIONS,POST,GET',
      },
    })
    if (response.status === 200) {
      let centroVentas = await response.json()
      return centroVentas
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default GetCentroVentaPorCompania
