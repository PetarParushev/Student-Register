<template>
    <div>
        <h1>Nationalities</h1>
        <b-row>
            <b-col class="sm 4" offset-sm="4">
                <router-link tag="button"
                    class="btn createBtn"
                    :to="{ name: 'CreateNationality'}">Create new</router-link>
            </b-col>
            <b-col sm="6" offset-sm="3">
              <b-form-group
                class="search"
                id="search-group"
                label="Search by title:"
                label-for="search-input">
                <b-form-input class="text-left"
                  id="search-input"
                  type="text"
                  v-model="search"
                  @keyup="searchNationalities(search)"
                  placeholder="Enter title"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
        <app-nationality-grid :nationalities="nationalities"></app-nationality-grid>
    </div>
</template>

<script>
import NationalityGrid from '../../components/Nationality/NationalityGrid.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
    created() {
        this.fetchNationalities()
    },
    data() {
        return {
            search: ''
        }
    },
    components: {
        appNationalityGrid: NationalityGrid
    },
    computed: {
        ...mapGetters([
            'nationalities'
        ])
    },
    methods: {
        ...mapActions([
            'fetchNationalities',
            'searchNationalities'
        ])
    }
}
</script>

<style scoped>
h1 {
    text-align: center;
    margin: 3%;
}
.btn{
  background-color: #383838e1;
  color: white;
  margin: 2%;
}
.createBtn {
    width: 50%;
    margin-left: 0;
}
</style>