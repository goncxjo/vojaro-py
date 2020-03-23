const state = {
    drawer: null,
    formTitle: '',
    formReadonly: null,
}

const getters = {
    drawer: state => state.drawer,
    formTitle: state => state.formTitle,
    formReadonly: state => state.formReadonly 
}

const actions = {

}

const mutations = {
    setTitle(state, payload) {
        let action = '';
        if (payload.routeName.includes('.new')) {
            action = 'Crear'
            state.formReadonly = false
        }
        else if (payload.routeName.includes('.view')) {
            action = 'Visualizar'
            state.formReadonly = true
        }
        else if (payload.routeName.includes('.edit')) {
            action = 'Editar'
            state.formReadonly = false
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
