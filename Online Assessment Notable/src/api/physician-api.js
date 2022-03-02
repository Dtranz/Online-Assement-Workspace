import axios from 'axios'

export default {
  getPhysicianList () {
    return axios.get(`/api/all`)
  },
  getPhysicianSchedule (id) {
    return axios.get(`/api/${id}`)
  }
}