<template>
  <div>
    <form class="add-activity" >

      <!--button v-on:click="recordTime">Stop</button-->
      <div v-if="timerEnabled">
      </div>
        <div class="form-group">
            <h4>Reading Timer</h4>

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
        <div style="position:absolute">
        <div v-if="!userTimer">
            <button class="btn btn-primary"  v-on:click.prevent="userTimer=true"  style="width:100%">Use Timer</button> 
        </div>
        <div id="center"  class="card" v-if="userTimer">
            <button class="btn btn-primary"  v-on:click.prevent="userTimer=false" style="width:100%">Hide Timer</button> 

            <p>{{minute > 9 ? minute: '0' + minute}}:{{second > 9 ? second: '0' + second}}</p>
        <div>
        <button v-on:click.prevent="play">Start Timer</button>
        <button v-on:click.prevent="pause">Pause Timer</button>
        </div>
        <button type="submit" class="submit" v-on:click.prevent="addingActivity"> Add</button>
        </div>        
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
            userTimer:false,
            timerEnabled: false,
            timerCount: "",
            second:0,
            minute:0,
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
                 this.second =(this.timerCount % 60);
                 this.minute = parseInt(this.timerCount / 60, 10) % 60
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
        addingActivity() {
            this.addedActivity.isbn = this.isbn
            this.addedActivity.minutesRead =this.minute;
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