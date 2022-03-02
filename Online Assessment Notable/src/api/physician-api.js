import axios from 'axios'

export default {
  getPhysicianList () {
    return axios.get(`/api/physician/all`, {
      withCredentials: true
    })
  }
}