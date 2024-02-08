import { React, useState, useEffect, useRef, useImperativeHandle, forwardRef } from 'react'
import GetFidelizados from '../../services/fidelizados/GetFidelizados'
import GetFidelizadosConFiltro from '../../services/fidelizados/GetFidelizadosConFiltro'
import GetFidelizadosPorCentroVenta from '../../services/fidelizados/GetFidelizadosPorCentroVenta'
import GetFidelizadosPorCentroVentaConFiltro from '../../services/fidelizados/GetFidelizadosPorCentroVentaConFiltro'
import {
  CButton,
  CRow,
  CCol,
  CCard,
  CCardBody,
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CFormInput,
  CForm,
  CInputGroup,
  CInputGroupText,
} from '@coreui/react'
import GetCiudades from 'src/services/configuraciones/GetCiudades'

const ReporteFidelizados = () => {
  const perfil = localStorage.getItem('perfil')
  const [fidelizados, setFidelizados] = useState([])
  const [ciudades, setCiudades] = useState([])
  const [filtro, setFiltro] = useState()

  const handleFiltroChange = (event) => {
    setFiltro(event.target.value)
  }

  const fetchFidelizados = async () => {
    let fidelizados = []
    if (perfil === '1') {
      fidelizados = await GetFidelizados()
    } else {
      fidelizados = await GetFidelizadosPorCentroVenta()
    }
    setFidelizados(fidelizados)
  }

  const fetchCiudades = async () => {
    let ciudades = await GetCiudades()
    setCiudades(ciudades)
  }

  useEffect(() => {
    fetchFidelizados()
    fetchCiudades()
  }, [])

  const handleSubmit = async (event) => {
    let fidelizados = []
    if (perfil === '1') {
      fidelizados = await GetFidelizadosConFiltro(filtro)
    } else {
      fidelizados = await GetFidelizadosPorCentroVentaConFiltro(filtro)
    }
    setFidelizados(fidelizados)
    event.preventDefault()
  }

  return (
    <>
      <h1>Reporte Fidelizados</h1>
      <CRow>
        <CCol xs={12} className="px-0">
          <CCard>
            <CCardBody>
              <CForm className="row mt-1 needs-validation" onSubmit={handleSubmit}>
                <CRow className="mb-2">
                  <CCol xs={9}>
                    <CInputGroup className="mb-3">
                      <CInputGroupText id="basic-addon1">Filto</CInputGroupText>
                      <CFormInput
                        placeholder="Filtro"
                        type="text"
                        id="filtro"
                        onChange={handleFiltroChange}
                      />
                    </CInputGroup>
                  </CCol>
                  <CCol xs={3}>
                    <CButton className="me-3" color="primary" type="submit">
                      Buscar
                    </CButton>
                  </CCol>
                </CRow>
              </CForm>
            </CCardBody>
          </CCard>
        </CCol>
      </CRow>
      <CRow className="mt-2">
        <CTable>
          <CTableHead>
            <CTableRow>
              <CTableHeaderCell scope="col">Nombre</CTableHeaderCell>
              <CTableHeaderCell scope="col">Puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col">Porcentaje de Puntos</CTableHeaderCell>
              <CTableHeaderCell scope="col">Puntos Reservados</CTableHeaderCell>
              <CTableHeaderCell scope="col">Celular</CTableHeaderCell>
              <CTableHeaderCell scope="col">Ciudad</CTableHeaderCell>
            </CTableRow>
          </CTableHead>
          <CTableBody>
            {fidelizados.map((fidelizado) => (
              <CTableRow key={fidelizado.id}>
                <CTableHeaderCell>{fidelizado.nombre}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.puntos ?? 0}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.porcentajePuntos}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.puntosReservados ?? 0}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.celular}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.nombreCiudad}</CTableHeaderCell>
              </CTableRow>
            ))}
          </CTableBody>
        </CTable>
      </CRow>
    </>
  )
}

export default ReporteFidelizados
