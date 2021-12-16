<template>
  <div class="home container">
    <div>
      <h1 id="center-3"><i class="fas fa-user-astronaut"></i> Welcome {{this.user.username}} <i class="fas fa-user-astronaut"></i></h1>
      <div>
        <Library  />
        <!--<ViewActivityByUserId v-bind:userId="userId"/>-->
        <FamilyPrizes/>
      </div>
    </div>   
  </div>
</template>

<script>
//import AuthService from "../services/AuthService";
//import ViewActivityByUserId from "../components/ViewActivityByUserId.vue";
import FamilyPrizes from "../components/FamilyPrizes.vue";
import Library from "../components/Library.vue";

export default {
  name: "Home",
    data() {
      return {
        //userId: '',
      }
    },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  components: {
    Library,
    //ViewActivityByUserId,
    FamilyPrizes,
  },
  created() {
    //this.userId = +this.$route.params.userId
  }
};
</script>
