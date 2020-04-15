import Vue from 'vue'

import router from '@/router'
import store from '@/store'
import vuetify from '@/plugins/vuetify';
import axios from 'axios'
import '@/filters'

import App from '@/components/App.vue'

Vue.config.productionTip = false

new Vue({
  router,
  store,
  created () {
    const userString = localStorage.getItem('user')
    if (userString) {
      const userData = JSON.parse(userString)
      this.$store.commit('setUserData', userData)
    }
    axios.interceptors.response.use(
      response => response,
      error => {
        if (error.response.status === 401) {
          this.$store.dispatch('logout')
        }
        return Promise.reject(error)
      }
    )
  },
  vuetify,
  render: h => h(App)
}).$mount('#app')
