import Vue from 'vue'
import Vuex from 'vuex'
import auth from './modules/auth-store'
import faculty from './modules/faculty-store'
import nationality from './modules/nationality-store'
import student from './modules/student-store'

Vue.use(Vuex)
export default new Vuex.Store({
  modules: {
    auth,
    faculty,
    nationality,
    student
  }
})
