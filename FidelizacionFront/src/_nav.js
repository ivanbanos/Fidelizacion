import React from 'react'
import CIcon from '@coreui/icons-react'
import {
  cilContact,
  cilFactory,
  cilBuilding,
  cilDescription,
  cilSpeedometer,
  cilStar,
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
    name: 'Compañias',
    to: '/companias',
    icon: <CIcon icon={cilFactory} customClassName="nav-icon" />,
  },
  {
    component: CNavGroup,
    name: 'Centros de Ventas',
    to: '/base',
    icon: <CIcon icon={cilBuilding} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Agregar',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Actualizar',
        to: '/base/breadcrumbs',
      },
      {
        component: CNavItem,
        name: 'Eliminar',
        to: '/base/cards',
      },
      {
        component: CNavItem,
        name: 'Listar',
        to: '/base/carousels',
      },
    ],
  },
  {
    component: CNavGroup,
    name: 'Fidelizados',
    to: '/base',
    icon: <CIcon icon={cilContact} customClassName="nav-icon" />,
    items: [
      {
        component: CNavItem,
        name: 'Agregar',
        to: '/base/accordion',
      },
      {
        component: CNavItem,
        name: 'Actualizar',
        to: '/base/breadcrumbs',
      },
      {
        component: CNavItem,
        name: 'Eliminar',
        to: '/base/cards',
      },
      {
        component: CNavItem,
        name: 'Listar',
        to: '/base/carousels',
      },
    ],
  },
  {
    component: CNavItem,
    name: 'Reportes',
    href: 'https://coreui.io/react/docs/templates/installation/',
    icon: <CIcon icon={cilDescription} customClassName="nav-icon" />,
  },
]

export default _nav
