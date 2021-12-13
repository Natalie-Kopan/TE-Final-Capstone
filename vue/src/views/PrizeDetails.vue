<template>
    <section id = "app">
        <div v-bind:key="prize.prizeId">
                <h2 id="center">{{prize.prizeTitle}}</h2>
                <p>First {{prize.maxPrize}} member(s) of your family to read {{prize.milestone}} minutes.</p>
                <button class="btn btn-primary" type ="submit">Edit Prize</button>
                <button class="btn btn-danger" type ="submit" v-on:click.prevent="deletedPrize(prize)">Delete Prize</button>
        </div>
  </section>
</template>

<script>
export default {
name: 'PrizeDetails',
        data() {
        return {
            addPrize: {
                description: '',
                prizeTitle: '',
                mileStone: '',
                maxPrize: '',
                startDate: '',
                endDate: '',
            },
            disabledDates: {
                to: new Date(Date.now())
            },
            prizes:[],
            errorMessage: '',
            successMessage:'',
        }
    },
   methods: {
    deletedPrize(selectedPrize) {
        let confirmed = confirm('Are you sure you want to delete this prize? This cannot be undone.');
        if (confirmed) {
                AuthService.deletedPrize(selectedPrize)
                .then(() => {
                    this.$store.commit('DELETE_PRIZE', selectedPrize);
                    //this.$router.push({name: 'Prizes'});
                })
                .catch(response => {
                    console.error("Could not delete prize", response);
                    alert("Prize can not be deleted, please try again later.");
                });
            }
        }
    },
  
    
}
</script>

<style>

</style>