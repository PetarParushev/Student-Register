import axios from 'axios'

const instance = axios.create({
  baseURL: 'https://localhost:44372/api/Auth'
})

export function checkEmail (email) {
  return instance.get(`email/${email}`)
}

export function checkUsername (username) {
  return instance.get(`username/${username}`)
}

export default {
  register: formData => instance.post('register', formData),

  login: authData => instance.post('login', authData)
}