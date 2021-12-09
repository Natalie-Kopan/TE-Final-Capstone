<template>
    <div class="container">
        <h1>Reading Activity Log</h1>
        <button class="btn btn-info" v-on:click.prevent="toggleLogForm"> {{logFormToggleText }} </button>
        <div id="form" v-if="showLogForm == true">
            <div v-if="showLogForm">
                <div id="addBook">
                    <p>Can't see your Book</p>
                    <router-link v-bind:to="{ name: ''}" class="btn btn-info" tag="button">Add Book</router-link>
                </div>
                    <add-reading-activity v-bind:currentUser="currentUser" v-on:add-log="toggleAndLoadLogs"/>
            </div>
        </div>
        <h2>Add Activity Log</h2>
            <div id="addActivityLog">
                <p>Number of Books Completed : {{ completedBooks.length }}</p>
                <p>Reading Time : {{ totalReadingTime }} minutes</p>
                <div v-if="currentBooks.length > 0" class="currentBooks">
                    <p>Currently Reading : </p><p v-for="book in currentBooks" v-bind:key="book.bookId">{{book.title}}</p>
                </div>
                 <div v-else class="currentBooks">
                    <p>You are not reading any books right now</p>
                </div>
            </div>
        <h3>Current Activity Log</h3>
        <div id="log-display-container">
        <div class="log" v-for="log in logs" v-bind:key="log.logId">
          <p><span class="grey">Book :</span> {{log.title}} </p>
          <p><span class="grey">Duration :</span> {{log.minutesSpent}} minutes</p>
          <p><span class="grey">Category :</span> {{log.readingFormat}} </p>
          <p><span class="grey">Notes :</span> {{log.bookNotes}} </p>
        </div>
        <div class="log" id="blank-log" v-if="logs.length % 2 == 1">
    </div>
    </div>
    </div>
  
</template>

<script>
//import AuthService from '../services/AuthService';

export default {

}
</script>

<style>

</style>

