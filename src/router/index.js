import Vue from 'vue'
import Router from 'vue-router'
import store from '@/store'

import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Layout from '@/views/Layout.vue'
import UniversidadIndex from '@/views/UniversidadIndex.vue'
import UniversidadEditar from '@/views/UniversidadEditar.vue'

Vue.use(Router)

const ifNotAuthenticated = (to, from, next) => {
  if (!store.getters['auth/isAuthenticated']) {
    next()
    return
  }
  next('/')
}

const ifAuthenticated = (to, from, next) => {
  if (store.getters['auth/isAuthenticated']) {
    next()
    return
  }

  next('/login')
}

export default new Router({
  routes: [
    {
      path: '/login',
      component: Login,
      beforeEnter: ifNotAuthenticated
    },
    {
      path: '/',
      component: Home,
      beforeEnter: ifAuthenticated
    },
    {
      path: '/universidades',
      component: Layout,
      children: [
        { name: 'universidades.index', path: '', component: UniversidadIndex },
        { name: 'universidades.new', path: '/universidades/new', component: UniversidadEditar },
        { name: 'universidades.edit', path: '/universidades/edit/:id', component: UniversidadEditar },
      ],
      beforeEnter: ifAuthenticated,
    },
  ]
})
