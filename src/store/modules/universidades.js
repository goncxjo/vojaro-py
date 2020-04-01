import universidades from '@/api/modules/universidades'

const state = {
    entity: {
      departamentos: []
    },
    entities: [],
    totalEntities: 0,
    filter: {
      codigo: '',
      nombre: ''
    },
}

const getters = {
    entity: state => state.entity,
    entities: state => state.entities,
    totalEntities: state => state.totalEntities,
    filteredCollection: state => {
      return state.entities.filter(u => {
        return u.codigo.toLowerCase().includes(state.filter.codigo) && u.nombre.toLowerCase().includes(state.filter.nombre)
      })
    }
}

const actions = {
  load ({ commit }, id) {
    if (id) {
      universidades.get(id)
      .then(r => r.data)
      .then(entity => {
        commit('set', entity)
      })
    } else {
      commit('clean')
    }
  },
  loadCollection ({ commit }) {
    universidades.get()
      .then(r => r.data)
      .then(entities => {
        commit('setCollection', entities)
      })
      .catch(e => {
          console.log(e)
      })
  },
  loadPaginatedCollection ({ commit }, settings) {
    return new Promise((resolve, reject) => {
      universidades.getPaginated(settings)
      .then(r => r.data)
      .then(result => {
        commit('setCollection', result.items)
        commit('setTotalCollection', result.total)
        resolve()
      })
      .catch(err => {
          console.log(err)
          reject(err)
      })
    })
  },
  save ({ }, payload) {
    universidades.save(payload)
      .then(response => response)
      .catch(e => {
          console.log(e)
    })
  },
  delete ({ commit, dispatch }, id) {
    universidades.delete(id)
    .then(response => response)
    commit('clean')
    dispatch('loadCollection')
  },
}

const mutations = {
    set(state, entity) {
      state.entity = entity
    },
    clean(state) {
      state.entity = {
        departamentos: []
      }
    },
    setCollection(state, entities) {
      state.entities = entities
      state.filteredCollection = entities
    },
    setTotalCollection(state, total) {
      state.totalEntities = total
    },
    cleanCollection(state) {
      state.entities.length = 0
    },
    filterCollection(state, filter) {
      state.filter.codigo = filter.codigo.toLowerCase()
      state.filter.nombre = filter.nombre.toLowerCase()
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
