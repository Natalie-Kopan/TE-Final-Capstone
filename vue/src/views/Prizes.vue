<template>
  <section class="prizesform">
        <div>
            <form v-on:submit.prevent="addedPrize">
            <div class="form-part">
                <h4> Add A Prize </h4>
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
                v-model.trim.number="addPrize.milestone"
                required 
                placeholder="Enter a Prize milestone">
            </div>
            <div class="form-part">
                <label for="max_prize" class="form-label">Max Prize</label>
                <input type="text" class="form-control" id="max_prize" 
                v-model.trim.number="addPrize.max_prize"
                required 
                placeholder="Enter a Max Prize">
            </div>
            <div class="form-part">
                <label for="start_date" class="form-label">Start Date </label>
                <DatePicker type="date" class="form-control" id="start_date" 
                v-model="addPrize.start_date"
                required 
                placeholder="Enter a Start Date">
                </DatePicker>
            </div>
                <div class="form-part">
                <label for="end_date" class="form-label">End Date </label>
                <DatePicker type="date" class="form-control" id="end_date" 
                v-model="addPrize.end_date"
                required 
                placeholder="Enter a End Date">
                </DatePicker>
            </div>
            <div>
                <button type="submit" class="submit"> Add</button>
            </div>
    </form>
    <p v-if="errorMessage">
        {{errorMessage}}
    </p>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService'
import DatePicker from 'vuejs-datepicker';

export default {
    name: 'Prizes',
        data() {
        return {
            addPrize: {
                description: '',
                prize_title: '',
                user_group: '',
                milestone: '',
                max_prize: '',
                start_date: '',
                end_date: '',
            },
            prizes:[],
            errorMessage: ''
        }
    },
    components:{
        DatePicker
    },
    methods: {
        addedPrize() {
            AuthService.addNewPrize(this.addPrize)
                .then(response => {
                    const newItem = response.data;
                    this.prizes.push(newItem);
                    this.addPrize={
                        family_id: '',
                        description: '',
                        prize_title: '',
                        user_group: '',
                        milestone: '',
                        max_prize: '',
                        start_date: '',
                        end_date: '',
                        };
                    this.errorMessage = '';
                })
                .catch(response => {
                    console.error("Could not add a Prize", response);
                    this.errorMessage = 'This prize either already exists or is invalid. Check user books list';
                });
        }      
    },
  }
</script>

<style>
.prizesform{
    border: 2px solid black;
    border-radius: 10px;
    width: 450px;
    height: 650px;
    margin: 20px;
}

</style>