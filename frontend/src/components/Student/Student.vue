<template>
    <div class="col-sm-12 col-md-4 col-lg-3" style="padding:5px" v-if="!deleted">
  <b-card
    no-body
    class="card"
    border-variant="info">

      <template v-slot:header>
        <h6 class="mb-0">Created on: {{ createdOn }}</h6>
      </template>

      <template v-slot:footer>
        <h6 class="mb-0">Updated on: {{ updatedOn }}</h6>
      </template>

    <b-card-body>
      <b-card-title>{{student.firstName}} {{student.lastName}}</b-card-title>
      <b-card-sub-title class="mb-2">Faculty Number: {{student.facultyNumber}}</b-card-sub-title>
      <b-card-text class="info">Nationality: {{ student.nationality.title }} </b-card-text>
      <b-card-text class="info">Faculty: {{ student.faculty.name }} </b-card-text>
    </b-card-body>

    <b-card-body>
    <router-link tag="button"
                    class="btn"
                    :to="{ name: 'CurrentStudent', params: { name: student.FirstName + student.LastName,
                                                            id: student.id}
                    }">Edit</router-link>
      <b-button class="btn" @click="deleteBtnClick">Delete</b-button>
    </b-card-body>
  </b-card>
</div>
</template>

<script>
import { deleteStudent } from '../../api/student'
import { mapGetters } from 'vuex'

export default {
    props: ['student'],
    data () {
        return {
            deleted: false,
            createdOn: `${new Date(this.student.createdOn).toDateString()} at ${new Date(this.student.createdOn).toLocaleTimeString()}`,
            updatedOn: `${new Date(this.student.updatedOn).toDateString()} at ${new Date(this.student.updatedOn).toLocaleTimeString()}`
        }
    },
    methods: {
        deleteBtnClick () {
          if (confirm('Are you sure you want to delete this student?')) {
            deleteStudent(this.student.id, this.token)
            this.deleted = true
          }
        }
    },
    computed: {
      ...mapGetters(['token'])
    }
}
</script>

<style scoped>
.btn{
  background-color: #383838e1;
  color: white;
  margin: 1%;
}
.card {
  max-width: 100%;
  max-height: 100%;
  margin: 7%;
}
.info {
  margin: 0;
}
</style>