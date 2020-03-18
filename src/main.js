import Vue from 'vue'

import router from '@/router'
import store from '@/store'
import vuetify from '@/plugins/vuetify';
import '@/filters'
import axios from 'axios'

import App from '@/components/App.vue'

Vue.config.productionTip = false
const token = localStorage.getItem('user-token')
if (token) {
  axios.defaults.headers.common['Authorization'] = token
}

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
