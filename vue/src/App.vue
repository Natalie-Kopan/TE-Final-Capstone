<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app"> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link class="logo" v-bind:to="{ name: 'Home' }">
        <img id="logo nav-item" src="../public/logo-textonly.png" />
        <!--
          <i class="fas fa-home"></i>
          Home
        --> 
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'Register' }"
        v-if="!$store.state.token">Register</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'Login' }"
        v-if="!$store.state.token">
        Login
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'UserDashboard'}"
        v-if="$store.state.token">
        User Dashboard
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'PrizeDashboard' }"
        v-if="$store.state.token">
       Prizes Dashboard
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'UserLibrary' }"
        v-if="$store.state.token">
        User Library
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'FamilyDisplay' }"
        v-if="$store.state.user.role == 'parent'">
        View Family
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'FamilyAdd' }"
        v-if="$store.state.user.role == 'parent'">
        Add Family Member
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'Logout' }"
        v-if="$store.state.token">
        Logout
      </router-link>
      <!-- <router-link
        class="nav-item"
        v-bind:to="{ name: 'ViewPrizes' }"
        v-if="$store.state.token">
        View Prizes
      </router-link> -->
    </div>
    
    <router-view />
  </div>
</template>

<script>
export default {
}
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">

@import url('https://fonts.googleapis.com/css2?family=Gochi+Hand&display=swap');
@import url('https://fonts.googleapis.com/css?family=Roboto');
@import './styles/colors.scss';
@import './styles/style.scss';


// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import '../node_modules/bootstrap/scss/bootstrap';

// Your custom styles go below this point
</style>