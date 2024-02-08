import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import GetCentroVentas from '../../services/centroVentas/GetCentroVentas'
import GetCentroVentaPorCompania from '../../services/centroVentas/GetCentroVentaPorCompania'
import CIcon from '@coreui/icons-react'
import { cilPlus, cilPencil, cilX } from '@coreui/icons'
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
  CForm,
  CFormSelect,
} from '@coreui/react'
import AddCentroVenta from 'src/services/centroVentas/AddCentroVenta'
import UpdateCentroVenta from 'src/services/centroVentas/UpdateCentroVenta'
import DeleteCentroVenta from 'src/services/centroVentas/DeleteCentroVenta'
import GetCiudades from 'src/services/configuraciones/GetCiudades'
import GetCompanias from '../../services/companias/GetCompanias'
import Toast from '../notifications/toasts/Toasts'

const AddCentroVentaModal = (props) => {
  const idCompania = localStorage.getItem('idCompania')
  const [validated, setValidated] = useState(false)
  const [addCentroVentaVisible, setAddCentroVentaVisible] = useState(false)
  const [inputCompaniaVisible, setCompaniaVisible] = useState(props.Perfil === '1')
  const [newNit, setNewNit] = useState()
  const [newNombre, setNewNombre] = useState()
  const [newDireccion, setNewDireccionChange] = useState()
  const [newTelefono, setNewTelefonoChange] = useState()
  const [newValorPorPunto, setNewValorPorPuntoChange] = useState()
  const [newCiudad, setNewCiudad] = useState()
  const [newCompania, setNewCompania] = useState(idCompania)

  const handleNitChange = (event) => {
    setNewNit(event.target.value)
  }
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handleDireccionChange = (event) => {
    setNewDireccionChange(event.target.value)
  }
  const handleTelefonoChange = (event) => {
    setNewTelefonoChange(event.target.value)
  }
  const handleValorPorPuntoChange = (event) => {
    setNewValorPorPuntoChange(event.target.value)
  }
  const handleCiudadChange = (event) => {
    setNewCiudad(event.target.value)
  }
  const handleCompaniaChange = (event) => {
    setNewCompania(event.target.value)
  }
  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
      setValidated(true)
    }
    if (form.checkValidity() === true) {
      let resultado = await AddCentroVenta(
        newNit,
        newNombre,
        newDireccion,
        newTelefono,
        newValorPorPunto,
        newCiudad,
        newCompania === '0' ? null : newCompania,
      )
      props.GetCentroVentas()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Centro de venta agregado con exito', 'success')
        setAddCentroVentaVisible(false)
      }
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setAddCentroVentaVisible(true)}>
        <CIcon icon={cilPlus} size="sm" />
      </CButton>
      <CModal
        visible={addCentroVentaVisible}
        alignment="center"
        onClose={() => setAddCentroVentaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Agregar Centro de Venta</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 mt-1 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Nit*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nit"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNitChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Nombre*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nombre"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNombreChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Direcci&oacute;n*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Direcci&oacute;n"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDireccionChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tel&eacute;fono*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Tel&eacute;fono"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTelefonoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Valor por punto*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Varlor por punto"
                  feedbackInvalid="Este campo es requerido"
                  type="number"
                  onChange={handleValorPorPuntoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Ciudad*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Ciudad"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleCiudadChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {props.ciudades.map((ciudad) => (
                    <option key={ciudad.id} value={ciudad.id}>
                      {ciudad.nombre}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            {inputCompaniaVisible && (
              <CRow className="mb-2">
                <CCol xs={3}>Compa&ntilde;ia*:</CCol>
                <CCol xs={9}>
                  <CFormSelect
                    aria-label="Compa&ntilde;ia"
                    feedbackInvalid="Este campo es requerido"
                    onChange={handleCompaniaChange}
                    required
                  >
                    <option selected="" value="">
                      Selecione un opcion
                    </option>
                    {props.Companias.map((compania) => (
                      <option key={compania.id} value={compania.id}>
                        {compania.nombre}
                      </option>
                    ))}
                  </CFormSelect>
                </CCol>
              </CRow>
            )}
            <CModalFooter>
              <CButton color="secondary" onClick={() => setAddCentroVentaVisible(false)}>
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

const TaskCentroVenta = (props) => {
  const [updateCentroVentaVisible, setUpdateCentroVentaVisible] = useState(false)
  const [deleteCentroVentaVisible, setDeleteCentroVentaVisible] = useState(false)
  const [validated, setValidated] = useState(false)
  const [newNit, setNewNit] = useState(props.CentroVenta.nit)
  const [newNombre, setNewNombre] = useState(props.CentroVenta.nombre)
  const [newDireccion, setNewDireccionChange] = useState(props.CentroVenta.direccion)
  const [newTelefono, setNewTelefonoChange] = useState(props.CentroVenta.telefono)
  const [newValorPorPunto, setNewValorPorPuntoChange] = useState(props.CentroVenta.valorPorPunto)
  const handleNitChange = (event) => {
    setNewNit(event.target.value)
  }
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handleDireccionChange = (event) => {
    setNewDireccionChange(event.target.value)
  }
  const handleTelefonoChange = (event) => {
    setNewTelefonoChange(event.target.value)
  }
  const handleValorPorPuntoChange = (event) => {
    setNewValorPorPuntoChange(event.target.value)
  }

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let centroVenta = props.CentroVenta
      centroVenta.nit = newNit
      centroVenta.nombre = newNombre
      centroVenta.direccion = newDireccion
      centroVenta.telefono = newTelefono
      centroVenta.valorPorPunto = newValorPorPunto
      let resultado = await UpdateCentroVenta(props.CentroVenta)
      props.GetCentroVentas()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Centro de venta actualizado con exito', 'success')
        setUpdateCentroVentaVisible(false)
      }
    }
  }

  const deleteCentroVenta = async () => {
    let resultado = await DeleteCentroVenta(props.CentroVenta)
    if (resultado.status === 400 || resultado.status === 500) {
      props.toast.current.showToast(resultado.response, 'danger')
    }
    props.GetCentroVentas()
    setDeleteCentroVentaVisible(false)
    if (resultado.status === 200) {
      props.toast.current.showToast('Centro de venta eliminado con exito', 'success')
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setUpdateCentroVentaVisible(true)}>
        <CIcon icon={cilPencil} size="sm" />
      </CButton>
      <CModal
        visible={updateCentroVentaVisible}
        alignment="center"
        onClose={() => setUpdateCentroVentaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Actualizar Centro de Venta</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 mt-1 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Nit*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nit"
                  value={newNit}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNitChange}
                  readOnly
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Nombre*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nombre"
                  value={newNombre}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNombreChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Direcci&oacute;n*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Direcci&oacute;n"
                  value={newDireccion}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDireccionChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tel&eacute;fono:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Tel&eacute;fono*"
                  value={newTelefono}
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTelefonoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Valor por punto*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Varlor por punto"
                  value={newValorPorPunto}
                  feedbackInvalid="Este campo es requerido"
                  type="number"
                  onChange={handleValorPorPuntoChange}
                  required
                />
              </CCol>
            </CRow>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setUpdateCentroVentaVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Actualizar
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
      </CModal>
      <CButton style={{ margin: '2pt' }} onClick={() => setDeleteCentroVentaVisible(true)}>
        <CIcon icon={cilX} size="sm" />
      </CButton>
      <CModal
        visible={deleteCentroVentaVisible}
        alignment="center"
        onClose={() => setDeleteCentroVentaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Eliminar Centro de Venta</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow>
            <label>Esta seguro?</label>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setDeleteCentroVentaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={deleteCentroVenta}>
            Eliminar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const CentroVentas = () => {
  let navigate = useNavigate()
  const perfil = localStorage.getItem('perfil') !== null ? localStorage.getItem('perfil') : 'null'
  const [CentroVentas, setCentroVentas] = useState([])
  const [Companias, setCompania] = useState([])
  const [ciudades, setCiudades] = useState([])
  const toastRef = useRef()

  const fetchCentroVentas = async () => {
    if (perfil !== '1' && perfil !== '2') {
      navigate('/dashboard', { replace: true })
    }
    let resultado = []
    if (perfil === '1') {
      resultado = await GetCentroVentas()
    } else {
      resultado = await GetCentroVentaPorCompania()
    }
    if (resultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (resultado.status === 400 || resultado.status === 500) {
      toastRef.current.showToast(resultado.response, 'danger')
    }
    if (resultado.status === 200) {
      setCentroVentas(resultado.response)
    }
  }

  const fetchCiudades = async () => {
    let ciudadesResultado = await GetCiudades()
    if (ciudadesResultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (ciudadesResultado.status === 400 || ciudadesResultado.status === 500) {
      toastRef.current.showToast(ciudadesResultado.response, 'danger')
    }
    if (ciudadesResultado.status === 200) {
      setCiudades(ciudadesResultado.response)
    }
  }

  const fetchCompanias = async () => {
    if (perfil !== '1') {
      navigate('/dashboard', { replace: true })
    }
    let resultado = await GetCompanias()
    if (resultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (resultado.status === 400 || resultado.status === 500) {
      toastRef.current.showToast(resultado.response, 'danger')
    }
    if (resultado.status === 200) {
      setCompania(resultado.response)
    }
  }

  useEffect(() => {
    fetchCentroVentas()
    fetchCiudades()
    fetchCompanias()
  }, [])

  return (
    <>
      <Toast ref={toastRef}></Toast>
      <h1>Centro de Ventas</h1>
      <CRow>
        <CTable align="middle" bordered small hover>
          <CTableHead align="middle">
            <CTableRow>
              <CTableHeaderCell scope="col">Nit</CTableHeaderCell>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Valor Por Punto</CTableHeaderCell>
              <CTableHeaderCell scope="col">Tel&eacute;fono</CTableHeaderCell>
              <CTableHeaderCell scope="col">
                <AddCentroVentaModal
                  GetCentroVentas={fetchCentroVentas}
                  ciudades={ciudades}
                  Companias={Companias}
                  Perfil={perfil}
                  toast={toastRef}
                />
              </CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody align="middle">
            {CentroVentas.map((CentroVenta) => (
              <CTableRow key={CentroVenta.id}>
                <CTableHeaderCell>{CentroVenta.nit}</CTableHeaderCell>
                <CTableHeaderCell>{CentroVenta.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{CentroVenta.valorPorPunto}</CTableHeaderCell>
                <CTableHeaderCell>{CentroVenta.telefono}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskCentroVenta
                    GetCentroVentas={fetchCentroVentas}
                    ciudades={ciudades}
                    CentroVenta={CentroVenta}
                    Companias={Companias}
                    Perfil={perfil}
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

export default CentroVentas
