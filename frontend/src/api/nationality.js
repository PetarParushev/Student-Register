import axios from 'axios'

const instance = axios.create({
    baseURL: 'https://localhost:44372/api'
})

export function getNationalityById (nationalityId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.get(`Nationality/${nationalityId}`, { headers })
}

export function createNationality (formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.post('Nationality', formData, { headers })
}

export function updateNationality (nationalityId, formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.put(`Nationality/${nationalityId}`, formData, { headers })
}

export function deleteNationality (nationalityId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.delete(`Nationality/${nationalityId}`, { id: nationalityId , headers})
}

export default {
    getNationalities: (token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = instance.get('Nationality', { headers })
        return response
    },

    searchNationalities: (title, token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = instance.get('Nationality', { params: {query: title }, headers})
        return response
    }
}