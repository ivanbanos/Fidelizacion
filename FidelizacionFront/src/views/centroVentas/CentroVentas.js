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
  CFormSelect,
} from '@coreui/react'
import AddCentroVenta from 'src/services/centroVentas/AddCentroVenta'
import UpdateCentroVenta from 'src/services/centroVentas/UpdateCentroVenta'
import DeleteCentroVenta from 'src/services/centroVentas/DeleteCentroVenta'
import GetCiudades from 'src/services/configuraciones/GetCiudades'
import GetCompanias from '../../services/companias/GetCompanias'

const AddCentroVentaModal = (props) => {
  const idCompania = localStorage.getItem('idCompania')
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
  const addCentroVenta = async () => {
    await AddCentroVenta(
      newNit,
      newNombre,
      newDireccion,
      newTelefono,
      newValorPorPunto,
      newCiudad,
      newCompania === '0' ? null : newCompania,
    )
    props.GetCentroVentas()
    setAddCentroVentaVisible(false)
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
          <CRow className="mb-2">
            <CCol xs={3}>Nit*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Nit" onChange={handleNitChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Nombre*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Nombre" onChange={handleNombreChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Direcci&oacute;n*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Direcci&oacute;n" onChange={handleDireccionChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tel&eacute;fono*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Tel&eacute;fono" onChange={handleTelefonoChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Valor por punto*:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Varlor por punto" onChange={handleValorPorPuntoChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Ciudad*:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handleCiudadChange}>
                <option>Selecione un opcion</option>
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
                <CFormSelect aria-label="Default select example" onChange={handleCompaniaChange}>
                  <option>Selecione un opcion</option>
                  {props.Companias.map((compania) => (
                    <option key={compania.id} value={compania.id}>
                      {compania.nombre}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
          )}
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setAddCentroVentaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={addCentroVenta}>
            Agregar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const TaskCentroVenta = (props) => {
  const [updateCentroVentaVisible, setUpdateCentroVentaVisible] = useState(false)
  const [deleteCentroVentaVisible, setDeleteCentroVentaVisible] = useState(false)
  const [newNit, setNewNit] = useState(props.CentroVenta.nit)
  const [newNombre, setNewNombre] = useState(props.CentroVenta.nombre)
  const [newDireccion, setNewDireccionChange] = useState(props.CentroVenta.direccion)
  const [newTelefono, setNewTelefonoChange] = useState(props.CentroVenta.telefono)
  const [newValorPorPunto, setNewValorPorPuntoChange] = useState(props.CentroVenta.valorPorPunto)
  const [newCiudad, setNewCiudad] = useState(props.CentroVenta.ciudadId)
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

  const updateCentroVenta = async () => {
    let centroVenta = props.CentroVenta
    centroVenta.nit = newNit
    centroVenta.nombre = newNombre
    centroVenta.direccion = newDireccion
    centroVenta.telefono = newTelefono
    centroVenta.valorPorPunto = newValorPorPunto
    centroVenta.ciudadId = newCiudad
    await UpdateCentroVenta(props.CentroVenta)
    props.GetCentroVentas()
    setUpdateCentroVentaVisible(false)
  }
  const deleteCentroVenta = async () => {
    await DeleteCentroVenta(props.CentroVenta)
    props.GetCentroVentas()
    setDeleteCentroVentaVisible(false)
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
          <CRow className="mb-2">
            <CCol xs={3}>Nit:</CCol>
            <CCol xs={9}>
              <CFormInput value={newNit} placeholder="Nit" onChange={handleNitChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Nombre:</CCol>
            <CCol xs={9}>
              <CFormInput value={newNombre} placeholder="Nombre" onChange={handleNombreChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Direcci&oacute;n:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newDireccion}
                placeholder="Direccion"
                onChange={handleDireccionChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tel&eacute;fono:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newTelefono}
                placeholder="Tel&eacute;fono"
                onChange={handleTelefonoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Valor por punto:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newValorPorPunto}
                placeholder="Valor por punto"
                onChange={handleValorPorPuntoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Ciudad:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newCiudad}
                aria-label="Default select example"
                onChange={handleCiudadChange}
              >
                {props.ciudades.map((ciudad) => (
                  <option key={ciudad.id} value={ciudad.id}>
                    {ciudad.nombre}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setUpdateCentroVentaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={updateCentroVenta}>
            Actualizar
          </CButton>
        </CModalFooter>
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
  const perfil = localStorage.getItem('perfil')
  const [CentroVentas, setCentroVentas] = useState([])
  const [Companias, setCompania] = useState([])
  const [ciudades, setCiudades] = useState([])
  const toastRef = useRef()

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

    if (perfil !== '1' && perfil !== '2') {
      navigate('/dashboard', { replace: true })
    }

    setCentroVentas(CentroVentas)
  }

  const fetchCiudades = async () => {
    let ciudades = await GetCiudades()
    setCiudades(ciudades)
  }

  const fetchCompanias = async () => {
    let Companias = await GetCompanias()
    if (Companias === 'fail') {
      navigate('/Login', { replace: true })
    }

    setCompania(Companias)
  }

  useEffect(() => {
    fetchCentroVentas()
    fetchCiudades()
    fetchCompanias()
  }, [])

  return (
    <>
      <h1>Centro de Ventas</h1>
      <AddCentroVentaModal
        GetCentroVentas={fetchCentroVentas}
        ciudades={ciudades}
        Companias={Companias}
        Perfil={perfil}
      />
      <CRow>
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Nit</CTableHeaderCell>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Valor Por Punto</CTableHeaderCell>
              <CTableHeaderCell scope="col">Tel&eacute;fono</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
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
