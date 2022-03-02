<template>
<div class="main">
  <div class="physician-list">
    <header class="header"> {{header}} </header>
    <h1> Physicians </h1>
    <ul>
      <li class="physicianList" v-for="physician in physicianList" :key="physician.id" @click="getSchedule(physician.name, physician.id)"> {{physician.name}} </li>
    </ul>
  </div>
  <div class="physician-appointments">
    <h2 class="title"> {{selected}} </h2>
    <h3 class="email"> {{email}} </h3>
    <ag-grid-vue
      style="width: 100%; height: 80%; position: absolute; bottom: 0px;"
      class="ag-theme-alpine"
      :columnDefs="columnDefs"
      :rowData="schedule">
    </ag-grid-vue>
  </div>
</div>
</template>

<script>
import { AgGridVue } from "ag-grid-vue3";
import PhysicianApi from './api/physician-api'
import "ag-grid-community/dist/styles/ag-grid.css";
import "ag-grid-community/dist/styles/ag-theme-alpine.css";
export default {
   components: {
    AgGridVue,
  },
  computed: {
    email() {
      console.log('good lord');
      return this.selected.split(' ').slice(-1).join(' ') + "@notablehealth.com"

    }
  },
  created() {
    PhysicianApi.getPhysicianList().
    then(result => {
      this.physicianList = result.data
    }).
    catch(error => {
      console.log('Caught err')
      console.log(error);
    })
  },
  data () {
    return {
      selected: '',
      physicianList: [],
      header: "notable",
      schedule: [],
      columnDefs: [
        {headerName: '#', field: 'position'},
        {headerName: 'Name', field: 'patientName'},
        {headerName: 'Time', field: 'visitTime'},
        {headerName: 'Kind', field: 'visitType'},
      ]
    }
  },
  methods: {
    getSchedule(name, id) {
      this.selected = name;
    PhysicianApi.getPhysicianSchedule(id).
      then(result => {
        let res = result.data
        console.log('res: ', res);
        this.schedule = res.map((patient, index) => {
        return {
          position: index + 1,
          patientName: patient.patientName,
          visitTime: patient.visitTime,
          visitType: patient.visitType === 0 ? 'New Patient' : 'Follow-up'
        }
      })
      }).
      catch(error => {
        console.log('Caught err')
        console.log(error);
      })    
    }
  }
}
</script>

<style>
.email {
  text-align: left;
  margin-left: 1.2rem;
}
.title {
  font-size: 4rem;
  text-align: left;
  margin-left: 1rem;
  margin-bottom: 0.5rem;
}
h1 {
  margin-left: 1em;
}
.physicianList {
  transition: all .2s ease-in-out;
  cursor: pointer;
}

.physicianList:hover {
  transform: translateX(5rem);
}
.header {
  padding: 1rem 0rem 1rem 0rem;
  margin-left: .74em;
  width: 100%;
  text-align: left;
  color: blue;
  font-size: 3rem;
  font-weight: bold;
}

.main {
  height: 100vh;
  width: 100vw;
  display: flex;
  flex-direction: row;
  background-color: #F9F6F0;
  overflow: hidden;
}
.physician-list {
  /* padding: 1rem; */
  margin-left: 0;
  align-self: flex-start;
  width: 30vw;
  height: inherit; 
  background-color: #F0F0F0;
}

.physician-appointments {
  position: relative;
  background-color:red;
  width: 70vw;
  height: inherit; 
  background-color: white;
}
</style>
