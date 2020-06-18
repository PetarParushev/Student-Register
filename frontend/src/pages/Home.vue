<template>
<div>
  <div class="center">
    <h1>Welcome to Student Register</h1>
    <h6>(Scroll down for more!)</h6>
  </div>
  <footer>(That's it, nothing more to read here! ----------> Go back to the top!)</footer>
</div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  created() {
    this.tryAutoLogin();
  },
  methods: {
        ...mapActions([
            'tryAutoLogin'
        ])
    }
}
</script>

<style scoped>
.center {
  padding: 30%;
  padding-top: 40%;
}
footer {
  font-weight: bolder;
  padding-left: 65%;
  padding-bottom: 5%;
}
</style>
