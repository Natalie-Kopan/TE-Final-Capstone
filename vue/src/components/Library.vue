<template>
  <section class="library-container" id = "app">
    <h1 id="center"><i class="fas fa-meteor"></i>  Your Library  <i class="fas fa-meteor"></i></h1>
    <div v-for="book of allBooks" v-bind:key="book.isbn">
      <div class = "library-card">
      <div class="card-contents">
        <h2 id="center-4">{{book.title}}</h2>
        <img class= "bookcover" v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" alt="book.title" />
        <!--h3 class="book-author">{{ book.author }}</h3-->
        <!--<button class="library-button" type ="submit" style="width:100%; bottom:0; margin-top:auto">-->
          <router-link class="library-btn" v-bind:to="{name: 'ActivityLog', params: {isbn: book.isbn}}">
              View/Add Activity
          </router-link>
       <!--</button>-->
    </div>
    </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService'

export default {
    name: 'Library',
    computed: {
      allBooks() {
          return this.$store.state.books;
      },
   },
     created() {
          // Make a HTTP GET request and return a promise representing the operation
          const booksPromise = AuthService.displayUserBookLibrary();
          booksPromise
          // 200 Status Codes
          .then(response => {
          console.log("GET Completed", response);
          const books = response.data;
          this.$store.state.books.push(books);
          this.$store.commit('BOOKS_LOADED', books);
          })
          // 400, 500, network issues, no internet, etc.
          .catch(response => {
            console.error("Could not load books.", response);
          });
  }
}

</script>

<style>

</style>