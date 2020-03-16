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
        let payload = {
            codigo: entidad.codigo,
            nombre: entidad.nombre,
        }

        if (entidad.id) {
            return axios.put(`${recurso}/${entidad.id}`, payload)
        }
        else {
            return axios.post(recurso, payload)
        }        
    },
}