import axios from 'axios'
import auth from './modules/auth'
import universidades from './modules/universidades'

axios.defaults.baseURL = '/api/'
axios.defaults.timeout = 60000
axios.defaults.headers.post['Content-Type'] = 'application/json'

// Response Interceptor to handle and log errors
axios.interceptors.response.use(function (response) {
  return response
}, function (error) {
  // Handle Error
  console.log(error)
  return Promise.reject(error)
})

export const httpClient = {
  auth,
  universidades,
}
