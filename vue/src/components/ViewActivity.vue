<template>
  <section class="container" id = "app">
    <h1> Previous Activity</h1>
    <div v-for="activityLog of allActivityLog" v-bind:key="activityLog.userId">
      <div class = "card" :color="colorChange">,
      <h2>Date: {{activityLog.dateOfActivity | formatDate}} </h2>
      <h2>Minutes Read: {{activityLog.minutesRead}}</h2>
    </div>
    </div>

    <div class="card-deck">
      <div class="card">
      <!--<img src="..." class="card-img-top" alt="...">-->
      <div class="card-body">
        <h5 class="card-title">You Read for {{activityLog.minutesRead}} minutes on {{activityLog.dateOfActivity | formatDate}} </h5>
        <p class="card-text">Here's some things you noted during this read: {{activityLog.notes}}</p>
        <p class="card-text"><small class="text-muted">{{activityLog.dateOfActivity | formatDate}}</small></p>
    </div>
    </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService.js';

export default {
  name: 'ActivityLog',
  data(){
    return {
      dateOfActivity: '',
      activityLog: '',
      lowminutes: false,
      medMinutes: false,
      highMinutes: true,
    }
  },
  props: {
      isbn: Number
  },
  computed: {
      allActivityLog() {
          return this.$store.state.activityLog;
      },
      colorChange() {
         if(this.activityLog.minutesRead <= 15){
          return '#1982C4'
         }
         else if (this.activityLog.minutesRead > 15 && this.activityLog.minutesRead <=30){
           return '#FFCA3A'
         }
         else {
           return '#8AC926'
         }
      }
   },
     created() {
          // Make a HTTP GET request and return a promise representing the operation
          const activityLogPromise = AuthService.displayActivityLog(this.isbn)
          activityLogPromise
          // 200 Status Codes
          .then(response => {
          console.log("GET Completed", response);
          const activityLog = response.data;
          this.$store.commit('ACTIVITY_LOADED', activityLog);
          })
          // 400, 500, network issues, no internet, etc.
          .catch(response => {
            console.error("Could not load books.", response);
            alert("Issue loading books");
          });
  }
}
</script>

<style>

.card {
  padding: 5px;
}
</style>
