import configData from '../../config.json'

const UpdateCentroVenta = async (centroVenta) => {
  try {
    const response = await fetch(configData.SERVER_URL + '/api/CentroVentas/' + centroVenta.id, {
      method: 'PUT',
      mode: 'cors',
      body: JSON.stringify(centroVenta),
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
      let centroVenta = await response.json()
      return centroVenta
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default UpdateCentroVenta
