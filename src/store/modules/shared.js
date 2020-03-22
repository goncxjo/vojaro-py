const state = {
    drawer: true,
    formTitle: '',
}

const getters = {
    formTitle: state => state.formTitle,
    drawer: state => state.drawer,
}

const actions = {

}

const mutations = {
    setTitle(state, payload) {
        let action = '';
        if (payload.routeName.includes('.new')) {
            action = 'Crear'
        }
        else if (payload.routeName.includes('.edit')) {
            action = 'Editar'
        }

        state.formTitle = action + ' ' + payload.entity
    },
    toggleDrawer(state) {
        state.drawer = !state.drawer
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
