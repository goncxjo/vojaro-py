import axios from 'axios'
import universidades from './modules/universidades'

axios.defaults.baseURL = '/api/'
axios.defaults.timeout = 5000
axios.defaults.headers.post['Content-Type'] = 'application/json'

// Request Interceptor
axios.interceptors.request.use(function (config) {
  config.headers['Authorization'] = 'Fake Token'
  return config
})

// Response Interceptor to handle and log errors
axios.interceptors.response.use(function (response) {
  return response
}, function (error) {
  // Handle Error
  console.log(error)
  return Promise.reject(error)
})

export function api(recurso) {
  return axios.create({
    baseURL: `${axios.defaults.baseURL}/${recurso}/`
  })
}

export const httpClient = {
  universidades
}
