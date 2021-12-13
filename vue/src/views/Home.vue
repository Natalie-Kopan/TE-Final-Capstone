<template>
  <div class="home container">
    <div>
      <h1> Welcome {{this.user.username}} To The Breakfast Book Club </h1>
    <Library v-if="$store.state.token" v-bind:isbn="isbn"/>
    <ViewActivity v-if="$store.state.token" v-bind:isbn="isbn"/>
    <FamilyPrizes v-if="$store.state.token"/>
     <p>
      Launched in 1984, <em>The Breakfast Book Club</em> became an inclusive
      book club amongst aspiring Tech Elevator classmates. While the concept of
      <em>The Breakfast Club</em> began as a study hall, it quickly grew into a
      fun-filled reading competition. The mantle has now been passed down to
      their kids where they can track daily reading, compete with friends and
      family to get prizes and continue the traditon of the club.
    </p>
    </div>   
  </div>
</template>

<script>
import AuthService from "../services/AuthService";
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
    home() {
      AuthService
      .home(this.user)
        .then((response) => {
          if (response.status == 201) {
            this.$router.push({ name: "Home" });
          }
        })
        .catch((response) => {
          console.error("Could not add user", response);
          this.errorMessage =
            "This user either already exists or is invalid. Check user credentials";
        });
    },
  },
  created() {
    this.isbn = +this.$route.params.isbn
  }
};
</script>
