import auth from '@/api/modules/auth'

const state = {
    // TODO: ver esto
    token: localStorage.getItem('user-token') || '',
    status: '',
}

const getters = {
    // TODO: ver esto
    isAuthenticated: state => !!state.token,
    authStatus: state => state.status,
}

const actions = {
    login({ commit }, user) {
        return new Promise((resolve, reject) => {
            commit('login', user)
            auth.requestToken(user)
            .then(response => {
                const token = response.data.token
                localStorage.setItem('user-token', token)
                // axios.defaults.headers.common['Authorization'] = token;
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
            resolve()
        })
    }
}

const mutations = {
    login(state, user) {
        auth.setUser({
            username: user.username,
            password: user.password,
        })
        state.status = 'loading'
    },
    success(state, token) {
        state.status = 'success'
        state.token = token
    },
    error(state) {
        auth.cleanUser()
        state.status = 'error'
    },
    logout(state) {
        // axios.defaults.headers.common['Authorization'] = '';
        state.status = ''
        state.token = ''
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
