import axios from 'axios'
import { httpClient } from '@/api'

const state = {
    token: localStorage.getItem('user-token') || '',
    status: '',
}

const getters = {
    isAuthenticated: state => !!state.token,
    authStatus: state => state.status,
}

const actions = {
    login({ commit }, user) {
        return new Promise((resolve, reject) => {
            commit('login', user)
            httpClient.auth
            .requestToken(user)
            .then(response => {
                const token = response.data.token
                localStorage.setItem('user-token', token)

                axios.interceptors.request.use(function (config) {
                    config.headers['Authorization'] = token
                    return config
                  })

                  commit('success', token)
                resolve(response)
            })
            .catch(err => {
                commit('error', err)
                localStorage.removeItem('user-token')
                reject(err)
            })
        })
    },
    logout({ commit }) {
        return new Promise((resolve, reject) => {
            commit('logout')
            localStorage.removeItem('user-token')
            delete axios.defaults.headers.common['Authorization']
            resolve()
        })
    }
}

const mutations = {
    login(state, user) {
        axios.defaults.auth = {
            username: user.username,
            password: user.password,
        }
        state.status = 'loading'
    },
    success(state, token) {
        state.status = 'success'
        state.token = token
    },
    error(state) {
        axios.defaults.auth = { }
        state.status = 'error'
    },
    logout(state) {
        axios.defaults.auth = { }
        state.status = ''
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
