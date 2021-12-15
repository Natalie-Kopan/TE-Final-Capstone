<template>
    <section class="view-prize-container">
   
      <h1 class="prize-title" id="center"><i class="fas fa-rocket"></i>  Available prizes  <i class="fas fa-rocket"></i></h1>
     
                    <div class="prize-card">

        <div v-for="prize of allPrizes" v-bind:key="prize.prizeId">
                <div class="library-card">
                    <h2 id="center-2" class="h3 mb-3 font-weight-normal">{{prize.prizeTitle}}</h2>
                      <p id="center-4" >Start Date: {{prize.startDate | formatDate}}</p>
                      <p id="center-4" >End Date: {{prize.endDate | formatDate}}</p>
                           <router-link class="library-btn" v-bind:to="{name: 'PrizeDetails', params: {id: prize.prizeId}}">
                                View Prize Details
                            </router-link>
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
.view-prize-container{
  display: grid;
  grid-template-areas:
      "header"
      "card";
}
.prize-title{
  text-align: center;
    grid-area: header;

}
.prize-card{
  grid-area: card;
  display: flex;
  flex-wrap: wrap;
  position: inherit;
  justify-content: space-evenly;
  }
</style>