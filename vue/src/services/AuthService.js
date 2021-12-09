import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/login/register', user)
  },

  addNewBook(book){
    return axios.post('/book', book)
  },

  displayUserBookLibrary(userId){
    return axios.get('/book', userId)
  },

  /*displayReadingActivityLog(userId) {
    return axios.get('/readingactivitylog', userId)
  }*/

  addFamilyMember(user){
    return axios.post('/Login/addFamily', user)
  },

}