import { httpClient } from '@/api'

const state = {
    id: 0,
    entidad: {
        id: 0,
        codigo: '',
        nombre: ''
    },
    entidades: []
}

const getters = {
    entidad: state => state.entidad,
    entidades: state => state.entidades
}
22
const actions = {
    cargar ({ commit, state }) {
      if (state.id) {
        httpClient.universidades
        .obtenerPorId(state.id)
        .then(r => r.data)
        .then(entidad => {
          commit('SETEAR_ENTIDAD', entidad)
        })
      } else {
        commit('LIMPIAR_ENTIDAD')
      }
    },
    cargarLista ({ commit }) {
      httpClient.universidades
        .obtenerTodos()
        .then(r => r.data)
        .then(entidades => {
          commit('SETEAR_ENTIDADES', entidades)
        })
        .catch(e => {
            console.log(e)
        })
    },
    guardar ({ commit, state }) {
        let payload = {
            codigo: state.entidad.codigo,
            nombre: state.entidad.nombre,
        }

        if (state.entidad.id) {
            payload.id = state.entidad.id
        }
  
        httpClient.universidades
            .guardar(payload)
            .then(response => {
                commit('AGREGAR_ENTIDAD', response.data)
                commit('LIMPIAR_ENTIDAD')
                return response
            }).catch(e => {
                console.log(e)
            })

    },
    limpiar ({ commit }) {
      commit('LIMPIAR_ENTIDAD')
    }
}

const mutations = {
    SETEAR_ID(state, id) {
      state.id = id
    },
    SETEAR_ENTIDAD(state, entidad) {
      state.entidad = entidad
    },
    SETEAR_ENTIDADES(state, entidades) {
      state.entidades = entidades
    },
    AGREGAR_ENTIDAD(state, entidadObject) {
      state.entidades.push(entidadObject)
    },
    ACTUALIZAR_ENTIDAD(state, entidad) {
        const entidadObject = {
            id: entidad.id,
            codigo: entidad.codigo,
            nombre: entidad.nombre,
        }
        state.entidades.push(entidadObject)
    },
    LIMPIAR_ENTIDAD(state) {
        state.entidad = {
            id: 0,
            codigo: '',
            nombre: ''
        }
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
