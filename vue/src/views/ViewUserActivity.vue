<template>
  <section class="activity container" id = "app">
    <h1 id="center"> <i class="fas fa-star"/> {{getUserName}} Activity <i class="fas fa-star" /> </h1>
    <div v-for="activityLog of allActivityLog" v-bind:key="activityLog.logId" class="activity-card">
      <!--<img src="..." class="card-img-top" alt="...">-->
      <div class="card-body">
        <h5 class="card-title">This user read for {{activityLog.minutesRead}} minutes on {{activityLog.dateOfActivity | formatDate}} </h5>
        <p class="card-text">Here's some things you noted during this read: {{activityLog.notes}}</p>
        <p class="card-text"><small class="text-muted">{{activityLog.dateOfActivity | formatDate}}</small></p>
      </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
  name: 'ViewUserActivity',
  data(){
    return {
      userId: '',
    }
  },
  computed: {
    allActivityLog() {
          return this.$store.state.activityLog;
      },
      getUserName(){
        return this.$store.state.familyMembers.find(f => f.userId === this.userId).username
      }
    },
    created() {
      this.userId = +this.$route.params.userId
      // Make a HTTP GET request and return a promise representing the operation
      const activityLogPromise = AuthService.displayUserActivityLog(this.userId)
      activityLogPromise
        // 200 Status Codes
        .then(response => {
          console.log("GET Completed", response);
          const activityLog = response.data;
          this.$store.commit('ACTIVITY_LOADED', activityLog);
        })
        // 400, 500, network issues, no internet, etc.
        .catch(response => {
          console.error("Could not load activities.", response);
          alert("Issue loading activities");
        });
  }
}
</script>

<style>

.card {
  padding: 5px;
}
</style>
