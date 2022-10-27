import { React, useState, useEffect, useRef, useImperativeHandle, forwardRef } from 'react'
import { useParams } from 'react-router-dom'
import { useNavigate } from 'react-router-dom'
import GetFidelizados from '../../services/fidelizados/GetFidelizados'
import {
  CButton,
  CRow,
  CCol,
  CCard,
  CCardBody,
  CCardText,
  CCardHeader,
  CTable,
  CTableBody,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
  CFormInput,
  CFormSelect,
  CModal,
  CModalBody,
  CModalFooter,
  CModalHeader,
  CModalTitle,
} from '@coreui/react'

const ReporteFidelizados = () => {
  const [fidelizados, setFidelizados] = useState([])

  const fetchFidelizados = async () => {
    let fidelizados = await GetFidelizados()
    setFidelizados(fidelizados)
  }

  useEffect(() => {
    fetchFidelizados()
  }, [])

  let ciudad = []
  ciudad.push({ value: 168, name: 'Cartagena' })
  ciudad.push({ value: 12, name: 'Medellín' })
  return (
    <>
      <h1>Reporte Fidelizados</h1>
      <CRow>
        <CCol xs={12}>
          <CCard>
            <CCardHeader>Filtros</CCardHeader>
            <CCardBody>
              <CCardText>
                <CRow className="mb-2">
                  <CCol xs={3}>Documento:</CCol>
                  <CCol xs={9}>
                    <CFormInput placeholder="Documento" />
                  </CCol>
                </CRow>
                <CRow className="mb-2">
                  <CCol xs={3}>Ciudad:</CCol>
                  <CCol xs={9}>
                    <CFormSelect aria-label="Default select example">
                      <option>Selecione un opci&oacute;n</option>
                      {ciudad.map((tipo) => (
                        <option key={tipo.value} value={tipo.value}>
                          {tipo.name}
                        </option>
                      ))}
                    </CFormSelect>
                  </CCol>
                </CRow>
              </CCardText>
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
                <CTableHeaderCell>0</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.porcentajePuntos}</CTableHeaderCell>
                <CTableHeaderCell>0</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.informacionAdicional.celular}</CTableHeaderCell>
                <CTableHeaderCell>{fidelizado.informacionAdicional.ciudad.nombre}</CTableHeaderCell>
              </CTableRow>
            ))}
          </CTableBody>
        </CTable>
      </CRow>
    </>
  )
}

export default ReporteFidelizados
