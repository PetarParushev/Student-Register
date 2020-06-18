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
          v-model="name"
          required
          placeholder="Enter name"
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
          v-model="city"
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
          v-model="address"
          required
          placeholder="Enter address:"
          maxlength="30"
        ></b-form-input>
      </b-form-group>
      </b-col>
      </b-row>
      <b-col class="sm 4" offset-sm="3">
      <b-button type="submit" class="btn">Create</b-button>
      </b-col>
    </b-form>
  </div>
</template>

<script>
import { createFaculty } from '../../api/faculty'
import router from '../../router'
import { mapGetters } from 'vuex'

export default {
    data () {
        return {
            name: '',
            city: '',
            address: ''
        }
    },
    methods: {
        async onSubmit() {
            const formData = {
                name: this.name,
                city: this.city,
                address: this.address
            }
            await createFaculty(formData, this.token)
            router.replace('/faculty')
        }
    },
    computed: {
      ...mapGetters(['token'])
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