import Vue from 'vue'
import Router from 'vue-router'

import Home from './views/Home.vue'
import Login from './views/Login.vue'
import Layout from './views/Layout.vue'
import UniversidadIndex from './views/UniversidadIndex.vue'
import UniversidadEditar from './views/UniversidadEditar.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: Home
    },
    {
      path: '/login',
      component: Login
    },
    {
      path: '/universidades',
      component: Layout,
      children: [
        { name: 'universidad.index', path: '', component: UniversidadIndex },
        { name: 'universidad.crear', path: '/universidades/crear', component: UniversidadEditar },
        { name: 'universidad.editar', path: '/universidades/editar/:id', component: UniversidadEditar },
      ]
    }
  ]
})
