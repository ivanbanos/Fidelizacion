import { React, useState, useEffect, useRef } from 'react'

import Companias from '../companias/Companias'
import {
  CAvatar,
  CButton,
  CButtonGroup,
  CCard,
  CCardBody,
  CCardFooter,
  CCardHeader,
  CCol,
  CProgress,
  CRow,
  CTable,
  CTableBody,
  CTableDataCell,
  CTableHead,
  CTableHeaderCell,
  CTableRow,
} from '@coreui/react'
import { CChartLine } from '@coreui/react-chartjs'
import { getStyle, hexToRgba } from '@coreui/utils'
import CIcon from '@coreui/icons-react'
import {
  cibCcAmex,
  cibCcApplePay,
  cibCcMastercard,
  cibCcPaypal,
  cibCcStripe,
  cibCcVisa,
  cibGoogle,
  cibFacebook,
  cibLinkedin,
  cifBr,
  cifEs,
  cifFr,
  cifIn,
  cifPl,
  cifUs,
  cibTwitter,
  cilCloudDownload,
  cilPeople,
  cilUser,
  cilUserFemale,
} from '@coreui/icons'
import CentroVentas from '../centroVentas/CentroVentas'
import Fidelizados from '../fidelizados/Fidelizados'

const Dashboard = () => {
  const perfil = localStorage.getItem('perfil')
  const [companiaVisible, setCompaniaVisible] = useState(false)
  const [centroVentasVisible, setCentroVentasVisible] = useState(false)
  const [fidelizadosVisible, setFidelizadosVisible] = useState(false)

  const returnPatanllaPrincipal = () => {
    if (perfil === '1') {
      setCompaniaVisible(true)
      setCentroVentasVisible(false)
      setFidelizadosVisible(false)
    } else if (perfil === '2') {
      setCompaniaVisible(false)
      setCentroVentasVisible(true)
      setFidelizadosVisible(false)
    } else if (perfil === '3') {
      setCompaniaVisible(false)
      setCentroVentasVisible(false)
      setFidelizadosVisible(true)
    } else {
      setCompaniaVisible(false)
      setCentroVentasVisible(false)
      setFidelizadosVisible(true)
    }
  }

  useEffect(() => {
    returnPatanllaPrincipal()
  }, [])

  return (
    <>
      {companiaVisible && <Companias></Companias>}
      {centroVentasVisible && <CentroVentas></CentroVentas>}
      {fidelizadosVisible && <Fidelizados></Fidelizados>}
    </>
  )
}

export default Dashboard
