<template>
  <section>
        <div>
            <form v-on:submit="addedPrize" class="prizesform" >
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
                <label for="milestone" class="form-label">Reading Milestone</label>
                <input type="text" class="form-control" id="milestone" 
                v-model.trim.number="addPrize.mileStone"
                required 
                placeholder="Enter a Reading milestone">
            </div>
            <div class="form-part">
                <label for="max_prize" class="form-label">Max Prize Recipient</label>
                <input type="text" class="form-control" id="max_prize" 
                v-model.trim.number="addPrize.maxPrize"
                required 
                placeholder="Enter the max number of Prize Recipient">
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
import AuthService from '../services/AuthService'
import Datepicker from 'vuejs-datepicker';

export default {
    name: 'AddPrizes',
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
    components:{
        Datepicker
    },
    methods: {
        addedPrize() {
            AuthService.addNewPrize(this.addPrize)
                .then(response => {
                    const newItem = response.data;
                    this.$store.commit('PRIZES_ADDED', this.addPrize);
                    this.prizes.push(newItem);
                    this.addPrize={
                        description: '',
                        prizeTitle: '',
                        mileStone: '',
                        maxPrize: '',
                        startDate: '',
                        endDate: '',
                    };
                    if (response.status == 201) {
                        this.successMessage='Prize was successfully added.'

                    }
                    this.errorMessage = '';
                })
                .catch(response => {
                    console.log(response);
                    console.error("Could not add a Prize", response);
                    this.errorMessage = 'This prize is invalid. Please check entered information. ';
                    this.successMessage = '';
                });
        }
    },
  }
</script>

<style>
.prizesform{
    border: 10px solid #1982c4;
    border-radius: 30px;
    width: 450px;
    margin: 20px;
}
form div > div {
    margin: 0;
}
#center{
    text-align: center;
}
#center-title{
    text-align: center;
    font-size: 80px;
    letter-spacing: .2ch;
    /* margin: 30px; */
    /* color: white; */
    /* border: 5px solid #92d5f2; */
    /* border-style: outset; */
    padding: 20px;
}
</style>