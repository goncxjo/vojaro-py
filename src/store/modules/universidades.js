import { httpClient } from '@/api'

const state = {
    entidad: {
        codigo: '',
        nombre: ''
    },
    entidades: []
}

const getters = {
    entidad: state => state.entidad,
    entidades: state => state.entidades
}

const actions = {
    cargar ({ commit }, { id }) {
        console.log(id)
      httpClient.universidades
        .obtenerPorId(id)
        .then(r => r.data)
        .then(entidad => {
          commit('SETEAR_ENTIDADES', entidad)
        })
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
        console.log('entidad', state)
        let payload = {
            codigo: state.entidad.codigo,
            nombre: state.entidad.nombre,
        }

        if (state.entidad.id) {
            payload.id = state.entidad.id
        }
  
        httpClient.universidades
            .guardar(payload)
            .then(r => r.data)
            .then(nuevaEntidad => {
                console.log(nuevaEntidad)       
                commit('AGREGAR_ENTIDAD', nuevaEntidad)
                commit('LIMPIAR_ENTIDAD', nuevaEntidad)
            }).catch(e => {
                console.log(e)
            })

    },
    limpiar ({ commit }) {
      commit('LIMPIAR_ENTIDAD')
    }
}

const mutations = {
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
