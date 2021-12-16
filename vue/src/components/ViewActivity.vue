<template>
  <main>
        <h1 id="center-2"> Your Previous Activity</h1>

  <section class="row" id = "app">
    <div class="col-sm">
    </div>
    <!--div class="col-sm"-->
      <div>
        <div class="circle" v-for="activityLog of allActivityLog" v-bind:key="activityLog.userId">
          <div class="text">
            <h5 >You Read for {{activityLog.minutesRead}} minutes on {{activityLog.dateOfActivity | formatDate}} </h5>
            <p>Here's some things you noted: {{activityLog.notes}}</p>
            <p><small class="text-muted">{{activityLog.dateOfActivity | formatDate}}</small></p>
          </div>
        </div>
      </div>
    <!--/div-->
    <div class="col-sm">
    </div>
  </section>
  </main>
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

<style scoped>
.circle {
    background-color: #FFCA3A;
    width: 300px;
    height: 300px;
    border-radius: 50%;
    display: inline-block;
    text-align: center;
    margin:10px;
    overflow:hidden;
    padding:25px;
    position:relative;
}
.text{
  transform:translate(-50%,-50%);
  position:relative;
  top:50%;
  left:50%;
  font-size: 60%;
  color: black;
}
</style>
