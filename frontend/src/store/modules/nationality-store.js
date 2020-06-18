import Vue from 'vue'
import Vuex from 'vuex'
import api from '../../api/nationality'

Vue.use(Vuex)

export default {
    state: {
        nationalities: []
    },
    mutations: {
        setNationalities (state, nationalities) {
            state.nationalities = nationalities
        }
    },
    actions: {
        async fetchNationalities({commit}) {
            try {
                const nationalities = await api.getNationalities(localStorage.getItem('token'))
                commit('setNationalities', nationalities.data)
            } catch (error) { console.log(error) }
        },
        async searchNationalities({commit}, searchString) {
            try {
                const nationalities = await api.searchNationalities(searchString, localStorage.getItem('token'))
                commit('setNationalities', nationalities.data)
            } catch (error) { console.log(error) }
        }
    },
    getters: {
        nationalities: (state) => {
            return state.nationalities
        }
    }
}