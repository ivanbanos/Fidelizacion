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

const AddUsuarioModal = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
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
  const addUsuario = async () => {
    await AddUsuario(newNombreUsuario, newPerfil, newCentroVenta === '0' ? null : newCentroVenta)
    props.GetUsuarios()
    setNewPerfilChange(perfil)
    setNewCentroVentaChange(centroVenta)
    setAddUsuarioVisible(false)
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
          <CRow className="mb-2">
            <CCol xs={3}>Nombre de Usuario*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Nombre de usuario" onChange={handleNombreUsuarioChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Perfil*:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handlePerfilChange}>
                <option>Selecione un opcion</option>
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
          <CButton color="secondary" onClick={() => setAddUsuarioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={addUsuario}>
            Agregar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const TaskUsuario = (props) => {
  const perfil = localStorage.getItem('perfil')
  const centroVenta = localStorage.getItem('idCentroVenta')
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

  const updateUsuario = async () => {
    let usuario = props.Usuario
    usuario.nombreUsuario = newNombreUsuario
    usuario.perfilId = newPerfil
    usuario.centroVentaId = newCentroVenta === '0' ? null : newCentroVenta
    usuario.centroVenta = null
    await UpdateUsuario(props.Usuario)
    props.GetUsuarios()
    setNewPerfilChange(perfil)
    setNewCentroVentaChange(centroVenta)
    setUpdateUsuarioVisible(false)
  }
  const deleteUsuario = async () => {
    await DeleteUsuario(props.Usuario)
    props.GetUsuarios()
    setDeleteUsuarioVisible(false)
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
          <CRow className="mb-2">
            <CCol xs={3}>Nombre de Usuario*:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newNombreUsuario}
                placeholder="Nombre de usuario"
                onChange={handleNombreUsuarioChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Perfil*:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newPerfil}
                aria-label="Default select example"
                onChange={handlePerfilChange}
              >
                <option>Selecione un opcion</option>
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
          <CButton color="secondary" onClick={() => setUpdateUsuarioVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={updateUsuario}>
            Actualizar
          </CButton>
        </CModalFooter>
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
    let usuarios = []
    if (perfil === '1') {
      usuarios = await GetUsuarios()
    } else if (perfil === '2') {
      usuarios = await GetUsuariosPorCompania()
    } else {
      usuarios = await GetUsuariosPorCentroVenta()
    }
    if (usuarios === 'fail') {
      navigate('/Login', { replace: true })
    }

    if (perfil !== '1' && perfil !== '2' && perfil !== '3') {
      navigate('/dashboard', { replace: true })
    }

    setUsuarios(usuarios)
  }

  const fetchPerfiles = async () => {
    let perfiles = await GetPerfiles()
    if (perfiles === 'fail') {
      navigate('/Login', { replace: true })
    }

    perfiles = perfiles.filter((x) => x.id >= perfil)
    setPerfiles(perfiles)
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
    fetchUsuarios()
    fetchPerfiles()
    fetchCentroVentas()
  }, [])

  return (
    <>
      <h1>Usuarios</h1>
      <AddUsuarioModal
        GetUsuarios={fetchUsuarios}
        Perfiles={Perfiles}
        CentroVentas={CentroVentas}
      />
      <CRow>
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre de Usuario</CTableHeaderCell>
              <CTableHeaderCell scope="col">Perfil</CTableHeaderCell>
              <CTableHeaderCell scope="col">Centro de Venta</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
            {Usuarios.map((usuario) => (
              <CTableRow key={usuario.Guid}>
                <CTableHeaderCell>{usuario.nombreUsuario}</CTableHeaderCell>
                <CTableHeaderCell>{usuario.perfilId}</CTableHeaderCell>
                <CTableHeaderCell>{usuario.centroVenta?.nombre}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskUsuario
                    GetUsuarios={fetchUsuarios}
                    Usuario={usuario}
                    Perfiles={Perfiles}
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

export default Usuarios
