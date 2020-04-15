import auth from '@/api/modules/auth'

const state = {
    user: null
}

const getters = {
    isAuthenticated(state) {
        return !!state.user
    } 
}

const actions = {
    login({ commit }, user) {
        commit('setUserData', user)
        return new Promise((resolve, reject) => {
            auth.requestToken(user)
            .then(({ data }) => {
                // TODO: refactorizar
                user.token = data.token
                user.avatar = data.avatar
                commit('setUserData', user)
                resolve()
            })
            .catch(err => {
                console.log(err)
                commit('clearUserData')
                reject(err)
            })
        })
    },
    logout({ commit }) {
        return auth.revokeToken()
            .then(() => {
                commit('clearUserData')
            })
    }
}

const mutations = {
    setUserData(state, user) {
        state.user = user
        auth.setUser(user)
        localStorage.setItem('user', JSON.stringify(user))
    },
    clearUserData() {
        localStorage.removeItem('user')
        location.reload()
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
