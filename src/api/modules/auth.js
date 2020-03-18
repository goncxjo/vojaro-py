import axios from 'axios'

const source = 'auth'

export default {
    requestToken(user) {
        return axios.post(`${source}/token`, user)
    },
    logout(user) {
        return axios.post(`${source}/logout`, user)
    },
}