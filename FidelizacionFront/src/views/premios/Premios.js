import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import CIcon from '@coreui/icons-react'
import { cilPlus, cilPencil, cilX, cilCart } from '@coreui/icons'
import {
  CButton,
  CRow,
  CCol,
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CFormInput,
  CModal,
  CModalBody,
  CModalFooter,
  CModalHeader,
  CModalTitle,
  CFormSelect,
} from '@coreui/react'
import GetCentroVentas from '../../services/centroVentas/GetCentroVentas'
import GetCentroVentaPorCompania from '../../services/centroVentas/GetCentroVentaPorCompania'
import GetPremiosPorCompania from 'src/services/premios/GetPremiosPorCompania'
import GetPremiosVigentesPorCompania from 'src/services/premios/GetPremiosVidentesPorCompania'
import AddPremio from 'src/services/premios/AddPremio'
import UpdatePremio from 'src/services/premios/UpdatePremio'
import DeletePremio from 'src/services/premios/DeletePremio'
import RedimirPremio from 'src/services/premios/RedimirPremio'

const AddPremioModal = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [addPremioVisible, setAddPremioVisible] = useState(false)
  const [centroVentaDisabled, setCentroVentaDisabled] = useState(true)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(perfil === '1')
  const [newDescripcion, setNewDescripcion] = useState()
  const [newPuntos, setNewPuntosChange] = useState()
  const [newPrecio, setNewPrecioChange] = useState()
  const [newFechaFin, setNewFechaFinChange] = useState()
  const [newCentroVenta, setNewCentroVentaChange] = useState(centroVenta)

  const handleDescripcionChange = (event) => {
    setNewDescripcion(event.target.value)
  }
  const handlePuntosChange = (event) => {
    setNewPuntosChange(event.target.value)
  }
  const handlePrecioChange = (event) => {
    setNewPrecioChange(event.target.value)
  }
  const handleFechaFinChange = (event) => {
    setNewFechaFinChange(event.target.value)
  }
  const handleCentroVentaChange = (event) => {
    setNewCentroVentaChange(event.target.value)
  }
  const addPremio = async () => {
    await AddPremio(
      newDescripcion,
      newPuntos,
      newPrecio,
      newFechaFin,
      newCentroVenta === '0' ? null : newCentroVenta,
    )
    props.GetPremios()
    setNewCentroVentaChange(centroVenta)
    setAddPremioVisible(false)
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setAddPremioVisible(true)}>
        <CIcon icon={cilPlus} size="sm" />
      </CButton>
      <CModal
        visible={addPremioVisible}
        alignment="center"
        onClose={() => setAddPremioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Agregar Premio</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow className="mb-2">
            <CCol xs={3}>Descripci&oacute;n*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Descripci&oacute;n" onChange={handleDescripcionChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Puntos*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Puntos" onChange={handlePuntosChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Precio*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Precio" onChange={handlePrecioChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Fecha Fin*:</CCol>
            <CCol xs={9}>
              <CFormInput type="date" placeholder="Fecha Fin" onChange={handleFechaFinChange} />
            </CCol>
          </CRow>
          {inputCentroVentaVisible && (
            <CRow className="mb-2">
              <CCol xs={3}>Centro de Venta*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Default select example"
                  onChange={handleCentroVentaChange}
                  disabled={centroVentaDisabled}
                >
                  <option>Selecione un opcion</option>
                  {props.CentroVentas.map((centroVenta) => (
                    <option key={centroVenta.id} value={centroVenta.id}>
                      {centroVenta.nombre}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
          )}
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setAddPremioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={addPremio}>
            Agregar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const TaskPremio = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [updatePremioVisible, setUpdatePremioVisible] = useState(false)
  const [deletePremioVisible, setDeletePremioVisible] = useState(false)
  const [redimirPremioVisible, setRedimirPremioVisible] = useState(false)
  const [respuestaRedimirPremioVisible, setRespuestaRedimirPremioVisible] = useState(false)
  const [respuestaRedecionPremio, setRespuestaRedecionPremio] = useState({})
  const [centroVentaDisabled, setCentroVentaDisabled] = useState(perfil === 1)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(perfil === '1')

  const [newDescripcion, setNewDescripcion] = useState(props.Premio.nombre)
  const [newPuntos, setNewPuntosChange] = useState(props.Premio.puntos)
  const [newPrecio, setNewPrecioChange] = useState(props.Premio.precio)
  const [newFechaFin, setNewFechaFinChange] = useState(props.Premio.fechaFin)
  const [newDocumentoFidelizado, setNewDocumentoFidelizadoChange] = useState()
  const [newCantidad, setNewCantidadChange] = useState()
  const [newCentroVenta, setNewCentroVentaChange] = useState(centroVenta)

  let respuesta2 = {}

  const handleDescripcionChange = (event) => {
    setNewDescripcion(event.target.value)
  }
  const handlePuntosChange = (event) => {
    setNewPuntosChange(event.target.value)
  }
  const handlePrecioChange = (event) => {
    setNewPrecioChange(event.target.value)
  }
  const handleFechaFinChange = (event) => {
    setNewFechaFinChange(event.target.value)
  }
  const handleDocumentoFidelizadoChange = (event) => {
    setNewDocumentoFidelizadoChange(event.target.value)
  }
  const handleCantidadChange = (event) => {
    setNewCantidadChange(event.target.value)
  }
  const handleCentroVentaChange = (event) => {
    setNewCentroVentaChange(event.target.value)
  }

  const updatePremio = async () => {
    let premio = props.Premio
    premio.nombre = newDescripcion
    premio.puntos = newPuntos
    premio.precio = newPrecio
    premio.fechaFin = newFechaFin
    await UpdatePremio(props.Premio)
    props.GetPremios()
    setNewCentroVentaChange(centroVenta)
    setUpdatePremioVisible(false)
  }
  const deletePremio = async () => {
    await DeletePremio(props.Premio.guid)
    props.GetPremios()
    setDeletePremioVisible(false)
  }
  const redimirPremio = async () => {
    let respuesta = await RedimirPremio(
      props.Premio.guid,
      newCantidad,
      newDocumentoFidelizado,
      centroVenta,
    )
    respuesta2 = respuesta
    console.log(respuesta2)
    setRespuestaRedecionPremio(respuesta2)
    props.GetPremios()
    setRedimirPremioVisible(false)
    setRespuestaRedimirPremioVisible(true)
  }

  const handlePrint = () => {
    const printWindow = window.open('', '_blank')
    printWindow.document.write(`
      <html>
        <head>
          <title>Acta de Entrega de Premio</title>
        </head>
        <body>
        <div>
          <h3>Acta de Entrega de Premio</h3>
          <br />
          <br />
          <p>
            En ${respuestaRedecionPremio.ciudadCentroVenta}, a${' '}
            ${respuestaRedecionPremio.fechaRedencion}, se lleva a cabo la ceremonia de entrega del
            premio ${respuestaRedecionPremio.descripcioPremio}, otorgado por${' '}
            ${respuestaRedecionPremio.nombreCentroVenta}, a cambio del consumo de${' '}
            ${respuestaRedecionPremio.puntosConsumidos} puntos.
          </p>
          <br />
          <br />
          <br />
          <br />
          <p>____________________________ </p>
          <p> ${respuestaRedecionPremio.nombreFidelizado}</p>
          <p> ${respuestaRedecionPremio.cedulaFidelizado}</p>
        </div>
        </body>
      </html>
    `)
    printWindow.document.close()
    printWindow.print()
  }

  return (
    <>
      {(perfil === '1' || perfil === '2') && (
        <>
          <CButton style={{ margin: '2pt' }} onClick={() => setUpdatePremioVisible(true)}>
            <CIcon icon={cilPencil} size="sm" />
          </CButton>
          <CModal
            visible={updatePremioVisible}
            alignment="center"
            onClose={() => setUpdatePremioVisible(false)}
          >
            <CModalHeader>
              <CModalTitle>Actualizar Premio</CModalTitle>
            </CModalHeader>
            <CModalBody>
              <CRow className="mb-2">
                <CCol xs={3}>Descripci&oacute;n*:</CCol>
                <CCol xs={9}>
                  <CFormInput
                    value={newDescripcion}
                    placeholder="Descripci&oacute;n"
                    onChange={handleDescripcionChange}
                  />
                </CCol>
              </CRow>
              <CRow className="mb-2">
                <CCol xs={3}>Puntos*:</CCol>
                <CCol xs={9}>
                  <CFormInput
                    value={newPuntos}
                    placeholder="Puntos"
                    onChange={handlePuntosChange}
                  />
                </CCol>
              </CRow>
              <CRow className="mb-2">
                <CCol xs={3}>Precio*:</CCol>
                <CCol xs={9}>
                  <CFormInput
                    value={newPrecio}
                    placeholder="Precio"
                    onChange={handlePrecioChange}
                  />
                </CCol>
              </CRow>
              <CRow className="mb-2">
                <CCol xs={3}>Fecha Fin*:</CCol>
                <CCol xs={9}>
                  <CFormInput
                    type="date"
                    value={newFechaFin}
                    placeholder="Fecha Fin"
                    onChange={handleFechaFinChange}
                  />
                </CCol>
              </CRow>
              {inputCentroVentaVisible && (
                <CRow className="mb-2">
                  <CCol xs={3}>Centro de Venta*:</CCol>
                  <CCol xs={9}>
                    <CFormSelect
                      value={newCentroVenta}
                      aria-label="Default select example"
                      onChange={handleCentroVentaChange}
                      disabled={centroVentaDisabled}
                    >
                      <option>Selecione un opcion</option>
                      {props.CentroVentas.map((centroVenta) => (
                        <option key={centroVenta.id} value={centroVenta.id}>
                          {centroVenta.nombre}
                        </option>
                      ))}
                    </CFormSelect>
                  </CCol>
                </CRow>
              )}
            </CModalBody>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setUpdatePremioVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" onClick={updatePremio}>
                Actualizar
              </CButton>
            </CModalFooter>
          </CModal>
          <CButton style={{ margin: '2pt' }} onClick={() => setDeletePremioVisible(true)}>
            <CIcon icon={cilX} size="sm" />
          </CButton>
          <CModal
            visible={deletePremioVisible}
            alignment="center"
            onClose={() => setDeletePremioVisible(false)}
          >
            <CModalHeader>
              <CModalTitle>Eliminar Premio</CModalTitle>
            </CModalHeader>
            <CModalBody>
              <CRow>
                <label>Esta seguro?</label>
              </CRow>
            </CModalBody>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setDeletePremioVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" onClick={deletePremio}>
                Eliminar
              </CButton>
            </CModalFooter>
          </CModal>
        </>
      )}

      <CButton style={{ margin: '2pt' }} onClick={() => setRedimirPremioVisible(true)}>
        <CIcon icon={cilCart} size="sm" />
      </CButton>
      <CModal
        visible={redimirPremioVisible}
        alignment="center"
        onClose={() => setRedimirPremioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Redimir Premio</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow className="mb-2">
            <CCol xs={3}>Documento Fidelizado*:</CCol>
            <CCol xs={9}>
              <CFormInput
                placeholder="Documento Fidelizado"
                onChange={handleDocumentoFidelizadoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Cantidad*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Cantidad" onChange={handleCantidadChange} />
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setRedimirPremioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={redimirPremio}>
            Redimir
          </CButton>
        </CModalFooter>
      </CModal>
      <CModal
        visible={respuestaRedimirPremioVisible}
        alignment="center"
        onClose={() => setRespuestaRedimirPremioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Premio Redimido Exitosamente!</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <div>
            <h3>Acta de Entrega de Premio</h3>
            <br />
            <br />
            <p>
              En {respuestaRedecionPremio.ciudadCentroVenta}, a{' '}
              {respuestaRedecionPremio.fechaRedencion}, se lleva a cabo la ceremonia de entrega del
              premio {respuestaRedecionPremio.descripcioPremio}, otorgado por{' '}
              {respuestaRedecionPremio.nombreCentroVenta}, a cambio del consumo de{' '}
              {respuestaRedecionPremio.puntosConsumidos} puntos.
            </p>
            <br />
            <br />
            <br />
            <br />
            <p>____________________________ </p>
            <p> {respuestaRedecionPremio.nombreFidelizado}</p>
            <p> {respuestaRedecionPremio.cedulaFidelizado}</p>
          </div>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setRespuestaRedimirPremioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={handlePrint}>
            Imprimir
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const Premios = () => {
  let navigate = useNavigate()
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [Premios, setPremios] = useState([])
  const [CentroVentas, setCentroVentas] = useState([])
  const toastRef = useRef()

  const fetchPremios = async () => {
    let premios = []
    if (perfil === '1' || perfil === '2') {
      premios = await GetPremiosPorCompania(centroVenta)
    } else {
      premios = await GetPremiosVigentesPorCompania(centroVenta)
    }

    if (premios === 'fail') {
      navigate('/Login', { replace: true })
    }

    setPremios(premios)
  }

  const fetchCentroVentas = async () => {
    let CentroVentas = []
    if (perfil === '1') {
      CentroVentas = await GetCentroVentas()
    } else {
      CentroVentas = await GetCentroVentaPorCompania()
    }
    if (CentroVentas === 'fail') {
      navigate('/Login', { replace: true })
    }

    setCentroVentas(CentroVentas)
  }

  useEffect(() => {
    fetchPremios()
    fetchCentroVentas()
  }, [])

  return (
    <>
      <h1>Premios</h1>
      <AddPremioModal GetPremios={fetchPremios} CentroVentas={CentroVentas} />
      <CRow>
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Descripción</CTableHeaderCell>
              <CTableHeaderCell scope="col">Puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col">Precio</CTableHeaderCell>
              <CTableHeaderCell scope="col">Fecha de Inicio</CTableHeaderCell>
              <CTableHeaderCell scope="col">Fecha de Fin</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
            {Premios.map((premio) => (
              <CTableRow key={premio.guid}>
                <CTableHeaderCell>{premio.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{premio.puntos}</CTableHeaderCell>
                <CTableHeaderCell>{premio.precio}</CTableHeaderCell>
                <CTableHeaderCell>{premio.fechaInicio}</CTableHeaderCell>
                <CTableHeaderCell>{premio.fechaFin}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskPremio
                    GetPremios={fetchPremios}
                    Premio={premio}
                    CentroVentas={CentroVentas}
                  />
                </CTableHeaderCell>
              </CTableRow>
            ))}
          </CTableBody>
        </CTable>
      </CRow>
    </>
  )
}

export default Premios
