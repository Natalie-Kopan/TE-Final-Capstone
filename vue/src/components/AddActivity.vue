<template>

  <section class="add-activity">
            <p v-if="errorMessage"  class="alert alert-danger">
        {{ errorMessage }}
      </p>
      <p v-if="successMessage"  class="alert alert-success">
        {{ successMessage }}
      </p>
    <div style="display:inline-block">
              <div v-if="timerEnabled"></div>
      <div v-if="!userTimer" style="margin-top:20px; margin-left:40px; padding:5px">
        <button class="btn btn-primary" v-on:click.prevent="userTimer=true">
          Use Timer
        </button>
      </div>

      <div id="center" class="card" v-if="userTimer">
        <button
          class="btn btn-primary"
          v-on:click.prevent="userTimer = false"
          style="width: 100%"
        >
          Hide Timer
        </button>
      </div>


      <form style="border:0" v-on:submit.prevent="addingActivity">
        <div v-if="userTimer">
          <p>
            {{ minute > 9 ? minute : "0" + minute }}:{{
              second > 9 ? second : "0" + second
            }}
          </p>
          <div>
            <button v-on:click.prevent="play, timerEnabled=true">Start Timer</button>
            <button v-on:click.prevent="pause, timerEnabled=false">Pause Timer</button>
          </div>
        </div>
        <div class="form-part" v-if="!userTimer">
          <!--h4>Minutes Read</h4-->
          <label for="minutesRead" class="form-label">Mintues Read</label>
          <input
            type="text"
            class="form-control"
            id="minutesRead"
            v-model.trim.number="addedActivity.minutesRead"
            required
            placeholder="Enter Minutes Read"
          />
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
          <input
            type="text"
            class="form-control"
            id="notes"
            v-model.trim="addedActivity.notes"
            required
            placeholder="Enter Notes"
          />
        </div>
        <div>
          <button type="submit" class="submit">Add</button>
        </div>
      </form>

    </div>
  </section>
</template>


<script>
import AuthService from "../services/AuthService";

export default {
  props: {
    isbn: Number,
  },
  name: "AddActivity",
  data() {
    return {
      userTimer: false,
      timerEnabled: false,
      timerCount: "",
      second: 0,
      minute: 0,
      addedActivity: {
        minutesRead: "",
        bookFormat: "",
        notes: "",
      },
      activityLog: [],
      errorMessage: "",
      successMessage: "",
    };
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
            if(this.timerEnabled){
            this.timerCount++;
            this.second = this.timerCount % 60;
            this.minute = parseInt(this.timerCount / 60, 10) % 60;}
          }, 1000);
          
        }
      },
      immediate: true, // This ensures the watcher is triggered upon creation
    },
  },
  methods: {
    addingActivity() {
      this.addedActivity.isbn = this.isbn;
        if(this.userTimer == true )
        {
            this.addedActivity.minutesRead = this.minute;
        }
          this.timerEnabled = false;

      AuthService.addActivity(this.addedActivity)
        .then((response) => {

          const newItem = response.data;
          this.$store.commit('ACTIVITY_ADDED', this.addedActivity);
          this.activityLog.push(newItem);
          this.addedActivity = {
            minutesRead: "",
            bookFormat: "",
            notes: "",
          };

          this.errorMessage = "";
          this.successMessage =
            "Awesome reading! Your activity has been added!";
          

        })
        .catch((response) => {
          console.error("Could not add activity", response);
          this.errorMessage =
            "This activity either already exists or is invalid. Check user books list";
          this.successMessage = "";
        });
        this.timerCount=0;
        this.second=0;
        this.minute=0;
    },
  },
  play() {
    this.timerEnabled = true;
  },
  pause() {
    this.timerEnabled = false;
  },
};
</script>

<style>
.add-activity {
  padding: 5px;
  width: 500px;
  margin: 20px;
  border-radius: 10px;
  border: solid 5px #ffca3a;
}
</style>