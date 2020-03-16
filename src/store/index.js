import Vue from 'vue'
import Vuex from 'vuex'
import universidades from './modules/universidades'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
      universidades
    },
  })
