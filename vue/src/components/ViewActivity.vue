<template>
  <section class="container" id = "app">
    <div v-for="activityLog of allActivityLog" v-bind:key="activityLog.logId">
      <div class = "card">
      <h2>{{activityLog.bookTitle}}</h2>
      
      <!--h3 class="book-author">{{ book.author }}</h3-->
    </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    props: {
        isbn: Number
    },
    name: 'ActivityLog',
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
