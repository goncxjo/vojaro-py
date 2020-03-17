import Vue from 'vue'
import Router from 'vue-router'

import Home from '@/views/Home.vue'
import Login from '@/views/Login.vue'
import Layout from '@/views/Layout.vue'
import UniversidadIndex from '@/views/UniversidadIndex.vue'
import UniversidadEditar from '@/views/UniversidadEditar.vue'

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
        { name: 'universidades.index', path: '', component: UniversidadIndex },
        { name: 'universidades.new', path: '/universidades/new', component: UniversidadEditar },
        { name: 'universidades.edit', path: '/universidades/edit/:id', component: UniversidadEditar },
      ]
    }
  ]
})
