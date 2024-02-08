import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import GetCompanias from '../../services/companias/GetCompanias'
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
  CForm,
  CFormInput,
  CModal,
  CModalBody,
  CModalFooter,
  CModalHeader,
  CModalTitle,
  CFormSelect,
} from '@coreui/react'
import AddCompania from 'src/services/companias/AddCompania'
import UpdateCompania from 'src/services/companias/UpdateCompania'
import DeleteCompania from 'src/services/companias/DeleteCompania'
import Toast from '../notifications/toasts/Toasts'

const AddCompaniaModal = (props) => {
  const [validated, setValidated] = useState(false)
  const [addCompaniaVisible, setAddCompaniaVisible] = useState(false)
  const [newNombre, setNewNombre] = useState()
  const [newVigenciaPuntos, setNewVigenciaPuntosChange] = useState()
  const [newTipoVencimiento, setNewTipoVencimiento] = useState()
  let tipoVencimiento = []
  tipoVencimiento.push({ value: 1, name: 'Tiempo' })
  tipoVencimiento.push({ value: 2, name: 'Conexion' })
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handleVigenciaPuntosChange = (event) => {
    setNewVigenciaPuntosChange(event.target.value)
  }
  const handleTipoVencimientoChange = (event) => {
    setNewTipoVencimiento(event.target.value)
  }

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let resultado = await AddCompania(newNombre, newVigenciaPuntos, newTipoVencimiento)
      props.GetCompanias()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Compa&ntilde;ia agregada con exito', 'success')
        setAddCompaniaVisible(false)
      }
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setAddCompaniaVisible(true)}>
        <CIcon icon={cilPlus} size="sm" />
      </CButton>
      <CModal
        visible={addCompaniaVisible}
        alignment="center"
        onClose={() => setAddCompaniaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Agregar Compa&ntilde;ia</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
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
              <CCol xs={3}>Vigencia de puntos*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="VigenciaPuntos"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleVigenciaPuntosChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tipo de Vencimiento*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Tipo de vencimiento"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTipoVencimientoChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {tipoVencimiento.map((tipo) => (
                    <option key={tipo.value} value={tipo.value}>
                      {tipo.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setAddCompaniaVisible(false)}>
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

const TaskCompania = (props) => {
  const [validated, setValidated] = useState(false)
  const [updateCompaniaVisible, setUpdateCompaniaVisible] = useState(false)
  const [deleteCompaniaVisible, setDeleteCompaniaVisible] = useState(false)
  const [newNit, setNewNit] = useState(props.Compania.nit)
  const [newNombre, setNewNombre] = useState(props.Compania.nombre)
  const [newVigenciaPuntos, setNewVigenciaPuntosChange] = useState(props.Compania.vigenciaPuntos)
  const [newTipoVencimiento, setNewTipoVencimiento] = useState(props.Compania.tipoVencimientoId)
  let tipoVencimiento = []
  tipoVencimiento.push({ value: 1, name: 'Tiempo' })
  tipoVencimiento.push({ value: 2, name: 'Conexion' })
  const handleNitChange = (event) => {
    setNewNit(event.target.value)
  }
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handleVigenciaPuntosChange = (event) => {
    setNewVigenciaPuntosChange(event.target.value)
  }
  const handleTipoVencimientoChange = (event) => {
    setNewTipoVencimiento(event.target.value)
  }

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let compania = props.Compania
      compania.nombre = newNombre
      compania.vigenciaPuntos = newVigenciaPuntos
      compania.tipoVencimientoId = newTipoVencimiento
      let resultado = await UpdateCompania(props.Compania)
      props.GetCompanias()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Compa&ntilde;ia actualizada con exito', 'success')
        setUpdateCompaniaVisible(false)
      }
    }
  }

  const deleteCompania = async () => {
    let resultado = await DeleteCompania(props.Compania)
    if (resultado.status === 400 || resultado.status === 500) {
      props.toast.current.showToast(resultado.response, 'danger')
    }
    props.GetCompanias()
    setDeleteCompaniaVisible(false)
    if (resultado.status === 200) {
      props.toast.current.showToast('Compa&ntilde;ia eliminada con exito', 'success')
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setUpdateCompaniaVisible(true)}>
        <CIcon icon={cilPencil} size="sm" />
      </CButton>
      <CModal
        visible={updateCompaniaVisible}
        alignment="center"
        onClose={() => setUpdateCompaniaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Actualizar Compa&ntilde;ia</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
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
              <CCol xs={3}>Vigencia de puntos*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  value={newVigenciaPuntos}
                  placeholder="VigenciaPuntos"
                  type="number"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleVigenciaPuntosChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tipo de Vencimiento*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  value={newTipoVencimiento}
                  aria-label="Tipo de vencimiento"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTipoVencimientoChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {tipoVencimiento.map((tipo) => (
                    <option key={tipo.value} value={tipo.value}>
                      {tipo.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setUpdateCompaniaVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Actualizar
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
      </CModal>
      <CButton style={{ margin: '2pt' }} onClick={() => setDeleteCompaniaVisible(true)}>
        <CIcon icon={cilX} size="sm" />
      </CButton>
      <CModal
        visible={deleteCompaniaVisible}
        alignment="center"
        onClose={() => setDeleteCompaniaVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Eliminar Compa&ntilde;ia</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow>
            <label>Esta seguro?</label>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setDeleteCompaniaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={deleteCompania}>
            Eliminar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const Companias = () => {
  let navigate = useNavigate()
  const perfil = localStorage.getItem('perfil')
  const [Companias, setCompanias] = useState([])
  const toastRef = useRef()

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
      setCompanias(resultado.response)
    }
  }

  useEffect(() => {
    fetchCompanias()
  }, [])

  return (
    <>
      <Toast ref={toastRef}></Toast>
      <h1>Compa&ntilde;ias</h1>
      <AddCompaniaModal GetCompanias={fetchCompanias} toast={toastRef} />
      <CRow>
        <CTable align="middle" bordered small hover>
          <CTableHead align="middle">
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Vigencia de puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody align="middle">
            {Companias.map((Compania) => (
              <CTableRow key={Compania.id}>
                <CTableHeaderCell>{Compania.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{Compania.vigenciaPuntos} meses</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskCompania
                    GetCompanias={fetchCompanias}
                    Compania={Compania}
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

export default Companias
