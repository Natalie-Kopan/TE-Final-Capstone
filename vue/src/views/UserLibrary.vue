<template>
  <section id="container">
    <div v-for="book of allBooks" v-bind:key="book.isbn">
          {{book.title}} 
    </div>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    name: 'userLibrary',
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

</style>