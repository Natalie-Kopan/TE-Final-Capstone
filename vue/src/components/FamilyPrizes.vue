<template>
    <section id = "app" class="library-container">
        <div v-for="prize of allPrizes" v-bind:key="prize.prizeId">
            <div class = "card">
                <div class="card-contents">
                    <h2 id="center" class="h3 mb-3 font-weight-normal">{{prize.prizeTitle}}</h2>
                      <p>Start Date: {{prize.startDate | formatDate}}</p>
                      <p>End Date: {{prize.endDate | formatDate}}</p>
                        <button class="btn btn-primary" type ="submit" style="width:100%; bottom:0; margin-top:auto">
                           <router-link v-bind:to="{name: 'PrizeDetails', params: {id: prize.prizeId}}" style="color:white">
                                View Prize Details
                            </router-link>
                        </button>
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
          });
    },
   
  
    
}
</script>

<style>

</style>