import axios from 'axios'

const source = 'universidades'

export default {
    get(id) {
        if (id) {
            return axios.get(`${source}/${id}`)
        }
        else {
            return axios.get(source)
        }
    },
    save(entity) {
        let payload = {
            codigo: entity.codigo,
            nombre: entity.nombre,
        }

        if (entity.id) {
            return axios.put(`${source}/${entity.id}`, payload)
        }
        else {
            return axios.post(source, payload)
        }
    },
}