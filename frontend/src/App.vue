<template>
  <div id="app">
    <app-header></app-header>
    <router-view></router-view>
    <app-go-top id="backToTop"></app-go-top>
  </div>
</template>
<script>
import Header from './components/Header.vue'
import GoTop from '@inotom/vue-go-top'

export default {
  name: 'app',
  components: {
    'app-header': Header,
    'app-go-top': GoTop
  }
}
</script>

<style>

</style>