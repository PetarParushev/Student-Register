<template>
  <div>
    <b-form @submit.prevent="onSubmit">
      <b-row class="row">
      <b-col sm="6" offset-sm="3">
      <b-form-group
        id="firstName-group"
        label="First Name:"
        label-for="firstName-input"
      >
        <b-form-input
          id="firstName-input"
          v-model="student.firstName"
          required
          placeholder="Enter first name:"
          maxlength="15"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="lastName-group"
        label="Last Name:"
        label-for="lastName-input"
      >
        <b-form-input
          id="lastName-input"
          v-model="student.lastName"
          required
          placeholder="Enter last name:"
          maxlength="15"
        ></b-form-input>
      </b-form-group>

    <!-- CHECK IF U CAN DO THIS IN DB -->
      <b-form-group
        id="facultyNumber-group"
        label="Faculty number:"
        label-for="facultyNumber-input"
      >
        <b-form-input
          id="facultyNumber-input"
          type="number"
          min="0"
          v-model="student.facultyNumber"
          required
          placeholder="Enter faculty number:"
          maxlength="6"
        ></b-form-input>
      </b-form-group>

      <label for="nationality-select">Nationality</label>
                <b-form-select
                  class="text-left"
                  id="nationality-select"
                  v-model="student.nationality.id"
                  :options= getNationalities
                  value-field="id"
                  text-field="title"
                  required
                ></b-form-select>

        <label for="faculty-select">Faculty</label>
                <b-form-select
                  class="text-left"
                  id="faculty-select"
                  v-model="student.faculty.id"
                  :options= getFaculties
                  value-field="id"
                  text-field="name"
                  required
                ></b-form-select>
        </b-col>
        </b-row>
        <b-col class="sm 4" offset-sm="3">
          <b-button type="submit">Update</b-button>
        </b-col>
    </b-form>
  </div>
</template>

<script>
import { getStudentById, updateStudent } from '../../api/student'
import { mapGetters, mapActions } from 'vuex'
import router from '../../router'

export default {
    created () {
        this.getStudent(this.$route.params.id)
        this.getNationality()
        this.getFaculty()
    },
    data () {
        return {
            student: {},
        }
    },
    methods: {
        ...mapActions(['getNationality', 'getFaculty']),
        async getStudent (studentId) {
            const response = await getStudentById(studentId, this.token)
            this.student = response.data
        },
        async onSubmit() {
            const formData = {
                firstName: this.student.firstName,
                lastName: this.student.lastName,
                facultyNumber: this.student.facultyNumber,
                nationality: this.student.nationality,
                faculty: this.student.faculty
            }
            await updateStudent(this.student.id, formData, this.token)
            router.replace('/student')
        }
    },
    computed: {
      ...mapGetters(['getNationalities', 'getFaculties', 'token'])
    }
}
</script>

<style scoped>
.row {
  margin: 5%;
}
.btn{
  background-color: #383838e1;
  color: white;
  width: 50%;
}
/* Chrome, Safari, Edge, Opera */
input::-webkit-outer-spin-button,
input::-webkit-inner-spin-button {
  -webkit-appearance: none;
  margin: 0;
}

/* Firefox */
input[type=number] {
  -moz-appearance: textfield;
}
</style>