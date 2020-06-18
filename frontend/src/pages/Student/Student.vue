<template>
    <div>
        <h1>Students</h1>
        <b-row>
              <b-col class="sm 4" offset-sm="4">
              <router-link tag="button"
                    class="btn createBtn"
                    :to="{ name: 'CreateStudent'}">Create new</router-link>
              </b-col>
          </b-row>
        <b-row>
            <b-col sm="6" offset-sm="3">
              <b-form-group
                class="search"
                id="search-group"
                label="Search by Faculty Number:"
                label-for="search-input">
                <b-form-input
                  id="search-input"
                  type="number"
                  v-model="search"
                  @keyup="searchStudents(search)"
                  placeholder="Enter faculty Number"
                ></b-form-input>
              </b-form-group>
            </b-col>
          </b-row>
        <app-student-grid :students="students"></app-student-grid>
    </div>
</template>

<script>
import StudentGrid from '../../components/Student/StudentGrid.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
    created() {
        this.fetchStudents()
    },
    data () {
        return {
            search: ''
        }
    },
    components: {
        appStudentGrid: StudentGrid
    },
    computed: {
        ...mapGetters([
            'students'
        ])
    },
    methods: {
        ...mapActions([
            'fetchStudents',
            'searchStudents'
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