<template>
    <div>
        <h1>Faculties</h1>
        <b-row>
            <b-col class="sm 4" offset-sm="4">
            <router-link tag="button"
                    class="btn createBtn"
                    :to="{ name: 'CreateFaculty'}">Create new</router-link>
            </b-col>
        </b-row>
        <b-row>
            <b-col sm="6" offset-sm="3">
              <b-form-group
                class="search"
                id="search-group"
                label="Search by name:"
                label-for="search-input">
                <b-form-input class="text-left"
                  id="search-input"
                  type="text"
                  v-model="search"
                  @keyup="searchFaculties(search)"
                  placeholder="Enter name"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
        <app-faculty-grid :faculties="faculties"></app-faculty-grid>
    </div>
</template>

<script>
import FacultyGrid from '../../components/Faculty/FacultyGrid.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
    created() {
        this.fetchFaculties()
    },
    data() {
        return {
            search: ''
        }
    },
    components: {
        appFacultyGrid: FacultyGrid
    },
    computed: {
        ...mapGetters([
            'faculties'
        ])
    },
    methods: {
        ...mapActions([
            'fetchFaculties',
            'searchFaculties'
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