<template>
  <div id="login" class="text-center container">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="title-page h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>

      <div class="alert alert-danger" role="alert" v-if="networkError">
        Network error!
      </div>

      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div class="form-group">
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus />
      </div>
      <div class="form-group">
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required />
      </div>
      <div class="form-group">
        <router-link :to="{ name: 'Register' }">Need an account?</router-link>
      </div>
      <button class="btn btn-primary" type="submit">Sign in</button>
    </form>
    <div class="img">
            <img data-v-c226fde6="" src="/img/reading-astro.203076f8.jpeg" class="about-img">

        <!--img src="../../img/istockphoto-1284998990-170667a.jpg" alt="dad reading" /-->
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "Login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
      networkError: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({ name: "UserDashboard" });
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response == null || response.status === 500) {
            this.networkError = true;
          }

          else if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>

.form-signin {
  grid-area: create;
}

.img {
  grid-area: img;
}

#login {
  grid-template-columns: 1fr 1fr;
  display: grid;
  row-gap: 20px;
  column-gap: 50px;
  grid-template-areas:
  "create img"
}

</style>