import axios from 'axios'

export default {
  getPhysicianList (physicianId) {
    return axios.get(`/api/physician/all`)
  }
}