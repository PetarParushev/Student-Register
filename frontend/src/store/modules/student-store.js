import Vue from 'vue'
import Vuex from 'vuex'
import api from '../../api/student'
import nationality from '../../api/nationality'
import faculty from '../../api/faculty'

Vue.use(Vuex)

export default {
    state: {
        students: [],
        nationalities: [],
        faculties: []
    },
    mutations: {
        setStudents (state, students) {
            state.students = students;
        },
        clearFaculties (state) {
            state.faculties = []
        },
        clearNationalities (state) {
            state.nationalities = []
        }
    },
    actions: {  
        async fetchStudents({commit}) {
            try {
                const students = await api.getStudents(localStorage.getItem('token'))
                commit('setStudents', students.data)
            }
            catch (error) { console.log(error) }
        },
        async searchStudents({commit}, searchString) {
            try {
                const students = await api.searchStudents(searchString, localStorage.getItem('token'))
                commit('setStudents', students.data)
            } catch (error) { console.log(error) }
        },
        async getNationality ({ state, commit }) {
            commit('clearNationalities')
            try {
              const nationalities = await nationality.getNationalities(localStorage.getItem('token'))
              nationalities.data.map(nationality => {
                state.nationalities.push({title: nationality.title, id: nationality.id})
              })
            } catch (error) { console.log(error) }
        },
        async getFaculty ({ state, commit }) {
            commit('clearFaculties')
            try {
              const faculties = await faculty.getFaculties(localStorage.getItem('token'))
              faculties.data.map(faculty => {
                state.faculties.push({id: faculty.id, name: faculty.name})
              })
            } catch (error) { console.log(error) }
        },
    },
    getters: {  
        students: (state) => {
            return state.students
        },
        getNationalities: (state) => {
            return state.nationalities
        },
        getFaculties: (state) => {
            return state.faculties
        }
    }
}