import axios from 'axios'

const http = axios.create({
  baseURL: 'https://localhost:7253/', 
  headers: {
    'Content-Type': 'application/json'
  }
})

export default http