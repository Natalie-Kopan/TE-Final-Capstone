<template>
    <section class="view-prize-container">
      <h1 class="prize-title">Here are your available prizes!</h1>
                    <div class="prize-card">

        <div v-for="prize of allPrizes" v-bind:key="prize.prizeId">
                <div class="card card-contents">
                    <h2 id="center" class="h3 mb-3 font-weight-normal">{{prize.prizeTitle}}</h2>
                      <p style="padding:10px">Start Date: {{prize.startDate | formatDate}}</p>
                      <p style="padding:10px">End Date: {{prize.endDate | formatDate}}</p>
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