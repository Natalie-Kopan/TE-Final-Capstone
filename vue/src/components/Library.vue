<template>
  <section class="library-container" id = "app">
    <div v-for="book of allBooks" v-bind:key="book.isbn">
      <div class = "card">
      <h2>{{book.title}}</h2>
      <img class= "bookcover" v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" alt="book.title" />
      <!--h3 class="book-author">{{ book.author }}</h3-->
      <button class="button">
          <router-link v-bind:to="{name: 'UserProgress', params: {id: book.isbn}}">
              View Book Activity
          </router-link>
        </button>
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
            alert("Issue loading books");
          });
  }
}

</script>

<style>
.card {
    border: 2px solid black;
    border-radius: 10px;
    width: 250px;
    height: 410px;
    margin: 20px;
}
.library-container{
    display: flex;  
    flex-wrap: wrap;
    justify-content: space-evenly;
}
.bookcover{
    border-radius: 10px;

}
.button{
  position: absolute;
  bottom: 0;
  align-self: center;
  border-radius: 10px;
  width: 100%;
}

</style>