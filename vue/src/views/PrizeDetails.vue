<template>
<div >
    <section id ="app" style="display:flex; justify-content:space-evenly">
        <div class="card">
        <div class="card-contents">
            <h2 id="center" class="h3 mb-3 font-weight-normal">{{prize.prizeTitle}}</h2>
            <p>Prize Description: {{prize.description}}</p>
            <p>Prize Milestone: {{prize.milestone}}</p>
            <p>Max Prize: {{prize.maxPrize}}</p>
            <p>Start Date: {{prize.startDate | formatDate}}</p>
            <p>End Date: {{prize.endDate | formatDate}}</p>
    <!--This is a 'mark complete' button for prizes, it does nothing yet
                <button class="btn btn-success"  v-on:click="edit=true" style="width:100%; color:white;">Mark Prize Complete</button> 
    -->            
                <button class="btn btn-primary"  v-on:click="edit=true" style="width:100%">Edit Prize</button> 
                <button class="btn btn-danger" type ="submit" v-on:click.prevent="deletedPrize()" style="width:100%; bottom:0; margin-bottom:1rem; color:white">Delete Prize</button>
        </div>  
        </div>
            <div v-if="edit">
                <form class="prizesform" v-on:submit.prevent="editPrize()">
                    <h1 class="h3 mb-3 font-weight-normal" id="center"> Edit Prize </h1>
                    <div v-if="errorMessage" class="alert alert-danger">
                        {{errorMessage}}
                    </div>
                    <div v-if="successMessage" class="alert alert-success">
                        {{successMessage}}
                    </div>
                    
                <div class="form-part">
                    <label for="prizeTitle" class="form-label">Title</label>
                    <input type="text" class="form-control" id="title" 
                        v-model.trim="prize.prizeTitle"
                        required 
                        placeholder="Enter a Prize title">
                </div>
            <div>
                <label for="description" class="form-label">Description</label>
                <input type="text" class="form-control" id="description" 
                v-model.trim="prize.description"
                required 
                placeholder="Enter a Prize descriptiom">
            </div>
            <div class="form-part">
                <label for="milestone" class="form-label">Milestone</label>
                <input type="text" class="form-control" id="milestone" 
                v-model.trim.number="prize.mileStone"
                required 
                placeholder="Enter a Prize milestone">
            </div>
            <div class="form-part">
                <label for="max_prize" class="form-label">Max Prize</label>
                <input type="text" class="form-control" id="max_prize" 
                v-model.trim.number="prize.maxPrize"
                required 
                placeholder="Enter a Max Prize">
            </div>
            <div class="form-part">
                <label for="start_date" class="form-label">Start Date </label>
                <datepicker  :bootstrap-styling="true" 
                v-model="prize.startDate"  name="start-date"
                :disabledDates="disabledDates"
                required 
                placeholder="Enter a Start Date">
                </datepicker>
            </div>
            <div class="form-part">
                <label for="end_date" class="form-label">End Date </label>
                <datepicker  name="end-date" :bootstrap-styling="true"
                v-model="prize.endDate"  
                :disabledDates="disabledDates"
                required 
                placeholder="Enter a End Date">
                </datepicker>
            </div>
            <div>
                <button class="btn btn-primary" type="submit" style="margin:0rem; width:100%" >Save Prize</button>
            </div>
            </form>
        </div> 
  </section>
</div>
</template>

<script>
import AuthService from '../services/AuthService'
import Datepicker from 'vuejs-datepicker';

export default {
name: 'PrizeDetails',
data() {
        return {
            prize: {},
            prizes: [],
            edit: false,
             disabledDates: {
                to: new Date(Date.now())
            },
            errorMessage: '',
            successMessage:'',
        }
    },
    components:{
        Datepicker
    },
    created() {
        let prizeparamId = parseInt(this.$route.params.id);
        let vuexPrize = this.$store.state.prizes.find(prize => prize.prizeId === prizeparamId);
        this.prize = {
            description:vuexPrize.description,
            endDate:vuexPrize.endDate,
            familyId:vuexPrize.familyId,
            maxPrize:vuexPrize.maxPrize,
            milestone:vuexPrize.milestone,
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
                    this.$store.commit('DELETE_PRIZE', this.prize.prizeId);
                    this.$router.push({name: 'ViewPrizes'});
                })
                .catch(response => {
                    console.error("Could not delete prize", response);
                    alert("Prize can not be deleted, please try again later.");
                });
            }
        },

        editPrize() {
            AuthService.editPrize(this.prize)
            .then(response => {
                console.log(response.data);
                this.$store.commit('EDIT_PRIZE', response.data);
                    if (response.status == 201) {
                        this.successMessage='Prize was successfully edited.'
                    }
                    this.errorMessage = '';
                })
                .catch(response => {
                    console.error("Could not edit prize", response);
                    this.errorMessage='Prize can not be edited, please check entered information.';
                });
            }
        }
}
</script>

<style>

</style>