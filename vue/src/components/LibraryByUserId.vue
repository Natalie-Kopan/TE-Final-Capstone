<template>
  <!--section class="library-container" id = "app">
    <div v-for="book of allBooks" v-bind:key="book.isbn">
      <div class = "card">
      <div class="card-contents">
        <h2>{{book.title}}</h2>
        <img class= "bookcover" v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" alt="book.title" />
        <button class="btn btn-primary" type ="submit" style="width:100%; bottom:0; margin-top:auto">
          <router-link v-bind:to="{name: 'ActivityLogByUserId', params: {isbn: book.isbn, userId: userId}}" style="color:white">
              View/Add Activity
          </router-link>
        </button>
    </div>
    </div>
    </div>
  </section-->
    <section  id = "app">
    <h1 id="center"><i class="fas fa-meteor" v-b></i>  {{getUserName}} Library  <i class="fas fa-meteor"></i></h1>
    <div class="library-container">
    <div v-for="book of allBooks" v-bind:key="book.isbn">
      <div class = "library-card">
      <div class="card-contents">
        <h2 id="center-4">{{book.title}}</h2>
        <img class= "bookcover" v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" alt="book.title" />
        <!--h3 class="book-author">{{ book.author }}</h3-->
        <!--<button class="library-button" type ="submit" style="width:100%; bottom:0; margin-top:auto">-->
          <router-link class="library-btn" v-bind:to="{name: 'ActivityLogByUserId', params: {isbn: book.isbn, userId: userId}}">
              View/Add Activity
          </router-link>
       <!--</button>-->
    </div>
    </div>
    </div>
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService'

export default {
    name: 'LibraryByUserId',
    props: {
      userId: Number
    },
    computed: {
      allBooks() {
          return this.$store.state.books;
      },
      getUserName(){
        return this.$store.state.familyMembers.find(f => f.userId === this.userId).username
      }
   },
     created() {
          // Make a HTTP GET request and return a promise representing the operation

          const booksPromise = AuthService.displayUserLibraryByUserId(this.userId);
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
.bookcover{
    border-radius: 10px;
}
</style>