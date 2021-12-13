<template>
    <section id = "app" class="library-container">
        <div v-for="prize of allPrizes" v-bind:key="prize.prizeId">
            <div class = "card">
                <div class="card-contents">
                    <h2 id="center">{{prize.prizeTitle}}</h2>
                <p>First {{prize.maxPrize}} member(s) of your family to read {{prize.milestone}} minutes.</p>
                <button class="btn btn-primary" type ="submit" style="width:100%; bottom:0; margin-top:auto">View Prize Details</button>
                <button class="btn btn-danger" type ="submit" style="width:100%" v-on:click.prevent="deletedPrize(prize)">Delete Prize</button>
            </div>
        </div>
        </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService'

export default {
    name: 'FamilyPrizes',
    computed: {
    allPrizes() {
          return this.$store.state.prizes;
        },
    },
    created() {
          // Make a HTTP GET request and return a promise representing the operation
          const prizesPromise = AuthService.displayPrizes();
          prizesPromise
          // 200 Status Codes
          .then(response => {
            console.log("GET Completed", response);
            const prizes = response.data;
            this.$store.state.prizes.push(prizes);
            this.$store.commit('PRIZES_LOADED', prizes);
          })
          // 400, 500, network issues, no internet, etc.
          .catch(response => {
            console.error("Could not load prizes.", response);
            alert("Issue loading prizes");
          });
    },
   
  
    
}
</script>

<style>

</style>