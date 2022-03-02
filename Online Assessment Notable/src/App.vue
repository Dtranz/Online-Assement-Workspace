<template>
<main class="main">
  <div class="physician-list">
    <header class="header"> {{header}} </header>
    <ul>
      <li v-for="physician in physicianList" :key="physician.id" @click="console.log('hello world')"> {{physician}} </li>
    </ul>
  </div>
  <div class="physician-appointments">
    <ol>
    </ol>
  </div>
</main>
</template>

<script>
import PhysicianApi from './api/physician-api'
// import PhysicianAppointments from './api/physician-appointments'
export default {
  created() {
    PhysicianApi.getPhysicianList().
    then(result => {
      console.log(result);
      this.physicianList = result
    })
  },
  data () {
    return {
      physicianList: [],
      header: "notable"
    }
  }
}
</script>

<style>
.header {
  padding: 1rem 0rem 1rem 0rem;
  margin-left: 5rem;
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
  background-color:red;
  width: 70vw;
  height: inherit; 
  background-color: white;
}
</style>
