<template>
  <section>
        <div>
            <form v-on:submit.prevent="addedPrize" class="prizesform" >
                <h1 class="h3 mb-3 font-weight-normal" id="center"> Add A Prize </h1>
                <div v-if="errorMessage" class="alert alert-danger">
                    {{errorMessage}}
                </div>
                <div v-if="successMessage" class="alert alert-success">
                    {{successMessage}}
                </div>
            <div class="form-part">
                <label for="prizeTitle" class="form-label">Title</label>
                <input type="text" class="form-control" id="title" 
                    v-model.trim="addPrize.prizeTitle"
                    required 
                    placeholder="Enter a Prize title">
            </div>
            <div>
                <label for="description" class="form-label">Description</label>
                <input type="text" class="form-control" id="description" 
                v-model.trim="addPrize.description"
                required 
                placeholder="Enter a Prize descriptiom">
            </div>
            <div class="form-part">
                <label for="milestone" class="form-label">Milestone</label>
                <input type="text" class="form-control" id="milestone" 
                v-model.trim.number="addPrize.mileStone"
                required 
                placeholder="Enter a Prize milestone">
            </div>
            <div class="form-part">
                <label for="max_prize" class="form-label">Max Prize</label>
                <input type="text" class="form-control" id="max_prize" 
                v-model.trim.number="addPrize.maxPrize"
                required 
                placeholder="Enter a Max Prize">
            </div>
            <div class="form-part">
                <label for="start_date" class="form-label">Start Date </label>
                <datepicker  :bootstrap-styling="true" 
                v-model="addPrize.startDate"  name="start-date"
                :disabledDates="disabledDates"
                required 
                placeholder="Enter a Start Date">
                </datepicker>
            </div>
            <div class="form-part">
                <label for="end_date" class="form-label">End Date </label>
                <datepicker  name="end-date" :bootstrap-styling="true"
                v-model="addPrize.endDate"  
                :disabledDates="disabledDates"
                required 
                placeholder="Enter a End Date">
                </datepicker>
            </div>
            <div>
                <button class="btn btn-primary" type="submit" style="margin:0rem; width:100%">Add Prize</button>
            </div>
    </form>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService.js';

export default {
    data() {
        return {
            prize: {}
        }
    },
    created() {
        let prizeparamId = parseInt(this.$route.params.id);

        // this.bug = this.$store.state.bugs.slice().find(bug => bug.id === bugId);

        let vuexPrize = this.$store.state.prizes.find(prize => prize.prizeId === prizeparamId);

        if (!vuexPrize) {
            this.$router.push({name: 'NotFound'});
        }

        // Clone the thing we found in Vuex
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
    methods: {
        savePrize() {
            AuthService.editPrize(this.prize)
                .then(response => {
                    this.$store.commit('EDIT_PRIZE', response.data);
                   // this.$router.push({name: 'BugDetails', params: {id: response.data.id}});
                })
                .catch(response => {
                    console.error("Could not update prize", response);
                    alert("Could not update the prize");
                });
        }
    }
}
</script>

<style>
form .btn {
    margin-right: 1rem;
}
</style>

<style>

</style>
