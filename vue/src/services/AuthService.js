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

  displayActivityLog(isbn) {
    return axios.get(`/Activity/${isbn}`)
  },

  addActivity(activityLog) {
    return axios.post(`/Activity/${activityLog.isbn}`, activityLog)
  },

  addFamilyMember(user){
    return axios.post('/Family', user)
  },
  displayFamilyMembers(user){
    return axios.get('/Family', user)
  },
  addNewPrize(prize){
    return axios.post('/Prizes', prize);
  },
  displayPrizes(familyId){
    return axios.get('/Prizes', familyId);
  }

}
