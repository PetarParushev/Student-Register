<template>
    <div class="row">
        <app-nationality :key="nationality.id" v-for="nationality in nationalities" :nationality="nationality"></app-nationality>
    </div>
</template>

<script>
import Nationality from './Nationality'
export default {
  props: ['nationalities'],
  components: {
    appNationality: Nationality
  }
}
</script>

<style scoped>

</style>
