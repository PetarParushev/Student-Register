import axios from 'axios'

const instance = axios.create({
    baseURL: 'https://localhost:44372/api'
})

export function getFacultyById (facultyId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.get(`Faculty/${facultyId}`, { headers })
}

export function createFaculty (formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.post('Faculty', formData, { headers })
}

export function updateFaculty (facultyId, formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.put(`Faculty/${facultyId}`, formData, { headers })
}

export function deleteFaculty (facultyId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.delete(`Faculty/${facultyId}`, { id: facultyId, headers})
}

export default {
    getFaculties: async (token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = await instance.get('Faculty', { headers })
        return response
    },
    
    searchFaculties: async (name, token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = await instance.get('Faculty', { params: {query: name }, headers})
        return response
    }
}