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

  displayUserBookLibrary(){
    return axios.get('/book')
  },

}
