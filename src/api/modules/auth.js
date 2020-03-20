import axios from 'axios'
import { config } from '@/api'

const http = axios.create(config)

export default {
    requestToken(user) {
        console.log(user)
        return http.post('tokens/', user)
    },
    revokeToken(user) {
        return http.delete('tokens/', user)
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