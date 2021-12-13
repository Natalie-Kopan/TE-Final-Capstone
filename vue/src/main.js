import Vue from 'vue'
import App from './App.vue'
import router from './router/index'
import store from './store/index'
import axios from 'axios'
import moment from 'moment'
import VueConfetti from 'vue-confetti'

Vue.config.productionTip = false
Vue.filter('formatDate', function(value) {
  if(value) {
    return moment (String(value)).format('MM/DD/YYYY')
  }
});

Vue.use(VueConfetti)

axios.defaults.baseURL = process.env.VUE_APP_REMOTE_API;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
