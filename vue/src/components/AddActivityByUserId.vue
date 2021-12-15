<template>
  <section>
    <div>
    <form class="add-activity" v-on:submit.prevent="addingActivity">
        <div class="form-part">
        <h2> Minutes Read </h2>
        <label for="minutesRead" class="form-label">Mintues Read</label>
            <input type="text" class="form-control" id="minutesRead" 
                v-model.trim.number="addedActivity.minutesRead"
                required 
                placeholder="Enter Minutes Read">
        </div>
        <div class="form-group">
            <label for="bookFormat" class="form-label">Book Format</label>
            <select class="form-select" v-model="addedActivity.bookFormat">
                <option>Paper</option>
                <option>Digital</option>
                <option>Audiobook</option>
                <option>Read-Aloud (Reader)</option>
                <option>Read-Aloud (Listener)</option>
                <option>Other</option>
            </select>
        </div>
        <div class="form-part">
        <label for="notes" class="form-label">Notes</label>
            <input type="text" class="form-control" id="notes" 
                v-model.trim="addedActivity.notes"
                required 
                placeholder="Enter Notes">
        </div>
        <div>
        <button type="submit" class="submit"> Add</button>
        </div>
    </form>
    <p v-if="errorMessage">
        {{errorMessage}}
    </p>
    <p v-if="successMessage">
        {{successMessage}}
    </p>
    </div>
  </section>
</template>


<script>
import AuthService from '../services/AuthService'

export default {
    props: {
        isbn: Number,
        userId: Number
    },
    name: 'AddActivityByUserId',
        data() {
            return {
                addedActivity: {
                    minutesRead: '',
                    bookFormat: '',
                    notes: '',
                },
                activityLog:[],
                errorMessage: '',
                successMessage: ''

            }
        },
    methods: {
        addingActivity() {
            this.addedActivity.isbn = this.isbn
            AuthService.addActivityByUserId(this.addedActivity, this.userId)
                .then(response => {
                    const newItem = response.data;
                    this.activityLog.push(newItem);
                    this.addActivity={
                        minutesRead: '',
                        bookFormat: '',
                        notes: '',
                    };
                    this.errorMessage = '';
                    this.successMessage = 'Awesome reading! Your activity has been added!';
                })
                .catch(response => {
                    console.error("Could not add activity", response);
                    this.errorMessage = 'This activity either already exists or is invalid. Check user books list';
                    this.successMessage = '';
                });
        }      
    },
} 
</script>

<style>

</style>