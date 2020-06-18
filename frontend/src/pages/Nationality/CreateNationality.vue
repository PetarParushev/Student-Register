<template>
  <div>
    <b-form @submit.prevent="onSubmit">
      <b-row class="row">
      <b-col sm="6" offset-sm="3">
      <b-form-group
        id="title-group"
        label="Title:"
        label-for="title-input"
      >
        <b-form-input
          id="title-input"
          v-model="title"
          required
          placeholder="Enter Title"
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
import { createNationality } from '../../api/nationality'
import router from '../../router'
import { mapGetters } from 'vuex'

export default {
    data () {
        return {
            title: ''
        }
    },
    methods: {
        async onSubmit() {
            const formData = {
                title: this.title
            }
            await createNationality(formData, this.token)
            router.replace('/nationality')
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