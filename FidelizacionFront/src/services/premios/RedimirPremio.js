import configData from '../../config.json'

const RedimirPremio = async (premioId, cantidad, documentoFidelizado, centroVentaId) => {
  try {
    const token = localStorage.getItem('token')
    const body = {
      premioId: premioId,
      cantidad: cantidad,
      documentoFidelizado: documentoFidelizado,
      centroDeVentaId: centroVentaId,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Premios/Redimir', {
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
      console.log('entro aquí 1')
      let premio = await response.json()
      return premio
    }
    if (response.status === 403) {
      console.log('entro aquí 2')
      return 'fail'
    }
    console.log('entro aquí 3')
    return 'fail'
  } catch (error) {
    console.log('entro aquí 4')
    return 'fail'
  }
}

export default RedimirPremio
