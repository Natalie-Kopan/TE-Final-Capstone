<template>
  <div id="register" class="text-center container">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
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
          type="text"
          id="familyName"
          class="form-control"
          placeholder="Family Name"
          v-model="user.familyName"
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
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required />
      </div>
      
      <!--div class="form-group">
        <input
          type="checkbox"
          required />
          <label for="userRole">I am a Parent.</label>
      </div-->

      <div class="form-group">
        <router-link :to="{ name: 'Login' }">Have an account?</router-link>
      </div>
      <button class="btn btn-primary" type="submit">
        Create Account
      </button>
      <div class="container">
        <img src="../../img/istockphoto-1284998990-170667a.jpg" alt="dad reading" />
      </div>
    </form>
  </div>

  
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'Register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'parent',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                name: 'Login',
                query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style>
img {
  align-items: center;
  padding: 10px;
  display: grid;
}

.form-group {
  display: flexbox;
}
</style>
