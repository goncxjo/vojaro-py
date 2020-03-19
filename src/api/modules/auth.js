import axios from 'axios'
import { config } from '@/api'

config.baseURL = '/api/auth/'
const http = axios.create(config)

export default {
    requestToken(user) {
        return http.post('token', user)
    },
    logout(user) {
        return http.post('logout', user)
    },
    setUser(user) {
        axios.defaults.auth = {
            username: user.username,
            password: user.password,
        }
    },
    cleanUser() {
        axios.defaults.auth = {
            username: '',
            password: '',
            }
    },
}