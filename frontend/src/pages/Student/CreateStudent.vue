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
          v-model="firstName"
          required
          placeholder="Enter first name"
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
          v-model="lastName"
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
          v-model="facultyNumber"
          required
          placeholder="Enter faculty number:"
          maxlength="6"
        ></b-form-input>
      </b-form-group>

      <label for="nationality-select">Nationality</label>
                <b-form-select
                  class="text-left"
                  id="nationality-select"
                  v-model="nationality"
                  required
                  :options="getNationalities"
                  value-field="id"
                  text-field="title"
                ></b-form-select>

                <label for="faculty-select">Faculty</label>
                <b-form-select
                  class="text-left"
                  id="faculty-select"
                  v-model="faculty"
                  required
                  :options= getFaculties
                  value-field="id"
                  text-field="name"
                ></b-form-select>
        </b-col>
        </b-row>
        <b-col class="sm 4" offset-sm="3">
      <b-button type="submit" class="btn">Create</b-button>
        </b-col>
    </b-form>
    
    
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import { createStudent } from '../../api/student'
import router from '../../router'

export default {
    async created () {
        await this.getFaculty()
        await this.getNationality()
        this.$forceUpdate();
    },
    data () {
        return {
            firstName: '',
            lastName: '',
            facultyNumber: '',
            nationality: '',
            faculty: '',
        }
    },
    methods: {
        async onSubmit() {
            const formData = {
                firstName: this.firstName,
                lastName: this.lastName,
                facultyNumber: parseInt(this.facultyNumber),
                nationalityId: this.nationality,
                facultyId: this.faculty
            }
            await createStudent(formData, this.token)
            router.replace('/student')
        },
        ...mapActions([
            'getNationality',
            'getFaculty'
        ])
    },
    computed: {
        ...mapGetters(['getNationalities', 'getFaculties', 'token', 'username'])
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