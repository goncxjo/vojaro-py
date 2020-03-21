import axios from 'axios'
import { config } from '@/api'

const source = '/universidades'
const http = axios.create(config)

export default {
    get(id) {
        return http({ 
            method: 'get', 
            url: `${source + (id ? '/' + id : '')}`
        })
    },
    save(entity) {
        let payload = {
            codigo: entity.codigo,
            nombre: entity.nombre,
        }

        if (entity.id) {
            return http({
                method: 'put',
                url: `${source}/${entity.id}`,
                data: payload
            })
        }
        else {
            return http({
                method: 'post',
                url: `${source}/`,
                data: payload
            })
        }
    },
    delete(id) {
        return http({ 
            method: 'delete', 
            url: `${source}/${id}`,
        })
    },
}