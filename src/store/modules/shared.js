const state = {
    formTitle: '',
}

const getters = {
    formTitle: state => state.formTitle
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
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
