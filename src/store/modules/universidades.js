import { httpClient } from '@/api'

const state = {
    entidad: {
      id: 0,
      codigo: '',
      nombre: ''
    },
    filtro: {
      codigo: '',
      nombre: ''
    },
    entidades: [],
}

const getters = {
    entidad: state => state.entidad,
    entidades: state => state.entidades,
    entidadesFiltradas: state => {
      return state.entidades.filter(u => {
        return u.codigo.toLowerCase().includes(state.filtro.codigo) && u.nombre.toLowerCase().includes(state.filtro.nombre)
      })
    }
}

const actions = {
    cargar ({ commit }, id) {
      if (id) {
        httpClient.universidades
        .obtenerPorId(id)
        .then(r => r.data)
        .then(entidad => {
          commit('setear', entidad)
        })
      } else {
        commit('limpiarEntidad')
      }
    },
    cargarLista ({ commit }) {
      httpClient.universidades
        .obtenerTodos()
        .then(r => r.data)
        .then(entidades => {
          commit('setearLista', entidades)
        })
        .catch(e => {
            console.log(e)
        })
    },
    guardar ({ }, entidad) {
      let payload = {
          id: entidad.id,
          codigo: entidad.codigo,
          nombre: entidad.nombre,
      }

      httpClient.universidades
          .guardar(payload)
          .then(response => response)
          .catch(e => {
              console.log(e)
          })
    }
}

const mutations = {
    setear(state, entidad) {
      state.entidad = entidad
    },
    setearLista(state, entidades) {
      state.entidades = entidades
      state.entidadesFiltradas = entidades
    },
    limpiarEntidad(state) {
      state.entidad = {
          id: 0,
          codigo: '',
          nombre: ''
      }
    },
    filtrar(state, filtro) {
      state.filtro.codigo = filtro.codigo.toLowerCase()
      state.filtro.nombre = filtro.nombre.toLowerCase()
    }
}

export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations
  }
