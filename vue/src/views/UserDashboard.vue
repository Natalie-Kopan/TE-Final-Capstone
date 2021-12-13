<template>
  <div class="home container">
    <div>
      <h1> Welcome {{this.user.username}} To The Breakfast Book Club </h1>
      <div class="logged-in-dash" v-if="$store.state.token">
        <Library  v-bind:isbn="isbn"/>
        <ViewActivity v-bind:isbn="isbn"/>
        <FamilyPrizes/>
      </div>
    </div>   
  </div>
</template>

<script>
//import AuthService from "../services/AuthService";
import ViewActivity from "../components/ViewActivity.vue";
import FamilyPrizes from "../components/FamilyPrizes.vue";
import Library from "../components/Library.vue";

export default {
  name: "Home",
    data() {
      return {
        isbn: '',
      }
    },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  components: {
    Library,
    ViewActivity,
    FamilyPrizes,
  },
  methods: {
    // home() {
    //   AuthService
    //   .home(this.user)
    //     .then((response) => {
    //       if (response.status == 201) {
    //         this.$router.push({ name: "Home" });
    //       }
    //     })
    //     .catch((response) => {
    //       console.error("Could not add user", response);
    //       this.errorMessage =
    //         "This user either already exists or is invalid. Check user credentials";
    //     });
    // },
  },
  created() {
    this.isbn = +this.$route.params.isbn
  }
};
</script>
