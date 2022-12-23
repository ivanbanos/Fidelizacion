import { React, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CFormInput,
  CInputGroup,
  CInputGroupText,
  CRow,
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { cilLockLocked, cilUser } from '@coreui/icons'
import ActualizarContrasena from '../../../services/configuraciones/ActualizarContrasena'

const UpdateContrasena = () => {
  let navigate = useNavigate()
  const [errorMessages, seterrormessages] = useState({})
  const [newContrasena, setNewContrasena] = useState()
  const [newContrasenaRepetida, setNewContrasenaRepetida] = useState()

  const handleContrasenaChange = (event) => {
    setNewContrasena(event.target.value)
  }

  const handleContrasenaRepetidaChange = (event) => {
    setNewContrasenaRepetida(event.target.value)
  }
  const handleSubmit = async (event) => {
    event.preventDefault()
    if (newContrasena === newContrasenaRepetida) {
      await ActualizarContrasena(newContrasena)
      navigate('/Dashboard', { replace: true })
    } else {
      seterrormessages({ name: 'password', message: 'Contraseña no coinciden' })
    }
    //Prevent page reload
  }

  return (
    <div className="bg-light min-vh-100 d-flex flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md={8}>
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <CForm>
                    <h1>Actualizaci&oacute;n Contrase&ntilde;a</h1>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        placeholder="Nueva Contrase&ntilde;a"
                        type="password"
                        autoComplete="Nueva-contrase&ntilde;a"
                        onChange={handleContrasenaChange}
                      />
                    </CInputGroup>
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon icon={cilLockLocked} />
                      </CInputGroupText>
                      <CFormInput
                        type="password"
                        placeholder="Repita contrase&ntilde;a"
                        autoComplete="Nueva-contrase&ntilde;a"
                        onChange={handleContrasenaRepetidaChange}
                      />
                    </CInputGroup>
                    <CRow>
                      <CCol xs={6}>
                        <CButton
                          color="primary"
                          className="px-4"
                          onClick={handleSubmit}
                          navigate={navigate}
                          seterrormessages={seterrormessages}
                        >
                          Actualizar
                        </CButton>
                        <div className="error">{errorMessages.message}</div>
                      </CCol>
                    </CRow>
                  </CForm>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default UpdateContrasena
