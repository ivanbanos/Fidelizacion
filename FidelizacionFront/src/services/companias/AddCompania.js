import configData from '../../config.json'

const AddCompania = async (nit, nombre, vigenciaPuntos, tipoVencimiento) => {
  try {
    const body = {
      nombre: nombre,
      vigenciaPuntos: vigenciaPuntos,
      tipoVencimientoId: tipoVencimiento,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Companias', {
      method: 'POST',
      mode: 'cors',
      body: JSON.stringify(body),
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
      let companias = await response.json()
      return companias
    }
    if (response.status === 403) {
      return 'fail'
    }
    return 'fail'
  } catch (error) {
    return 'fail'
  }
}

export default AddCompania
