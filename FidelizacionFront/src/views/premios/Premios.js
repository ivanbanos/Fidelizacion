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
  CForm,
  CFormInput,
  CFormSelect,
  CModal,
  CModalBody,
  CModalFooter,
  CModalHeader,
  CModalTitle,
} from '@coreui/react'
import GetCentroVentas from '../../services/centroVentas/GetCentroVentas'
import GetCentroVentaPorCompania from '../../services/centroVentas/GetCentroVentaPorCompania'
import GetPremiosPorCompania from 'src/services/premios/GetPremiosPorCompania'
import GetPremiosVigentesPorCentroVenta from 'src/services/premios/GetPremiosVigentesPorCentroVenta'
import AddPremio from 'src/services/premios/AddPremio'
import UpdatePremio from 'src/services/premios/UpdatePremio'
import DeletePremio from 'src/services/premios/DeletePremio'
import RedimirPremio from 'src/services/premios/RedimirPremio'
import Toast from '../notifications/toasts/Toasts'

const AddPremioModal = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [validated, setValidated] = useState(false)
  const [addPremioVisible, setAddPremioVisible] = useState(false)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(
    perfil === '1' || perfil === '2',
  )
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

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
      setValidated(true)
    }
    if (form.checkValidity() === true) {
      let resultado = await AddPremio(
        newDescripcion,
        newPuntos,
        newPrecio,
        newFechaFin,
        newCentroVenta === '0' ? centroVenta : newCentroVenta,
      )
      props.GetPremios()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 403 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Premio agregado con exito', 'success')
        setAddPremioVisible(false)
      }
    }
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
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Descripci&oacute;n*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Descripci&oacute;n"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDescripcionChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Puntos*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Puntos"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePuntosChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Precio*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Precio"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePrecioChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Fecha Fin*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Fecha Fin"
                  type="date"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleFechaFinChange}
                  required
                />
              </CCol>
            </CRow>
            {inputCentroVentaVisible && (
              <CRow className="mb-2">
                <CCol xs={3}>Centro de Venta*:</CCol>
                <CCol xs={9}>
                  <CFormSelect
                    aria-label="Centro de venta"
                    feedbackInvalid="Este campo es requerido"
                    onChange={handleCentroVentaChange}
                    required
                  >
                    <option selected="" value="">
                      Seleccione una opci&oacute;n
                    </option>
                    {props.CentroVentas.map((centroVenta) => (
                      <option key={centroVenta.id} value={centroVenta.id}>
                        {centroVenta.nombre}
                      </option>
                    ))}
                  </CFormSelect>
                </CCol>
              </CRow>
            )}
            <CModalFooter>
              <CButton color="secondary" onClick={() => setAddPremioVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Agregar
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
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
  const [validated, setValidated] = useState(false)
  const [validatedRedimir, setValidatedRedimir] = useState(false)
  const [respuestaRedecionPremio, setRespuestaRedecionPremio] = useState({})
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(
    perfil === '1' || perfil === '2',
  )
  const [newDescripcion, setNewDescripcion] = useState(props.Premio.nombre)
  const [newPuntos, setNewPuntosChange] = useState(props.Premio.puntos)
  const [newPrecio, setNewPrecioChange] = useState(props.Premio.precio)
  const [newFechaFin, setNewFechaFinChange] = useState(props.Premio.fechaFin)
  const [newDocumentoFidelizado, setNewDocumentoFidelizadoChange] = useState()
  const [newCantidad, setNewCantidadChange] = useState()
  const [newCentroVenta, setNewCentroVentaChange] = useState(props.Premio.centroVentaId)

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

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
      setValidated(true)
    }
    if (form.checkValidity() === true) {
      let premio = props.Premio
      premio.nombre = newDescripcion
      premio.puntos = newPuntos
      premio.precio = newPrecio
      premio.fechaFin = newFechaFin
      premio.centroVentaId = newCentroVenta === '0' ? centroVenta : newCentroVenta
      let resultado = await UpdatePremio(props.Premio)
      props.GetPremios()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 403 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Premio actualizado con exito', 'success')
        setUpdatePremioVisible(false)
      }
    }
  }
  const deletePremio = async () => {
    let resultado = await DeletePremio(props.Premio.guid)
    if (resultado.status === 400 || resultado.status === 500) {
      props.toast.current.showToast(resultado.response, 'danger')
    }
    props.GetPremios()
    setDeletePremioVisible(false)
    if (resultado.status === 200) {
      props.toast.current.showToast('Premio eliminado con exito', 'success')
    }
  }
  const redimirPremio = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
      setValidated(true)
    }

    if (form.checkValidity() === true) {
      let resultado = await RedimirPremio(
        props.Premio.guid,
        newCantidad,
        newDocumentoFidelizado,
        centroVenta,
      )
      props.GetPremios()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 403 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      setRedimirPremioVisible(false)
      if (resultado.status === 200) {
        setRespuestaRedecionPremio(resultado.response)
        setRespuestaRedimirPremioVisible(true)
      }
    }
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
          <p>
            Quedando un saldo disponibles ${respuestaRedecionPremio.puntosRestantes} puntos.
          </p>
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
              <CForm
                className="row g-3 needs-validation"
                noValidate
                validated={validated}
                onSubmit={handleSubmit}
              >
                <CRow className="mb-2">
                  <CCol xs={3}>Descripci&oacute;n*:</CCol>
                  <CCol xs={9}>
                    <CFormInput
                      value={newDescripcion}
                      placeholder="Descripci&oacute;n"
                      type="text"
                      feedbackInvalid="Este campo es requerido"
                      onChange={handleDescripcionChange}
                      required
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-2">
                  <CCol xs={3}>Puntos*:</CCol>
                  <CCol xs={9}>
                    <CFormInput
                      value={newPuntos}
                      placeholder="Puntos"
                      type="number"
                      feedbackInvalid="Este campo es requerido"
                      onChange={handlePuntosChange}
                      required
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-2">
                  <CCol xs={3}>Precio*:</CCol>
                  <CCol xs={9}>
                    <CFormInput
                      value={newPrecio}
                      placeholder="Precio"
                      type="number"
                      feedbackInvalid="Este campo es requerido"
                      onChange={handlePrecioChange}
                      required
                    />
                  </CCol>
                </CRow>
                <CRow className="mb-2">
                  <CCol xs={3}>Fecha Fin*:</CCol>
                  <CCol xs={9}>
                    <CFormInput
                      value={newFechaFin}
                      placeholder="Fecha Fin"
                      type="date"
                      feedbackInvalid="Este campo es requerido"
                      onChange={handleFechaFinChange}
                      required
                    />
                  </CCol>
                </CRow>
                {inputCentroVentaVisible && (
                  <CRow className="mb-2">
                    <CCol xs={3}>Centro de Venta*:</CCol>
                    <CCol xs={9}>
                      <CFormSelect
                        value={newCentroVenta}
                        aria-label="Centro de venta"
                        feedbackInvalid="Este campo es requerido"
                        onChange={handleCentroVentaChange}
                        required
                      >
                        <option selected="" value="">
                          Seleccione una opci&oacute;n
                        </option>
                        {props.CentroVentas.map((centroVenta) => (
                          <option key={centroVenta.id} value={centroVenta.id}>
                            {centroVenta.nombre}
                          </option>
                        ))}
                      </CFormSelect>
                    </CCol>
                  </CRow>
                )}
                <CModalFooter>
                  <CButton color="secondary" onClick={() => setUpdatePremioVisible(false)}>
                    Cerrar
                  </CButton>
                  <CButton color="primary" type="submit">
                    Actualizar
                  </CButton>
                </CModalFooter>
              </CForm>
            </CModalBody>
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
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validatedRedimir}
            onSubmit={redimirPremio}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Documento Fidelizado*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Documento Fidelizado"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDocumentoFidelizadoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Cantidad*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Cantidad"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleCantidadChange}
                  required
                />
              </CCol>
            </CRow>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setRedimirPremioVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Redimir
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
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
            <p>
              Quedando un saldo disponibles de {respuestaRedecionPremio.puntosRestantes} puntos.
            </p>
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
    let resultado = []
    if (perfil === '1' || perfil === '2') {
      resultado = await GetPremiosPorCompania(centroVenta)
    } else {
      resultado = await GetPremiosVigentesPorCentroVenta(centroVenta)
    }
    if (resultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (resultado.status === 400 || resultado.status === 500) {
      toastRef.current.showToast(resultado.response, 'danger')
    }
    if (resultado.status === 200) {
      setPremios(resultado.response)
    }
  }

  const fetchCentroVentas = async () => {
    let resultado = []
    if (perfil === '1') {
      resultado = await GetCentroVentas()
    } else {
      resultado = await GetCentroVentaPorCompania()
    }
    if (resultado.status === 400 || resultado.status === 500) {
      toastRef.current.showToast(resultado.response, 'danger')
    }
    if (resultado.status === 200) {
      setCentroVentas(resultado.response)
    }
  }

  useEffect(() => {
    fetchPremios()
    fetchCentroVentas()
  }, [])

  return (
    <>
      <Toast ref={toastRef}></Toast>
      <h1>Premios</h1>
      <CRow>
        <CTable align="middle" bordered small hover>
          <CTableHead align="middle">
            <CTableRow>
              <CTableHeaderCell scope="col">Descripción</CTableHeaderCell>
              <CTableHeaderCell scope="col">Puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col">Precio</CTableHeaderCell>
              <CTableHeaderCell scope="col">Fecha de Inicio</CTableHeaderCell>
              <CTableHeaderCell scope="col">Fecha de Fin</CTableHeaderCell>
              <CTableHeaderCell scope="col">
                <AddPremioModal
                  GetPremios={fetchPremios}
                  CentroVentas={CentroVentas}
                  toast={toastRef}
                />
              </CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody align="middle">
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
                    toast={toastRef}
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
