import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import GetFidelizados from '../../services/fidelizados/GetFidelizados'
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
import AddFidelizado from 'src/services/fidelizados/AddFidelizado'
import UpdateFidelizado from 'src/services/fidelizados/UpdateFidelizado'
import DeleteFidelizado from 'src/services/fidelizados/DeleteFidelizado'

const AddFidelizadoModal = (props) => {
  const [addFidelizadoVisible, setAddFidelizadoVisible] = useState(false)
  const [newTipoDocumento, setNewTipoDocumento] = useState()
  const [newDocumento, setNewDocumento] = useState()
  const [newNombre, setNewNombre] = useState()
  const [newContrasena, setNewContrasena] = useState()
  const [newPorcentajePunto, setNewPorcentajePuntoChange] = useState()
  const [newTelefono, setNewTelefonoChange] = useState('0000000000')
  const [newCelular, setNewCelularChange] = useState()
  const [newDireccion, setNewDireccionChange] = useState()
  const [newEstrato, setNewEstratoChange] = useState(0)
  const [newNumeroHijos, setNewNumeroHijosChange] = useState(0)
  const [newSexo, setNewSexoChange] = useState()
  const [newCiudad, setNewCiudad] = useState()
  const [newProfesion, setNewProfesion] = useState(0)
  let tipoDocumento = []
  tipoDocumento.push({ value: 1, name: 'Cedula' })
  tipoDocumento.push({ value: 2, name: 'Pasaporte' })
  let sexo = []
  sexo.push({ value: 1, name: 'Masculino' })
  sexo.push({ value: 2, name: 'Femenino' })
  sexo.push({ value: 3, name: 'Otro' })
  let ciudad = []
  ciudad.push({ value: 168, name: 'Cartagena' })
  ciudad.push({ value: 12, name: 'Medellín' })
  let profesion = []
  profesion.push({ value: 1, name: 'Ingeniero' })
  profesion.push({ value: 2, name: 'Medico' })
  profesion.push({ value: 3, name: 'Estudiante' })
  const handleTipoDocumentoChange = (event) => {
    setNewTipoDocumento(event.target.value)
  }
  const handleDocumentoChange = (event) => {
    setNewDocumento(event.target.value)
  }
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handleContrasenaChange = (event) => {
    setNewContrasena(event.target.value)
  }
  const handlePorcentajePuntoChange = (event) => {
    setNewPorcentajePuntoChange(event.target.value)
  }
  const handleTelefonoChange = (event) => {
    setNewTelefonoChange(event.target.value)
  }
  const handleCelularChange = (event) => {
    setNewCelularChange(event.target.value)
  }
  const handleDireccionChange = (event) => {
    setNewDireccionChange(event.target.value)
  }
  const handleEstratoChange = (event) => {
    setNewEstratoChange(event.target.value)
  }
  const handleNumeroHijosChange = (event) => {
    setNewNumeroHijosChange(event.target.value)
  }
  const handleSexoChange = (event) => {
    setNewSexoChange(event.target.value)
  }
  const handleCiudadChange = (event) => {
    setNewCiudad(event.target.value)
  }
  const handleProfesionChange = (event) => {
    setNewProfesion(event.target.value)
  }
  const addFidelizado = async () => {
    await AddFidelizado(
      newDocumento,
      newTipoDocumento,
      newNombre,
      newContrasena,
      newPorcentajePunto,
      5,
      newTelefono,
      newCelular,
      newDireccion,
      newEstrato,
      newNumeroHijos,
      newSexo,
      newCiudad,
      newProfesion,
    )
    props.GetFidelizados()
    setAddFidelizadoVisible(false)
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setAddFidelizadoVisible(true)}>
        <CIcon icon={cilPlus} size="sm" />
      </CButton>
      <CModal
        visible={addFidelizadoVisible}
        alignment="center"
        onClose={() => setAddFidelizadoVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Agregar Fidelizado</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow className="mb-2">
            <CCol xs={3}>Tipo documento:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handleTipoDocumentoChange}>
                <option>Selecione un opcion</option>
                {tipoDocumento.map((tipoDocumento) => (
                  <option key={tipoDocumento.value} value={tipoDocumento.value}>
                    {tipoDocumento.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Documento:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Documento" onChange={handleDocumentoChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Nombre:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Nombre" onChange={handleNombreChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Contrase&ntilde;a:</CCol>
            <CCol xs={9}>
              <CFormInput
                type="password"
                placeholder="Contrase&ntilde;a"
                onChange={handleContrasenaChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Porcentaje de Puntos:</CCol>
            <CCol xs={9}>
              <CFormInput
                placeholder="Porcentaje de Puntos"
                onChange={handlePorcentajePuntoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tel&eacute;fono:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Tel&eacute;fono" onChange={handleTelefonoChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Celular:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Celular" onChange={handleCelularChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Direcci&oacute;n:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Direcci&oacute;n" onChange={handleDireccionChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Estrato:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="Estrato" onChange={handleEstratoChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>N&uacute;mero de Hijos:</CCol>
            <CCol xs={9}>
              <CFormInput placeholder="N&uacute;mero de Hijos" onChange={handleNumeroHijosChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Sexo:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handleSexoChange}>
                <option>Selecione un opcion</option>
                {sexo.map((sexo) => (
                  <option key={sexo.value} value={sexo.value}>
                    {sexo.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Ciudad:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handleCiudadChange}>
                <option>Selecione un opcion</option>
                {ciudad.map((ciudad) => (
                  <option key={ciudad.value} value={ciudad.value}>
                    {ciudad.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Profesi&oacute;n:</CCol>
            <CCol xs={9}>
              <CFormSelect aria-label="Default select example" onChange={handleProfesionChange}>
                <option>Selecione un opcion</option>
                {profesion.map((profesion) => (
                  <option key={profesion.value} value={profesion.value}>
                    {profesion.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setAddFidelizadoVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={addFidelizado}>
            Agregar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const TaskFidelizado = (props) => {
  const [updateFidelizadoVisible, setUpdateFidelizadoVisible] = useState(false)
  const [deleteFidelizadoVisible, setDeleteFidelizadoVisible] = useState(false)
  const [newTipoDocumento, setNewTipoDocumento] = useState(props.Fidelizado.tipoDocumentoId)
  const [newDocumento, setNewDocumento] = useState(props.Fidelizado.documento)
  const [newNombre, setNewNombre] = useState(props.Fidelizado.nombre)
  const [newPorcentajePunto, setNewPorcentajePuntoChange] = useState(
    props.Fidelizado.porcentajePuntos,
  )
  const [newTelefono, setNewTelefonoChange] = useState(
    props.Fidelizado.informacionAdicional.telefono,
  )
  const [newCelular, setNewCelularChange] = useState(props.Fidelizado.informacionAdicional.celular)
  const [newDireccion, setNewDireccionChange] = useState(
    props.Fidelizado.informacionAdicional.direccion,
  )
  const [newEstrato, setNewEstratoChange] = useState(props.Fidelizado.informacionAdicional.estrato)
  const [newNumeroHijos, setNewNumeroHijosChange] = useState(
    props.Fidelizado.informacionAdicional.numeroHijos,
  )
  const [newSexo, setNewSexoChange] = useState(props.Fidelizado.informacionAdicional.sexoId)
  const [newCiudad, setNewCiudad] = useState(props.Fidelizado.informacionAdicional.ciudadId)
  const [newProfesion, setNewProfesion] = useState(
    props.Fidelizado.informacionAdicional.profesionId,
  )
  let tipoDocumento = []
  tipoDocumento.push({ value: 1, name: 'Cedula' })
  tipoDocumento.push({ value: 2, name: 'Pasaporte' })
  let sexo = []
  sexo.push({ value: 1, name: 'Masculino' })
  sexo.push({ value: 2, name: 'Femenino' })
  sexo.push({ value: 3, name: 'Otro' })
  let ciudad = []
  ciudad.push({ value: 168, name: 'Cartagena' })
  ciudad.push({ value: 12, name: 'Medellín' })
  let profesion = []
  profesion.push({ value: 1, name: 'Ingeniero' })
  profesion.push({ value: 2, name: 'Medico' })
  profesion.push({ value: 3, name: 'Estudiante' })
  const handleTipoDocumentoChange = (event) => {
    setNewTipoDocumento(event.target.value)
  }
  const handleDocumentoChange = (event) => {
    setNewDocumento(event.target.value)
  }
  const handleNombreChange = (event) => {
    setNewNombre(event.target.value)
  }
  const handlePorcentajePuntoChange = (event) => {
    setNewPorcentajePuntoChange(event.target.value)
  }
  const handleTelefonoChange = (event) => {
    setNewTelefonoChange(event.target.value)
  }
  const handleCelularChange = (event) => {
    setNewCelularChange(event.target.value)
  }
  const handleDireccionChange = (event) => {
    setNewDireccionChange(event.target.value)
  }
  const handleEstratoChange = (event) => {
    setNewEstratoChange(event.target.value)
  }
  const handleNumeroHijosChange = (event) => {
    setNewNumeroHijosChange(event.target.value)
  }
  const handleSexoChange = (event) => {
    setNewSexoChange(event.target.value)
  }
  const handleCiudadChange = (event) => {
    setNewCiudad(event.target.value)
  }
  const handleProfesionChange = (event) => {
    setNewProfesion(event.target.value)
  }

  const updateFidelizado = async () => {
    let fidelizado = props.Fidelizado
    fidelizado.tipoDocumento = newTipoDocumento
    fidelizado.documento = newDocumento
    fidelizado.nombre = newNombre
    fidelizado.procentaje = newPorcentajePunto
    fidelizado.informacionAdicional.telefono = newTelefono
    fidelizado.informacionAdicional.celular = newCelular
    fidelizado.informacionAdicional.direccion = newDireccion
    fidelizado.informacionAdicional.estrato = newEstrato
    fidelizado.informacionAdicional.numero = newNumeroHijos
    fidelizado.informacionAdicional.sexoId = newSexo
    fidelizado.informacionAdicional.ciudadId = newCiudad
    fidelizado.informacionAdicional.profesionId = newProfesion
    await UpdateFidelizado(props.Fidelizado)
    props.GetFidelizados()
    setUpdateFidelizadoVisible(false)
  }
  const deleteFidelizado = async () => {
    await DeleteFidelizado(props.Fidelizado)
    props.GetFidelizados()
    setDeleteFidelizadoVisible(false)
  }

  return (
    <>
      <CButton style={{ margin: '2pt' }} onClick={() => setUpdateFidelizadoVisible(true)}>
        <CIcon icon={cilPencil} size="sm" />
      </CButton>
      <CModal
        visible={updateFidelizadoVisible}
        alignment="center"
        onClose={() => setUpdateFidelizadoVisible(false)}
      >
        <CModalHeader>
          <CModalTitle>Actualizar Compa&ntilde;ia</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CRow className="mb-2">
            <CCol xs={3}>Tipo documento:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newTipoDocumento}
                aria-label="Default select example"
                onChange={handleTipoDocumentoChange}
              >
                <option>Selecione un opcion</option>
                {tipoDocumento.map((tipoDocumento) => (
                  <option key={tipoDocumento.value} value={tipoDocumento.value}>
                    {tipoDocumento.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Documento:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newDocumento}
                placeholder="Documento"
                onChange={handleDocumentoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Nombre:</CCol>
            <CCol xs={9}>
              <CFormInput value={newNombre} placeholder="Nombre" onChange={handleNombreChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Porcentaje de Puntos:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newPorcentajePunto}
                placeholder="Porcentaje de Puntos"
                onChange={handlePorcentajePuntoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Tel&eacute;fono:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newTelefono === '0000000000' ? '' : newTelefono}
                placeholder="Tel&eacute;fono"
                onChange={handleTelefonoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Celular:</CCol>
            <CCol xs={9}>
              <CFormInput value={newCelular} placeholder="Celular" onChange={handleCelularChange} />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Direcci&oacute;n:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newDireccion}
                placeholder="Direcci&oacute;n"
                onChange={handleDireccionChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Estrato:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newEstrato === 0 ? '' : newEstrato}
                placeholder="Estrato"
                onChange={handleEstratoChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>N&uacute;mero de Hijos:</CCol>
            <CCol xs={9}>
              <CFormInput
                value={newNumeroHijos === 0 ? '' : newNumeroHijos}
                placeholder="N&uacute;mero de Hijos"
                onChange={handleNumeroHijosChange}
              />
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Sexo:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newSexo}
                aria-label="Default select example"
                onChange={handleSexoChange}
              >
                <option>Selecione un opcion</option>
                {sexo.map((sexo) => (
                  <option key={sexo.value} value={sexo.value}>
                    {sexo.name}
                  </option>
                ))}
              </CFormSelect>
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
                <option>Selecione un opcion</option>
                {ciudad.map((tipo) => (
                  <option key={tipo.value} value={tipo.value}>
                    {tipo.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
          <CRow className="mb-2">
            <CCol xs={3}>Profesi&oacute;n:</CCol>
            <CCol xs={9}>
              <CFormSelect
                value={newProfesion}
                aria-label="Default select example"
                onChange={handleProfesionChange}
              >
                <option>Selecione un opcion</option>
                {profesion.map((profesion) => (
                  <option key={profesion.value} value={profesion.value}>
                    {profesion.name}
                  </option>
                ))}
              </CFormSelect>
            </CCol>
          </CRow>
        </CModalBody>
        <CModalFooter>
          <CButton color="secondary" onClick={() => setUpdateFidelizadoVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={updateFidelizado}>
            Actualizar
          </CButton>
        </CModalFooter>
      </CModal>
      <CButton style={{ margin: '2pt' }} onClick={() => setDeleteFidelizadoVisible(true)}>
        <CIcon icon={cilX} size="sm" />
      </CButton>
      <CModal
        visible={deleteFidelizadoVisible}
        alignment="center"
        onClose={() => setDeleteFidelizadoVisible(false)}
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
          <CButton color="secondary" onClick={() => setDeleteFidelizadoVisible(false)}>
            Cerrar
          </CButton>
          <CButton color="primary" onClick={deleteFidelizado}>
            Eliminar
          </CButton>
        </CModalFooter>
      </CModal>
    </>
  )
}

const Fidelizados = () => {
  let navigate = useNavigate()
  const [Fidelizados, setFidelizados] = useState([])
  const toastRef = useRef()

  const fetchFidelizados = async () => {
    let fidelizados = await GetFidelizados()
    setFidelizados(fidelizados)
  }

  useEffect(() => {
    fetchFidelizados()
  }, [])

  return (
    <>
      <h1>Fidelizados</h1>
      <AddFidelizadoModal GetFidelizados={fetchFidelizados} />
      <CRow>
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col"></CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
            {Fidelizados.map((fidelizado) => (
              <CTableRow key={fidelizado.id}>
                <CTableHeaderCell>{fidelizado.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.Puntos}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskFidelizado GetFidelizados={fetchFidelizados} Fidelizado={fidelizado} />
                </CTableHeaderCell>
              </CTableRow>
            ))}
          </CTableBody>
        </CTable>
      </CRow>
    </>
  )
}

export default Fidelizados
