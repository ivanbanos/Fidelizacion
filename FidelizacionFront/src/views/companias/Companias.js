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

const AddCompaniaModal = (props) => {
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
  const addCompania = async () => {
    await AddCompania(newNombre, newVigenciaPuntos, newTipoVencimiento)
    props.GetCompanias()
    setAddCompaniaVisible(false)
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
          <CRow className="mb-2">
            <CCol xs={3}>Nombre:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Nombre" onChange={handleNombreChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Vigencia de puntos:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="VigenciaPuntos" onChange={handleVigenciaPuntosChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tipo de Vencimiento:</CCol>
            <CCol xs={9}>
              <CFormSelect
                aria-label="Default select example"
                onChange={handleTipoVencimientoChange}
              >
                <option>Selecione un opcion</option>
                {tipoVencimiento.map((tipo) => (
                  <option key={tipo.value} value={tipo.value}>
                    {tipo.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setAddCompaniaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={addCompania}>
            Agregar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const TaskCompania = (props) => {
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

  const updateCompania = async () => {
    let compania = props.Compania
    compania.nit = newNit
    compania.nombre = newNombre
    compania.vigenciaPuntos = newVigenciaPuntos
    compania.idTipoVencimiento = newTipoVencimiento
    await UpdateCompania(props.Compania)
    props.GetCompanias()
    setUpdateCompaniaVisible(false)
  }
  const deleteCompania = async () => {
    await DeleteCompania(props.Compania)
    props.GetCompanias()
    setDeleteCompaniaVisible(false)
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
            <CCol xs={3}>Vigencia de puntos:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newVigenciaPuntos}
                placeholder="VigenciaPuntos"
                onChange={handleVigenciaPuntosChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tipo de Vencimiento:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newTipoVencimiento}
                aria-label="Default select example"
                onChange={handleTipoVencimientoChange}
              >
                {tipoVencimiento.map((tipo) => (
                  <option key={tipo.value} value={tipo.value}>
                    {tipo.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setUpdateCompaniaVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={updateCompania}>
            Actualizar
          </CButton>
        </CModalFooter>
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
  const [Companias, setCompanias] = useState([])
  const toastRef = useRef()

  const fetchCompanias = async () => {
    let Companias = await GetCompanias()
    setCompanias(Companias)
  }

  useEffect(() => {
    fetchCompanias()
  }, [])

  return (
    <>
      <h1>Compa&ntilde;ias</h1>
      <AddCompaniaModal GetCompanias={fetchCompanias} />
      <CRow>
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Vigencia de puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
            {Companias.map((Compania) => (
              <CTableRow key={Compania.id}>
                <CTableHeaderCell>{Compania.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{Compania.vigenciaPuntos} meses</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskCompania GetCompanias={fetchCompanias} Compania={Compania} />
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
