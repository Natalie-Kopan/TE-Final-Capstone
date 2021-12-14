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
        <button class="btn btn-primary"  v-on:click="userTimer=true" style="width:100%">Use Timer</button> 
        <div v-if="userTimer">
            <p>Timer: {{timerCount}}</p>
            <p>{{time}}</p>
        <div>
        <button v-on:click.prevent="play">Play</button>
        <button v-on:click.prevent="pause">Pause</button>
        <button type="submit" class="submit" v-on:submit.prevent="recordTime"> Stop Timer</button>
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
            time: null,
            interval: null,
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
        beforeDestroy() {
    // prevent memory leak
    clearInterval(this.interval)
  },
  created() {
    // update the time every second
    this.interval = setInterval(() => {
      // Concise way to format time according to system locale.
      // In my case this returns "3:48:00 am"
      this.time = Intl.DateTimeFormat(navigator.language, {
        hour: 'numeric',
        minute: 'numeric',
        second: 'numeric'
      }).format()
    }, 1000)},
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
                this.addedActivity.minutesRead = parseInt(this.timerCount/60);
                this.addedActivity.isbn = this.isbn
                AuthService.addActivity(this.addedActivity)
                .then(response => {
                    const newItem = response.data;
                    this.activityLog.push(newItem);
                    this.addedActivity={
                        minutesRead: '',
                        bookFormat: '',
                        notes: '',
                    };
                    this.timeerCount="";
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