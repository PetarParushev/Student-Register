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
      <b-card-title>{{nationality.title}}</b-card-title>
    </b-card-body>

    <b-card-body>
    <router-link tag="button"
                    class="btn"
                    :to="{ name: 'CurrentNationality', params: { title: nationality.title,
                                                            id: nationality.id}
                    }">Edit</router-link>
      <b-button class="btn" @click="deleteBtnClick">Delete</b-button>
    </b-card-body>
  </b-card>
</div>
</template>

<script>
import { deleteNationality } from '../../api/nationality'
import { mapGetters } from 'vuex'

export default {
    props: ['nationality'],
    data () {
        return {
            deleted: false,
            createdOn: `${new Date(this.nationality.createdOn).toDateString()} at ${new Date(this.nationality.createdOn).toLocaleTimeString()}`,
            updatedOn: `${new Date(this.nationality.updatedOn).toDateString()} at ${new Date(this.nationality.updatedOn).toLocaleTimeString()}`
        }
    },
    methods: {
        deleteBtnClick () {
          if (confirm('Are you sure you want to delete this nationality?')) {
            deleteNationality(this.nationality.id, this.token)
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
</style>