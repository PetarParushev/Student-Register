<template>
  <div>
    <b-form @submit.prevent="onSubmit">
      <b-row class="row">
      <b-col sm="6" offset-sm="3">
      <b-form-group
        id="name-group"
        label="Name:"
        label-for="name-input"
      >
        <b-form-input
          id="name-input"
          v-model="faculty.name"
          required
          placeholder="Enter name:"
          maxlength="30"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="city-group"
        label="City:"
        label-for="city-input"
      >
        <b-form-input
          id="city-input"
          v-model="faculty.city"
          required
          placeholder="Enter city:"
          maxlength="30"
        ></b-form-input>
      </b-form-group>

      <b-form-group
        id="address-group"
        label="Address:"
        label-for="address-input"
      >
        <b-form-input
          id="address-input"
          v-model="faculty.address"
          required
          placeholder="Enter address:"
          maxlength="30"
        ></b-form-input>
      </b-form-group>
      </b-col>
      </b-row>
      <b-col class="sm 4" offset-sm="3">
      <b-button type="submit" class="btn">Update</b-button>
      </b-col>
    </b-form>
  </div>
</template>

<script>
import { getFacultyById, updateFaculty } from '../../api/faculty'
import router from '../../router'
import { mapGetters } from 'vuex'

export default {
    created () {
        this.getFaculty(this.$route.params.id)
    },
    data () {
        return {
            faculty: {},
        }
    },
    methods: {
        async getFaculty (facultyId) {
            const response = await getFacultyById(facultyId, this.token)
            this.faculty = response.data
        },
        async onSubmit() {
            const formData = {
                name: this.faculty.name,
                city: this.faculty.city,
                address: this.faculty.address
            }
            await updateFaculty(this.faculty.id, formData, this.token)
            router.replace('/faculty')
        }
    },
    computed: {
      ...mapGetters([
            'token'
        ])
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
</style>