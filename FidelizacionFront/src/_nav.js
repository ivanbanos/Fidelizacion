import React from 'react'
import CIcon from '@coreui/icons-react'
import {
  cilContact,
  cilFactory,
  cilBuilding,
  cilDescription,
  cilSpeedometer,
  cilGift,
} from '@coreui/icons'
import { CNavGroup, CNavItem, CNavTitle } from '@coreui/react'

const _nav = [
  {
    component: CNavItem,
    name: 'Dashboard',
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Fidelizados',
    to: '/fidelizados',
    icon: <CIcon icon={cilContact} customClassName="nav-icon" />,
  },
  {
    component: CNavItem,
    name: 'Premios',
    to: '/premios',
    icon: <CIcon icon={cilGift} customClassName="nav-icon" />,
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

export default _nav
