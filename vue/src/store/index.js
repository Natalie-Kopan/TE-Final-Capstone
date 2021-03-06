import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')

let currentUser = null;
if ((localStorage.getItem('user') && localStorage.getItem('user') != 'undefined')) {
  currentUser = JSON.parse(localStorage.getItem('user'));
}

if(currentToken && currentToken != 'undefined') {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    books:[],
    prizes:[],
    activityLog:[],
    familyMembers:[],
    token: currentToken || '',
    user: currentUser || {} // If a user is an parent, their user.role will be 'role'
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    BOOKS_LOADED(state, books) {
      state.books = books;
    },
    ACTIVITY_LOADED(state, activityLog) {
      state.activityLog = activityLog;
    },
    ACTIVITY_ADDED(state, activityLog){
      state.activityLog.push(activityLog);
    },
    BOOK_ADDED(state, book) {
      state.books.push(book);
    },
    PRIZES_LOADED(state, prizes) {
      state.prizes = prizes;
    },
    PRIZES_ADDED(state, prize){
      state.prizes.push(prize);
    },
    DELETE_PRIZE(state, prizeId){
      let index = state.prizes.findIndex(prize =>prize.id === prizeId);
      state.prizes.splice(index, 1);
      console.log(state.prizes);
    },
    EDIT_PRIZE(state, payload){
      console.log(payload.prizeId);
      
      let index = state.prizes.findIndex(prize => prize.prizeId === payload.prizeId);
      console.log(index);
      console.log(state.prizes);
      if (index >= 0) {
        state.prizes.splice(index, 1, payload);
      }
    },
    FAMILY_MEMBERS_LOADED(state, familyMembers) {
      state.familyMembers = familyMembers;
    },
  }
})
