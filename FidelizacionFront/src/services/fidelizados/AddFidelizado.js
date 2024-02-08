import configData from '../../config.json'

const AddFidelizado = async (
  documento,
  tipoDocumentoId,
  nombre,
  porcentajePuntos,
  centroVentaId,
  telefono,
  celular,
  direccion,
  estrato,
  numeroHijos,
  sexo,
  ciudad,
  profesion,
) => {
  try {
    const token = localStorage.getItem('token')
    const idUsuario = localStorage.getItem('idUsuario')
    const body = {
      documento: documento,
      tipoDocumentoId: tipoDocumentoId,
      nombre: nombre,
      porcentajePuntos: porcentajePuntos,
      centroVentaId: centroVentaId,
      telefono: telefono,
      celular: celular,
      direccion: direccion,
      estrato: estrato,
      numeroHijos: numeroHijos,
      sexoId: sexo,
      ciudadId: ciudad,
      profesionId: profesion === 0 ? null : profesion,
      usuario: idUsuario,
    }
    const response = await fetch(configData.SERVER_URL + '/api/Fidelizados', {
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
      let fidelizado = await response.json()
      return { status: response.status, response: fidelizado }
    }
    if (response.status === 400 || response.status === 403 || response.status === 500) {
      return { status: response.status, response: await response.text() }
    }
    return { status: response.status, response: await response.text() }
  } catch (error) {
    return { status: 500, response: error }
  }
}

export default AddFidelizado
