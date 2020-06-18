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
          v-model="nationality.title"
          required
          placeholder="Enter Title:"
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
import { getNationalityById, updateNationality } from '../../api/nationality'
import router from '../../router'
import { mapGetters } from 'vuex'

export default {
    created () {
        this.getNationality(this.$route.params.id)
    },
    data () {
        return {
            nationality: {},
        }
    },
    methods: {
        async getNationality (nationalityId) {
            const response = await getNationalityById(nationalityId, this.token)
            this.nationality = response.data
        },
        async onSubmit() {
            const formData = {
                title: this.nationality.title
            }
            await updateNationality(this.nationality.id, formData, this.token)
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