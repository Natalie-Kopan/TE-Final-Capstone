<template>
  <section id = "app">
    <div v-for="familyMember of allFamily" v-bind:key="familyMember.username" class="card">
        <div class="card-contents">
          <h2>{{familyMember.username}}</h2>
          <button class="btn btn-primary" type ="submit" style="width:100%; bottom:0; margin-top:auto">
            <router-link v-bind:to="{name: 'ViewUserActivity', params: {userId: familyMember.userId}}" style="color:white">
              View User Activity
            </router-link>
        </button>
        </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    name: 'ViewFamily',
    computed: {
      allFamily() {
        return this.$store.state.familyMembers;
      },
    },
    created() {
      // Make a HTTP GET request and return a promise representing the operation
      const familyMembersPromise = AuthService.displayFamilyMembers(this.$route.params.userId);
      familyMembersPromise
        // 200 Status Codes
        .then(response => {
          console.log("GET Completed", response);
          const familyMembers = response.data;
          this.$store.commit('FAMILY_MEMBERS_LOADED', familyMembers);
        })
        // 400, 500, network issues, no internet, etc.
        .catch(response => {
          console.error("Could not load family members.", response);
          alert("Issue loading family members");
        });
    }
}
</script>