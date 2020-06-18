import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store'
import Home from '../pages/Home.vue'

const Login = resolve => {
  require.ensure(['../pages/Auth/Login.vue'], () => {
    resolve(require('../pages/Auth/Login.vue'))
  })
}
const Register = resolve => {
  require.ensure(['../pages/Auth/Register.vue'], () => {
    resolve(require('../pages/Auth/Register.vue'))
  })
}

const Faculty = resolve => {
  require.ensure(['../pages/Faculty/Faculty.vue'], () => {
    resolve(require('../pages/Faculty/Faculty.vue'))
  })
}
const CreateFaculty = resolve => {
  require.ensure(['../pages/Faculty/CreateFaculty.vue'], () => {
    resolve(require('../pages/Faculty/CreateFaculty.vue'))
  })
}
const CurrentFaculty = resolve => {
  require.ensure(['../pages/Faculty/CurrentFaculty.vue'], () => {
    resolve(require('../pages/Faculty/CurrentFaculty.vue'))
  })
}

const Nationality = resolve => {
  require.ensure(['../pages/Nationality/Nationality.vue'], () => {
    resolve(require('../pages/Nationality/Nationality.vue'))
  })
}
const CreateNationality = resolve => {
  require.ensure(['../pages/Nationality/CreateNationality.vue'], () => {
    resolve(require('../pages/Nationality/CreateNationality.vue'))
  })
}
const CurrentNationality = resolve => {
  require.ensure(['../pages/Nationality/CurrentNationality.vue'], () => {
    resolve(require('../pages/Nationality/CurrentNationality.vue'))
  })
}

const Student = resolve => {
  require.ensure(['../pages/Student/Student.vue'], () => {
    resolve(require('../pages/Student/Student.vue'))
  })
}
const CreateStudent = resolve => {
  require.ensure(['../pages/Student/CreateStudent.vue'], () => {
    resolve(require('../pages/Student/CreateStudent.vue'))
  })
}
const CurrentStudent = resolve => {
  require.ensure(['../pages/Student/CurrentStudent.vue'], () => {
    resolve(require('../pages/Student/CurrentStudent.vue'))
  })
}

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/faculty',
    name: 'Faculty',
    component: Faculty,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/createFaculty',
    name: 'CreateFaculty',
    component: CreateFaculty,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/faculty/:name&:id',
    name: 'CurrentFaculty',
    component: CurrentFaculty,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },

  {
    path: '/nationality',
    name: 'Nationality',
    component: Nationality,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/createNationality',
    name: 'CreateNationality',
    component: CreateNationality,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/nationality/:title&:id',
    name: 'CurrentNationality',
    component: CurrentNationality,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },

  {
    path: '/student',
    name: 'Student',
    component: Student,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/createStudent',
    name: 'CreateStudent',
    component: CreateStudent,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/student/:name&:id',
    name: 'CurrentStudent',
    component: CurrentStudent,
    async beforeEnter (to, from, next) {
      await store.dispatch('tryAutoLogin')
      if (store.state.auth.idToken) {
        next()
      } else {
        next('/login')
      }
    }
  },
  {
    path: '/login',
    name: 'Login',
    component: Login,
     async beforeEnter (to, from, next) {
       await store.dispatch('tryAutoLogin')
       if (store.state.auth.idToken) {
         next('/')
       } else {
         next()
       }
     }
  },
  {
    path: '/register',
    name: 'Register',
    component: Register,
     async beforeEnter (to, from, next) {
       await store.dispatch('tryAutoLogin')
       if (store.state.auth.idToken) {
         next('/')
       } else {
         next()
       }
     }
  },
  {
    path: '*',
    redirect: '/'
  }
]

export default new VueRouter({
  mode: 'history',
  routes,
  scrollBehavior () {
    window.scrollTo(0, 0)
  }
})
