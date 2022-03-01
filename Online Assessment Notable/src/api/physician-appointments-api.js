import axios from 'axios'

export default {
  getPhysicianAppointments (physicianId) {
    return axios.get(`/api/physician-appointments/${physicianId}`)
  }
}