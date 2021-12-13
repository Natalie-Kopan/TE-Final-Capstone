<template>
  <div class="card">
    <form class="add-activity" v-on:submit.prevent="recordTime">
      <button v-on:click="play">Play</button>
      <button v-on:click="pause">Pause</button>
      <!--button v-on:click="recordTime">Stop</button-->
      <div v-if="timerEnabled">
        {{timerCount}}
      </div>
        <div class="form-group">
            <label for="bookFormat" class="form-label">Book Format</label>
            <select v-model="addedActivity.bookFormat">
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
        <button type="submit" class="submit"> Stop Timer</button>
        </div>
    </form>
    <p v-if="errorMessage">
        {{errorMessage}}
    </p>
    <p v-if="successMessage">
        {{successMessage}}
    </p>
    </div>
</template>

<script>
import AuthService from '../services/AuthService'
export default {
    props: {
        isbn: Number
    },
    data() {
        return {
            timerEnabled: false,
            timerCount: "",
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
        watch: {
            timerEnabled(value) {
                if (value) {
                    setTimeout(() => {
                        this.timerCount++;
                    }, 1000);
                }
            },
        timerCount: {
            handler(value) {
            if (value > 0 && this.timerEnabled) {
                setTimeout(() => {
                 this.timerCount++;
                }, 1000);
                    }
                },
                immediate: true // This ensures the watcher is triggered upon creation
            }
        },
        methods: {
            play() {
                this.timerEnabled = true;
            },
            pause() {
                this.timerEnabled = false;
            },
            recordTime(){
                this.timerEnabled = false;
                this.addedActivity.minutesRead = this.timerCount/60;
                this.addedActivity.isbn = this.isbn
                AuthService.addActivity(this.addedActivity)
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
        }
    }
</script>