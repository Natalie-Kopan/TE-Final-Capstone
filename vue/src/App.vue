<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <div id="app"> <!-- If you start to get random styling you don't like, remove container from this div -->
    <div id="nav">
      <router-link class="nav-item" v-bind:to="{ name: 'home' }">
        <img id="logo" src="../public/logo-textonly.png" />
        <!--
          <i class="fas fa-home"></i>
          Home
        --> 
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token">Register</router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token">
        Login
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token">
        Logout
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'book' }"
        v-if="$store.state.token">
        Add Book
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'userLibrary' }"
        v-if="$store.state.token">
        User Library
      </router-link>
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

@import url('https://fonts.googleapis.com/css?family=Roboto');
@import './styles/colors.scss';
@import './styles/style.scss';

// Import the bootstrap styles. If you want to override Bootstrap colors, it needs to happen above this line
@import '../node_modules/bootstrap/scss/bootstrap';

// Your custom styles go below this point

</style>