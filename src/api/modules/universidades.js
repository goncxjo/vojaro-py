import axios from 'axios'
import { config } from '@/api'

config.baseURL = '/api/universidades/'
const http = axios.create(config)

export default {
    get(id) {
        if (id) {
            return http.get(`${id}`)
        }
        else {
            return http.get()
        }
    },
    save(entity) {
        let payload = {
            codigo: entity.codigo,
            nombre: entity.nombre,
        }

        if (entity.id) {
            return http.put(`${entity.id}`, payload)
        }
        else {
            return http.post(payload)
        }
    },
}