import React from 'react'
import CIcon from '@coreui/icons-react'
import {
  cilContact,
  cilFactory,
  cilBuilding,
  cilDescription,
  cilSpeedometer,
  cilUser,
  cilGift,
} from '@coreui/icons'
import { CNavGroup, CNavItem, CNavTitle } from '@coreui/react'

const _navSuperAdministrador = [
  {
    component: CNavItem,
    name: 'Dashboard',
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Compañias',
    to: '/companias',
    icon: <CIcon icon={cilFactory} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Centros de Ventas',
    to: '/centroVentas',
    icon: <CIcon icon={cilBuilding} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Usuarios',
    to: '/usuarios',
    icon: <CIcon icon={cilUser} customClassName="nav-icon" />,
  },
  {
    component: CNavGroup,
    name: 'Reportes',
    to: '/base',
    icon: <CIcon icon={cilDescription} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Fidelizados',
        to: '/reporte/ReporteFidelizados',
      },
    ],
  },
]

export default _navSuperAdministrador
