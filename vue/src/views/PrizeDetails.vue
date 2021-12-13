<template>
    <section id = "app" class="card">
        <div class="card-contents">
            <h2 id="center">{{prize.prizeTitle}}</h2>
            <button class="btn btn-danger" type ="submit" v-on:click.prevent="deletedPrize()" style="width:100%; bottom:0; margin-top:auto">Delete Prize</button>
            <button class="btn btn-primary" type ="submit" v-on:click.prevent="editPrize()">Edit Prize</button>   
        </div> 
  </section>
</template>

<script>
import AuthService from '../services/AuthService'

export default {
name: 'PrizeDetails',
data() {
        return {
            prize: {}
        }
    },
    created() {
        let prizeparamId = parseInt(this.$route.params.id);
        let vuexPrize = this.$store.state.prizes.find(prize => prize.prizeId === prizeparamId);
        this.prize = {
            description:vuexPrize.description,
            endDate:vuexPrize.endDate,
            familyId:vuexPrize.familyId,
            maxPrize:vuexPrize.maxPrize,
            mileStone:vuexPrize.mileStone,
            prizeId:vuexPrize.prizeId,
            prizeTitle:vuexPrize.prizeTitle,    
            startDate:vuexPrize.startDate
            }
        },
    params:{
        id: Number
    },
   methods: {
    deletedPrize() {
        let confirmed = confirm('Are you sure you want to delete this prize? This cannot be undone.');
        if (confirmed) {
                AuthService.deletedPrize(this.prize.prizeId)
                .then(() => {
                    console.log(this.prize.prizeId);
                    this.$store.commit('DELETE_PRIZE', this.prize.prizeId);
                    console.log()
                    this.$router.push({name: 'ViewPrizes'});
                })
                .catch(response => {
                    console.error("Could not delete prize", response);
                    alert("Prize can not be deleted, please try again later.");
                });
            }
        },
        editPrize() {
            AuthService.deletedPrize(this.prize.prizeId)
            .then(() => {
                this.$store.commit('EDIT_PRIZE', this.prize);
                })
                .catch(response => {
                    console.error("Could not edit prize", response);
                    alert("Prize can not be editted, please try again later.");
                });
            }
        }
}
</script>

<style>

</style>