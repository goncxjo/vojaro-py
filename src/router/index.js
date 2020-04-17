import Vue from 'vue'
import Router from 'vue-router'

import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Layout from '@/views/Layout.vue'
import RecursoNoEncontrado from '@/views/RecursoNoEncontrado.vue'

import UniversidadIndex from '@/views/UniversidadIndex.vue'
import UniversidadEditar from '@/views/UniversidadEditar.vue'

Vue.use(Router)

const authNotRequired = (to, from, next) => {
  const loggedIn = localStorage.getItem('user')

  if (!loggedIn) {
    next()
    return
  }
  next('/')
}

const authRequired = (to, from, next) => {
  const loggedIn = localStorage.getItem('user')

  if (loggedIn) {
    next()
    return
  }

  next('/login')
}

// TODO: refactorizar 
const removeAuth = (to, from, next) => {
  localStorage.removeItem('user')
  next()
}


const router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/login',
      component: Login,
      beforeEnter: authNotRequired
    },
    // {
    //   path: '/logout',
    //   component: Login,
    //   beforeEnter: removeAuth
    // },
    {
      path: '/',
      component: Home,
      beforeEnter: authRequired
    },
    {
      path: '/universidades',
      component: Layout,
      children: [
        { name: 'universidades.index', path: '', component: UniversidadIndex },
        { name: 'universidades.new', path: '/universidades/new', component: UniversidadEditar },
        { name: 'universidades.view', path: '/universidades/:id', component: UniversidadEditar },
        { name: 'universidades.edit', path: '/universidades/:id/edit', component: UniversidadEditar },
      ],
      beforeEnter: authRequired,
    },
    {
      path: '/404',
      name: '404',
      component: RecursoNoEncontrado
    },
    {
      path: '*',
      redirect: { name: '404' }
    }
  ]
})

export default router