<template>
    <div class="row">
        <app-faculty :key="faculty.id" v-for="faculty in faculties" :faculty="faculty"></app-faculty>
    </div>
</template>

<script>
import Faculty from './Faculty'
export default {
  props: ['faculties'],
  components: {
    appFaculty: Faculty
  }
}
</script>

<style scoped>

</style>
