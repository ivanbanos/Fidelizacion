import { React, useState, useEffect } from 'react'
import { useSelector, useDispatch } from 'react-redux'

import { CSidebar, CSidebarBrand, CSidebarNav, CSidebarToggler } from '@coreui/react'
import CIcon from '@coreui/icons-react'

import { AppSidebarNav } from './AppSidebarNav'

import { logoNegative } from 'src/assets/brand/logo-negative'
import { sygnet } from 'src/assets/brand/sygnet'

import SimpleBar from 'simplebar-react'
import 'simplebar/dist/simplebar.min.css'

// sidebar nav config
import navigation from '../_nav'
import navigationSuperAdministrador from '../_navSuperAdministrador'
import navigationAdministrador from '../_navAdministrador'
import navigationSupervisor from '../_navSupervisor'

const AppSidebar = () => {
  const dispatch = useDispatch()
  const unfoldable = useSelector((state) => state.sidebarUnfoldable)
  const sidebarShow = useSelector((state) => state.sidebarShow)
  const [Navigation, setNavigation] = useState([])

  const returnNav = () => {
    const perfil = localStorage.getItem('perfil')
    if (perfil === '1') {
      setNavigation(navigationSuperAdministrador)
    } else if (perfil === '2') {
      setNavigation(navigationAdministrador)
    } else if (perfil === '3') {
      setNavigation(navigationSupervisor)
    } else {
      setNavigation(navigation)
    }
  }

  useEffect(() => {
    returnNav()
  }, [])

  return (
    <CSidebar
      position="fixed"
      unfoldable={unfoldable}
      visible={sidebarShow}
      onVisibleChange={(visible) => {
        dispatch({ type: 'set', sidebarShow: visible })
      }}
    >
      <CSidebarBrand className="d-none d-md-flex" to="/">
        <img
          className="sidebar-brand-full"
          height={60}
          src={require('../assets/images/sigesLogo.jpeg')}
        />
        <CIcon className="sidebar-brand-narrow" icon={sygnet} height={35} />
      </CSidebarBrand>
      <CSidebarNav>
        <SimpleBar>
          <AppSidebarNav className="sideNav" items={Navigation} />
        </SimpleBar>
      </CSidebarNav>
      <CSidebarToggler
        className="d-none d-lg-flex"
        onClick={() => dispatch({ type: 'set', sidebarUnfoldable: !unfoldable })}
      />
    </CSidebar>
  )
}

export default AppSidebar
