import axios from 'axios'

const recurso = 'universidades'

export default {
    obtenerTodos() {
        return axios.get(recurso)
    },
    obtenerPorId(id) {
        return axios.get(`${recurso}/${id}`)
    },
    guardar(entidad) {
        if (entidad.id) {
            return axios.put(`${recurso}/${id}`, entidad)
        }
        else {
            return axios.post(recurso, entidad)
        }        
    },
}