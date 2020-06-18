import Vue from 'vue'
import Vuex from 'vuex'
import api from '../../api/faculty'

Vue.use(Vuex)

export default {
    state: {
        faculties: []
    },
    mutations: {
        setFaculties (state, faculties) {
            state.faculties = faculties;
        }
    },
    actions: {  
        async fetchFaculties({ commit }) {
            try {
                const faculties = await api.getFaculties(localStorage.getItem('token'))
                console.log(faculties)
                commit('setFaculties', faculties.data)
            }
            catch (error) { console.log(error) }
        },
        async searchFaculties({commit}, searchString) {
            try {
                const faculties = await api.searchFaculties(searchString, localStorage.getItem('token'))
                commit('setFaculties', faculties.data)
            } catch (error) { console.log(error) }
        }
    },
    getters: {  
        faculties: (state) => {
            return state.faculties
        }
    }
}