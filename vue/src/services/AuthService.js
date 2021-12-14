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
  displayUserLibraryByUserId(userId){
    return axios.get(`/book/${userId}`)
  },
  displayActivityLog(isbn) {
    return axios.get(`/Activity/${isbn}`)
  },
  displayUserActivityLog(userId) {
    return axios.get(`/Activity/user/${userId}`)
  },
  displayBookActivityByUser(userId, isbn){
    return axios.get(`Activity/${userId}/${isbn}`)
  },
  addActivity(activityLog) {
    return axios.post(`/Activity/${activityLog.isbn}`, activityLog)
  },
  addActivityByUserId(activityLog, userId){
    return axios.post(`/Activity/${userId}/${activityLog.isbn}`, activityLog)
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
  },
  deletedPrize(prizeId){
    return axios.delete(`/Prizes/${prizeId}`);
  },
  editPrize(prize){
    console.log(prize);
    return axios.put('/Prizes', prize);
  } 
}
