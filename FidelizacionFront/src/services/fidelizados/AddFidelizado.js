import configData from '../../config.json'

const AddFidelizado = async (
  documento,
  tipoDocumentoId,
  nombre,
  contrasena,
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
      fidelizado: {
        documento: documento,
        tipoDocumentoId: tipoDocumentoId,
        nombre: nombre,
        porcentajePuntos: porcentajePuntos,
        centroVentaId: centroVentaId,
        informacionAdicional: {
          telefono: telefono,
          celular: celular,
          direccion: direccion,
          estrato: estrato,
          numeroHijos: numeroHijos,
          sexoId: sexo,
          ciudadId: ciudad,
          profesionId: profesion === 0 ? null : profesion,
        },
      },
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

export default AddFidelizado
