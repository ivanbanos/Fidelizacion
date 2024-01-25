import { React, useState, useEffect, useRef } from 'react'
import { useNavigate } from 'react-router-dom'
import GetFidelizados from '../../services/fidelizados/GetFidelizados'
import GetFidelizadosPorCentroVenta from '../../services/fidelizados/GetFidelizadosPorCentroVenta'
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
  CForm,
  CFormLabel,
  CInputGroup,
  CInputGroupText,
  CFormCheck,
  CFormFeedback,
} from '@coreui/react'
import AddFidelizado from 'src/services/fidelizados/AddFidelizado'
import UpdateFidelizado from 'src/services/fidelizados/UpdateFidelizado'
import DeleteFidelizado from 'src/services/fidelizados/DeleteFidelizado'
import GetCiudades from 'src/services/configuraciones/GetCiudades'
import GetCentroVentas from '../../services/centroVentas/GetCentroVentas'
import GetCentroVentaPorCompania from '../../services/centroVentas/GetCentroVentaPorCompania'

const AddFidelizadoModal = (props) => {
  const centroVenta = localStorage.getItem('idCentroVenta')
  const [validated, setValidated] = useState(false)
  const [addFidelizadoVisible, setAddFidelizadoVisible] = useState(false)
  const [inputCentroVentaVisible, setCentroVentaVisible] = useState(
    props.Perfil === '1' || props.Perfil === '2',
  )
  const [newTipoDocumento, setNewTipoDocumento] = useState()
  const [newDocumento, setNewDocumento] = useState()
  const [newNombre, setNewNombre] = useState()
  const [newPorcentajePunto, setNewPorcentajePuntoChange] = useState()
  const [newTelefono, setNewTelefonoChange] = useState('0000000000')
  const [newCelular, setNewCelularChange] = useState()
  const [newDireccion, setNewDireccionChange] = useState()
  const [newEstrato, setNewEstratoChange] = useState(0)
  const [newNumeroHijos, setNewNumeroHijosChange] = useState(0)
  const [newSexo, setNewSexoChange] = useState()
  const [newCiudad, setNewCiudad] = useState()
  const [newProfesion, setNewProfesion] = useState(0)
  const [newCentroVenta, setNewCentroVentaChange] = useState(centroVenta)
  let tipoDocumento = []
  tipoDocumento.push({ value: 1, name: 'Cedula' })
  tipoDocumento.push({ value: 2, name: 'Pasaporte' })
  let sexo = []
  sexo.push({ value: 1, name: 'Masculino' })
  sexo.push({ value: 2, name: 'Femenino' })
  sexo.push({ value: 3, name: 'Otro' })
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
      await AddFidelizado(
        newDocumento,
        newTipoDocumento,
        newNombre,
        newPorcentajePunto,
        newCentroVenta,
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
      setValidated(false)
      setAddFidelizadoVisible(false)
    }
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
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Tipo documento*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Tipo de documento"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTipoDocumentoChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {tipoDocumento.map((tipoDocumento) => (
                    <option key={tipoDocumento.value} value={tipoDocumento.value}>
                      {tipoDocumento.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Documento*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Documento"
                  type="text"
                  id="email"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDocumentoChange}
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
              <CCol xs={3}>Porcentaje de Puntos*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Porcentaje de Puntos"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePorcentajePuntoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tel&eacute;fono:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Tel&eacute;fono"
                  type="text"
                  onChange={handleTelefonoChange}
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Celular*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Celular"
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleCelularChange}
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
              <CCol xs={3}>Estrato:</CCol>
              <CCol xs={9}>
                <CFormInput placeholder="Estrato" type="text" onChange={handleEstratoChange} />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>N&uacute;mero de Hijos:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="N&uacute;mero de Hijos"
                  type="text"
                  onChange={handleNumeroHijosChange}
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Sexo*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Sexo"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleSexoChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {sexo.map((sexo) => (
                    <option key={sexo.value} value={sexo.value}>
                      {sexo.name}
                    </option>
                  ))}
                </CFormSelect>
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
            <CRow className="mb-2">
              <CCol xs={3}>Profesi&oacute;n:</CCol>
              <CCol xs={9}>
                <CFormSelect aria-label="Profesi&ocute;n" onChange={handleProfesionChange}>
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {profesion.map((profesion) => (
                    <option key={profesion.value} value={profesion.value}>
                      {profesion.name}
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
              <CButton color="secondary" onClick={() => setAddFidelizadoVisible(false)}>
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

const TaskFidelizado = (props) => {
  const [updateFidelizadoVisible, setUpdateFidelizadoVisible] = useState(false)
  const [deleteFidelizadoVisible, setDeleteFidelizadoVisible] = useState(false)
  const [validated, setValidated] = useState(false)
  const [newTipoDocumento, setNewTipoDocumento] = useState(props.Fidelizado.tipoDocumentoId)
  const [newDocumento, setNewDocumento] = useState(props.Fidelizado.documento)
  const [newNombre, setNewNombre] = useState(props.Fidelizado.nombre)
  const [newPorcentajePunto, setNewPorcentajePuntoChange] = useState(
    props.Fidelizado.porcentajePuntos,
  )
  const [newTelefono, setNewTelefonoChange] = useState(props.Fidelizado.telefono)
  const [newCelular, setNewCelularChange] = useState(props.Fidelizado.celular)
  const [newDireccion, setNewDireccionChange] = useState(props.Fidelizado.direccion)
  const [newEstrato, setNewEstratoChange] = useState(props.Fidelizado.estrato)
  const [newNumeroHijos, setNewNumeroHijosChange] = useState(props.Fidelizado.numeroHijos)
  const [newSexo, setNewSexoChange] = useState(props.Fidelizado.sexoId)
  const [newCiudad, setNewCiudad] = useState(props.Fidelizado.ciudadId)
  const [newProfesion, setNewProfesion] = useState(props.Fidelizado.profesionId)
  let tipoDocumento = []
  tipoDocumento.push({ value: 1, name: 'Cedula' })
  tipoDocumento.push({ value: 2, name: 'Pasaporte' })
  let sexo = []
  sexo.push({ value: 1, name: 'Masculino' })
  sexo.push({ value: 2, name: 'Femenino' })
  sexo.push({ value: 3, name: 'Otro' })
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

  const handleSubmit = async (event) => {
    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.preventDefault()
      event.stopPropagation()
    }
    setValidated(true)
    if (form.checkValidity() === true) {
      let fidelizado = props.Fidelizado
      fidelizado.nombre = newNombre
      fidelizado.porcentajePuntos = newPorcentajePunto
      fidelizado.telefono = newTelefono
      fidelizado.celular = newCelular
      fidelizado.direccion = newDireccion
      fidelizado.estrato = newEstrato
      fidelizado.numero = newNumeroHijos
      fidelizado.sexoId = newSexo
      fidelizado.ciudadId = newCiudad
      fidelizado.profesionId = newProfesion
      await UpdateFidelizado(props.Fidelizado)
      props.GetFidelizados()
      setValidated(false)
      setUpdateFidelizadoVisible(false)
    }
  }

  const updateFidelizado = async () => {
    let fidelizado = props.Fidelizado
    fidelizado.nombre = newNombre
    fidelizado.porcentajePuntos = newPorcentajePunto
    fidelizado.telefono = newTelefono
    fidelizado.celular = newCelular
    fidelizado.direccion = newDireccion
    fidelizado.estrato = newEstrato
    fidelizado.numero = newNumeroHijos
    fidelizado.sexoId = newSexo
    fidelizado.ciudadId = newCiudad
    fidelizado.profesionId = newProfesion
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
          <CModalTitle>Actualizar Fidelizado</CModalTitle>
        </CModalHeader>
        <CModalBody>
          <CForm
            className="row g-3 needs-validation"
            noValidate
            validated={validated}
            onSubmit={handleSubmit}
          >
            <CRow className="mb-2">
              <CCol xs={3}>Tipo documento*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Tipo de documento"
                  value={newTipoDocumento}
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleTipoDocumentoChange}
                  disabled
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {tipoDocumento.map((tipoDocumento) => (
                    <option key={tipoDocumento.value} value={tipoDocumento.value}>
                      {tipoDocumento.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Documento*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Documento"
                  value={newDocumento}
                  type="text"
                  id="documento"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleDocumentoChange}
                  disabled
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
              <CCol xs={3}>Porcentaje de Puntos*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Porcentaje de Puntos"
                  value={newPorcentajePunto}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handlePorcentajePuntoChange}
                  required
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Tel&eacute;fono:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Tel&eacute;fono"
                  value={newTelefono === '0000000000' ? '' : newTelefono}
                  type="text"
                  onChange={handleTelefonoChange}
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Celular*:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Celular"
                  value={newCelular}
                  type="text"
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleCelularChange}
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
              <CCol xs={3}>Estrato:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="Estrato"
                  value={newEstrato === 0 ? '' : newEstrato}
                  type="text"
                  onChange={handleEstratoChange}
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>N&uacute;mero de Hijos:</CCol>
              <CCol xs={9}>
                <CFormInput
                  placeholder="N&uacute;mero de Hijos"
                  value={newNumeroHijos === 0 ? '' : newNumeroHijos}
                  type="text"
                  onChange={handleNumeroHijosChange}
                />
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Sexo*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Sexo"
                  value={newSexo}
                  feedbackInvalid="Este campo es requerido"
                  onChange={handleSexoChange}
                  required
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {sexo.map((sexo) => (
                    <option key={sexo.value} value={sexo.value}>
                      {sexo.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CRow className="mb-2">
              <CCol xs={3}>Ciudad*:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Ciudad"
                  value={newCiudad}
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
            <CRow className="mb-2">
              <CCol xs={3}>Profesi&oacute;n:</CCol>
              <CCol xs={9}>
                <CFormSelect
                  aria-label="Profesi&ocute;n"
                  value={newProfesion}
                  onChange={handleProfesionChange}
                >
                  <option selected="" value="">
                    Seleccione una opci&oacute;n
                  </option>
                  {profesion.map((profesion) => (
                    <option key={profesion.value} value={profesion.value}>
                      {profesion.name}
                    </option>
                  ))}
                </CFormSelect>
              </CCol>
            </CRow>
            <CModalFooter>
              <CButton color="secondary" onClick={() => setUpdateFidelizadoVisible(false)}>
                Cerrar
              </CButton>
              <CButton color="primary" type="submit">
                Actualizar
              </CButton>
            </CModalFooter>
          </CForm>
        </CModalBody>
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
          <CModalTitle>Eliminar Fidelizado</CModalTitle>
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
  const perfil = localStorage.getItem('perfil')
  const [Fidelizados, setFidelizados] = useState([])
  const [ciudades, setCiudades] = useState([])
  const [CentroVentas, setCentroVentas] = useState([])
  const toastRef = useRef()

  const fetchFidelizados = async () => {
    let fidelizados = []
    if (perfil === '1') {
      fidelizados = await GetFidelizados()
    } else {
      fidelizados = await GetFidelizadosPorCentroVenta()
    }
    if (fidelizados === 'fail') {
      navigate('/Login', { replace: true })
    } else {
      setFidelizados(fidelizados)
    }
  }

  const fetchCiudades = async () => {
    let ciudades = await GetCiudades()
    setCiudades(ciudades)
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
    fetchFidelizados()
    fetchCiudades()
    fetchCentroVentas()
  }, [])

  return (
    <>
      <h1>Fidelizados</h1>
      <AddFidelizadoModal
        GetFidelizados={fetchFidelizados}
        ciudades={ciudades}
        Perfil={perfil}
        CentroVentas={CentroVentas}
      />
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
                <CTableHeaderCell>{fidelizado.puntos ?? 0}</CTableHeaderCell>
                <CTableHeaderCell>
                  <TaskFidelizado
                    GetFidelizados={fetchFidelizados}
                    ciudades={ciudades}
                    Fidelizado={fidelizado}
                    Perfil={perfil}
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

export default Fidelizados
