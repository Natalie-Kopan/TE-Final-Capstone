<template>
  <div id="addFamilyMember" class="text-center container">
    <form class="form-add-family-member" @submit="addFamilyMember">
      <h1 class="h3 mb-3 font-weight-normal" id="center-title" >Add Family Member</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="alert alert-success" role="alert" v-if="successMessage && !registrationErrors">
        {{ successMessage }}
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
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required />
      </div>
      <div class="form-group">
        <select
          id="role"
          class="form-select"
          v-model="user.role">
          <option value="parent">Parent</option>
          <option value="child">Child</option>
        </select>
      </div>
      
      <!--div class="form-group">
        <input
          type="checkbox"
          required />
          <label for="userRole">I am a Parent.</label>
      </div-->

      <!--<div class="form-group">
        <router-link :to="{ name: 'login' }">Have an account?</router-link>
      </div>-->
      <button class="btn btn-primary" type="submit">
        Add Family Member
      </button>
    </form>
  </div>
</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'AddFamilyMember',
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
      successMessage: '',
    };
  },
  methods: {
    addFamilyMember() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        authService
          .addFamilyMember(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.registrationErrors = false;
              this.registrationErrorMsg = '';
              this.successMessage = this.user.username + ' was succesfully added.'
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            this.successMessage = '';
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

<style></style>