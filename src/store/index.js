import Vue from 'vue'
import Vuex from 'vuex'

import auth from './modules/auth'
import shared from './modules/shared'
import universidades from './modules/universidades'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
      auth,
      shared,
      universidades,
    },
  })
