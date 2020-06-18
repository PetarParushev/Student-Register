import Vue from 'vue'
import Vuex from 'vuex'
import auth from '../../api/auth'
import router from '../../router'
import jwtDecode from 'jwt-decode'

Vue.use(Vuex)

export default {
  state: {
    idToken: null,
    username: null
  },
  mutations: {
    storeUser (state, userData) {
      state.idToken = userData.token
      state.username = userData.username
    },
    clearAuthData (state) {
      state.idToken = null
      state.username = null
    }
  },
  actions: {
    async register ({ dispatch }, formData) {
      await auth.register(formData)
      dispatch('login', formData)
    },

    async login ({ commit, dispatch }, authData) {

      const response = await auth.login(authData)
      const token = jwtDecode(response.data.token)
      const expirationDate = new Date(token.exp * 1000)

      localStorage.setItem('token', response.data.token)
      localStorage.setItem('userName', response.data.userName)
      localStorage.setItem('expirationDate', expirationDate)

      commit('storeUser', {
        token: response.data.token,
        username: response.data.userName
      })

      const now = new Date()
      dispatch('setLogoutTimer', expirationDate.getTime() - now.getTime())
      router.replace('/')
    },

    setLogoutTimer ({ commit }, milliseconds) {
      setTimeout(() => {
        commit('clearAuthData')
      }, milliseconds)
    },

    logout ({ commit }) {
      commit('clearAuthData')
      localStorage.removeItem('expirationDate')
      localStorage.removeItem('token')
      localStorage.removeItem('userName')
    },

    tryAutoLogin ({ commit, dispatch, state }) {
      const token = localStorage.getItem('token')
      if (!token || state.idToken) {
        return
      }

      const expirationDate = new Date(localStorage.getItem('expirationDate'))
      const now = new Date()
      if (now >= expirationDate) {
        return
      }

      const username = localStorage.getItem('userName')
      commit('storeUser', {
        token: token,
        username: username
      })

      dispatch('setLogoutTimer', expirationDate.getTime() - now.getTime())
    }
  },
  getters: {
    isAuthenticated: (state) => {
      return state.idToken !== null
    },
    token: (state) => {
      return state.idToken
    },
    username: (state) => {
      return state.username
    }
  }
}
