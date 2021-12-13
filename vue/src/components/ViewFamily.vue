<template>
  <section id = "app">
    <div v-for="familyMember of allFamily" v-bind:key="familyMember.username" class="card">
        <div class="card-contents">
          <h2>{{familyMember.username}}</h2>
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
      const familyMembersPromise = AuthService.displayFamilyMembers();
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
        });
    }
}
</script>