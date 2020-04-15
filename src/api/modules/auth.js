import axios from 'axios'
import { config } from '@/api'

const http = axios.create(config)

export default {
    requestToken(user) {
        return http({
            method: 'post',
            url: 'tokens/',
            data: user
        })
    },
    revokeToken() {
        return http({ 
            method: 'delete', 
            url: 'tokens/',
        })
    },
    setUser(user) {
        axios.defaults.headers.common['Authorization'] = `Bearer ${ user.token }`
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