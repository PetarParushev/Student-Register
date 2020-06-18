<template>
  <!-- Navbar -->
    <b-row>
      <b-navbar type="dark" variant="info" class="nav">
        <router-link to="/">
          <b-navbar-brand class="brand">Student Register</b-navbar-brand>
        </router-link>
        <b-navbar-nav>
          <b-col>
          <router-link to="/student" class="link">Students</router-link>
          <router-link to="/nationality" class="link">Nationalities</router-link>
          <router-link to="/faculty" class="link">Faculties</router-link>
          <router-link to="/login" class="link" v-if="!isAuthenticated">Login</router-link>
          <router-link to="/register" class="link" v-if="!isAuthenticated">Register</router-link>
          <router-link to="/" class="link" v-if="isAuthenticated" @click.native="logout">Logout</router-link>
          </b-col>
        </b-navbar-nav>
      </b-navbar>
    </b-row>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  methods: {
    ...mapActions(['logout'])
  },
  computed: {
    ...mapGetters(['isAuthenticated'])
  }
}

</script>

<style scoped>
#header {
  width: 100%;
  margin: 0;
  padding: 0;
}
.nav {
  width: 100%;
}
.link {
  text-decoration: none;
  padding: 8%;
  color: white;
}
.brand {
  padding-left: 2rem;
}
</style>
