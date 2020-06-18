<template>
    <div class="row">
        <app-student :key="student.id" v-for="student in students" :student="student"></app-student>
    </div>
</template>

<script>
import Student from './Student'
export default {
  props: ['students'],
  components: {
    appStudent: Student
  }
}
</script>

<style scoped>

</style>
