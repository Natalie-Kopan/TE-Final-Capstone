<template>
  <section class="container" id = "app">
    <h1> Previous Activity</h1>
    <div v-for="activityLog of allActivityLog" v-bind:key="activityLog.logId">
      <div class = "card">
      <h2>Date: {{activityLog.dateOfActivity | formatDate}} </h2>
      <h2>Minutes Read: {{activityLog.minutesRead}}</h2>
    </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
  name: 'ActivityLog',
  data(){
    return {
      dateOfActivity: '',
    }
  },
  props: {
      isbn: Number
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
            console.error("Could not load books.", response);
            alert("Issue loading books");
          });
  }
}
</script>

<style>

</style>
