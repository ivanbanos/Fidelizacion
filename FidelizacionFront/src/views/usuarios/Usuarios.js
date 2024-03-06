import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
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
import AddUsuario from 'src/services/usuarios/AddUsuario'
import GetUsuarios from '../../services/usuarios/GetUsuarios'
import GetUsuariosPorCentroVenta from '../../services/usuarios/GetUsuariosPorCentroVenta'
import GetUsuariosPorCompania from '../../services/usuarios/GetUsuariosPorCompania'
import UpdateUsuario from 'src/services/usuarios/UpdateUsuario'
import DeleteUsuario from 'src/services/usuarios/DeleteUsuario'
import GetPerfiles from 'src/services/configuraciones/GetPerfiles'
import GetCentroVentas from '../../services/centroVentas/GetCentroVentas'
import GetCentroVentaPorCompania from '../../services/centroVentas/GetCentroVentaPorCompania'
import Toast from '../notifications/toasts/Toasts'

const AddUsuarioModal = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [validated, setValidated] = useState(false)
  const [addUsuarioVisible, setAddUsuarioVisible] = useState(false)
  const [centroVentaDisabled, setCentroVentaDisabled] = useState(true)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(
    perfil === '1' || perfil === '2',
  )
  const [newNombreUsuario, setNewNombreUsuario] = useState()
  const [newPerfil, setNewPerfilChange] = useState()
  const [newCentroVenta, setNewCentroVentaChange] = useState(centroVenta)

  const handleNombreUsuarioChange = (event) => {
    setNewNombreUsuario(event.target.value)
  }
  const handlePerfilChange = (event) => {
    setNewPerfilChange(event.target.value)
    if (event.target.value === '1') {
      setCentroVentaDisabled(true)
    } else {
      setCentroVentaDisabled(false)
    }
  }
  const handleCentroVentaChange = (event) => {
    setNewCentroVentaChange(event.target.value)
  }
  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let resultado = await AddUsuario(
        newNombreUsuario,
        newPerfil,
        newCentroVenta === '0' ? null : newCentroVenta,
      )
      props.GetUsuarios()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        setNewPerfilChange(perfil)
        setNewCentroVentaChange(centroVenta)
        props.toast.current.showToast('Usuario agregado con exito', 'success')
        setAddUsuarioVisible(false)
      }
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setAddUsuarioVisible(true)}>
        <CIcon icon={cilPlus} size="sm" />
      </CButton>
      <CModal
        visible={addUsuarioVisible}
        alignment="center"
        onClose={() => setAddUsuarioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Agregar Usuarios</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Nombre de Usuario*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nombre de usuario"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNombreUsuarioChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Perfil*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Perfil"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePerfilChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {props.Perfiles.map((perfil) => (
                    <option key={perfil.id} value={perfil.id}>
                      {perfil.nombre}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            {inputCentroVentaVisible && (
              <CRow className="mb-2">
                <CCol xs={3}>Centro de Venta*:</CCol>
                <CCol xs={9}>
                  <CFormSelect
                    aria-label="Default select example"
                    feedbackInvalid="Este campo es requerido"
                    onChange={handleCentroVentaChange}
                    disabled={centroVentaDisabled}
                    required
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
            <CModalFooter>
              <CButton color="secondary" onClick={() => setAddUsuarioVisible(false)}>
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

const TaskUsuario = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [validated, setValidated] = useState(false)
  const [updateUsuarioVisible, setUpdateUsuarioVisible] = useState(false)
  const [deleteUsuarioVisible, setDeleteUsuarioVisible] = useState(false)
  const [centroVentaDisabled, setCentroVentaDisabled] = useState(props.Usuario.perfilId === 1)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(
    perfil === '1' || perfil === '2',
  )
  const [newNombreUsuario, setNewNombreUsuario] = useState(props.Usuario.nombreUsuario)
  const [newPerfil, setNewPerfilChange] = useState(props.Usuario.perfilId)
  const [newCentroVenta, setNewCentroVentaChange] = useState(props.Usuario.centroVentaId)
  const handleNombreUsuarioChange = (event) => {
    setNewNombreUsuario(event.target.value)
  }
  const handlePerfilChange = (event) => {
    setNewPerfilChange(event.target.value)
    if (event.target.value === '1') {
      setCentroVentaDisabled(true)
    } else {
      setCentroVentaDisabled(false)
    }
  }
  const handleCentroVentaChange = (event) => {
    setNewCentroVentaChange(event.target.value)
  }

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let usuario = props.Usuario
      usuario.nombreUsuario = newNombreUsuario
      usuario.perfilId = newPerfil
      usuario.centroVentaId = newCentroVenta === '0' ? null : newCentroVenta
      let resultado = await UpdateUsuario(props.Usuario)
      props.GetUsuarios()
      setValidated(false)
      if (resultado.status === 400 || resultado.status === 500) {
        props.toast.current.showToast(resultado.response, 'danger')
      }
      if (resultado.status === 200) {
        props.toast.current.showToast('Usuario actualizado con exito', 'success')
        setUpdateUsuarioVisible(false)
      }
    }
  }

  const deleteUsuario = async () => {
    let resultado = await DeleteUsuario(props.Usuario)
    if (resultado.status === 400 || resultado.status === 500) {
      props.toast.current.showToast(resultado.response, 'danger')
    }
    props.GetUsuarios()
    setDeleteUsuarioVisible(false)
    if (resultado.status === 200) {
      props.toast.current.showToast('Usuario eliminado con exito', 'success')
    }
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setUpdateUsuarioVisible(true)}>
        <CIcon icon={cilPencil} size="sm" />
      </CButton>
      <CModal
        visible={updateUsuarioVisible}
        alignment="center"
        onClose={() => setUpdateUsuarioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Actualizar Usuario</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Nombre de Usuario*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Nombre de usuario"
                  value={newNombreUsuario}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleNombreUsuarioChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Perfil*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Perfil"
                  value={newPerfil}
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePerfilChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {props.Perfiles.map((perfil) => (
                    <option key={perfil.id} value={perfil.id}>
                      {perfil.nombre}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            {inputCentroVentaVisible && (
              <CRow className="mb-2">
                <CCol xs={3}>Centro de Venta*:</CCol>
                <CCol xs={9}>
                  <CFormSelect
                    aria-label="Default select example"
                    value={newCentroVenta}
                    feedbackInvalid="Este campo es requerido"
                    onChange={handleCentroVentaChange}
                    disabled={centroVentaDisabled}
                    required
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
            <CModalFooter>
              <CButton color="secondary" onClick={() => setUpdateUsuarioVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Actualizar
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
      </CModal>
      <CButton style={{ margin: '2pt' }} onClick={() => setDeleteUsuarioVisible(true)}>
        <CIcon icon={cilX} size="sm" />
      </CButton>
      <CModal
        visible={deleteUsuarioVisible}
        alignment="center"
        onClose={() => setDeleteUsuarioVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Eliminar Usuario</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow>
            <label>Esta seguro?</label>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setDeleteUsuarioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={deleteUsuario}>
            Eliminar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const Usuarios = () => {
  let navigate = useNavigate()
  const perfil = localStorage.getItem('perfil')
  const [Usuarios, setUsuarios] = useState([])
  const [Perfiles, setPerfiles] = useState([])
  const [CentroVentas, setCentroVentas] = useState([])
  const toastRef = useRef()

  const fetchUsuarios = async () => {
    if (perfil !== '1' && perfil !== '2' && perfil !== '3') {
      navigate('/dashboard', { replace: true })
    }
    let resultado = []
    if (perfil === '1') {
      resultado = await GetUsuarios()
    } else if (perfil === '2') {
      resultado = await GetUsuariosPorCompania()
    } else {
      resultado = await GetUsuariosPorCentroVenta()
    }
    if (resultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (resultado.status === 400 || resultado.status === 500) {
      toastRef.current.showToast(resultado.response, 'danger')
    }
    if (resultado.status === 200) {
      setUsuarios(resultado.response)
    }
  }

  const fetchPerfiles = async () => {
    let perfilesResultado = await GetPerfiles()
    if (perfilesResultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (perfilesResultado.status === 400 || perfilesResultado.status === 500) {
      toastRef.current.showToast(perfilesResultado.response, 'danger')
    }
    if (perfilesResultado.status === 200) {
      perfilesResultado.response = perfilesResultado.response.filter((x) => x.id >= perfil)
      setPerfiles(perfilesResultado.response)
    }
  }

  const fetchCentroVentas = async () => {
    let centroVentasResultado = []
    if (perfil === '1') {
      centroVentasResultado = await GetCentroVentas()
    } else {
      centroVentasResultado = await GetCentroVentaPorCompania()
    }
    if (centroVentasResultado.status === 401) {
      navigate('/Login', { replace: true })
    }
    if (centroVentasResultado.status === 400 || centroVentasResultado.status === 500) {
      toastRef.current.showToast(centroVentasResultado.response, 'danger')
    }
    if (centroVentasResultado.status === 200) {
      setCentroVentas(centroVentasResultado.response)
    }
  }

  useEffect(() => {
    fetchUsuarios()
    fetchPerfiles()
    fetchCentroVentas()
  }, [])

  return (
    <>
      <Toast ref={toastRef}></Toast>
      <h1>Usuarios</h1>
      <CRow>
        <CTable align="middle" bordered small hover>
          <CTableHead align="middle">
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre de Usuario</CTableHeaderCell>
              <CTableHeaderCell scope="col">Perfil</CTableHeaderCell>
              <CTableHeaderCell scope="col">Centro de Venta</CTableHeaderCell>
              <CTableHeaderCell scope="col">
                <AddUsuarioModal
                  GetUsuarios={fetchUsuarios}
                  Perfiles={Perfiles}
                  CentroVentas={CentroVentas}
                  toast={toastRef}
                />
              </CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody align="middle">
            {Usuarios.map((usuario) => (
              <CTableRow key={usuario.Guid}>
                <CTableHeaderCell>{usuario.nombreUsuario}</CTableHeaderCell>
                <CTableHeaderCell>{usuario.perfil}</CTableHeaderCell>
                <CTableHeaderCell>{usuario.nombreCentroVenta}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskUsuario
                    GetUsuarios={fetchUsuarios}
                    Usuario={usuario}
                    Perfiles={Perfiles}
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

export default Usuarios
