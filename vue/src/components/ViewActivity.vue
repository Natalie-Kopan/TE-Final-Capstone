<template>
  <section class="container" id = "app">
    <h1> Your Previous Activity</h1>
    <div class="card-deck">
      <div class="activity-card" v-for="activityLog of allActivityLog" v-bind:key="activityLog.userId">
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
    }
  },
  props: {
      isbn: String
  },
  computed: {
      allActivityLog() {
          return this.$store.state.activityLog;
      },
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
            console.error("Could not load activity.", response);
          });
  }
}
</script>

<style>


</style>
