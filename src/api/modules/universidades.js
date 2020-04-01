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
    getPaginated(settings) {
        return http({ 
            method: 'get', 
            url: `${source}/`,
            params: {
                page: settings.page,
                perPage: settings.itemsPerPage,
                filters: JSON.stringify(settings.filters),
            }
        })
    },
    save(entity) {
        if (entity.id) {
            return http({
                method: 'put',
                url: `${source}/${entity.id}`,
                data: entity
            })
        }
        else {
            return http({
                method: 'post',
                url: `${source}/`,
                data: entity
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