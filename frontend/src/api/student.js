import axios from 'axios'

const instance = axios.create({
    baseURL: 'https://localhost:44372/api'
})

export function getStudentById (studentId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.get(`Student/${studentId}`, { headers })
}

export function createStudent (formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.post('Student', formData, { headers })
}

export function updateStudent (studentId, formData, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.put(`Student/${studentId}`, formData, { headers })
}

export function deleteStudent (studentId, token) {
    const headers = { Authorization: `Bearer ${token}` }
    return instance.delete(`Student/${studentId}`, { id: studentId, headers })
}

export default {
    getStudents: async (token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = await instance.get('Student', { headers })
        return response
    },

    searchStudents: async (facNumber, token) => {
        const headers = { Authorization: `Bearer ${token}` }
        const response = await instance.get('Student', { params: {query: facNumber }, headers})
        return response
    }
}