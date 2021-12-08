<template>
<section class="container">
    <form v-on:submit.prevent="addedBook">
        <div>
        <label for="title" class="form-label">Title</label>
            <input type="text" class="form-control" id="title" 
                v-model.trim="addBook.title"
                required 
                placeholder="Enter a Book title">
        </div>
        <div>
        <label for="author" class="form-label">Author</label>
            <input type="text" class="form-control" id="author" 
                v-model.trim="addBook.author"
                required 
                placeholder="Enter a Book author">
        </div>
        <div>
        <label for="isbn" class="form-label">ISBN</label>
            <input type="text" class="form-control" id="isbn" 
                v-model.trim.number="addBook.isbn"
                required 
                placeholder="Enter a Book ISBN">
        </div>
        <button type="submit" class="btn btn-succes"> Add</button>
    </form>
    <p v-if="errorMessage">
        {{errorMessage}}
    </p>
</section>
</template>

<script> 
import AuthService from '../services/AuthService';

export default {
    name: 'addBook',
        data() {
        return {
            addBook: {
                title: '',
                author: '',
                isbn: '',
            },
            books:[],
            errorMessage: ''
        }
    },
    methods: {
        addedBook() {
            AuthService.addNewBook(this.addBook)
                .then(response => {
                    const newItem = response.data;
                    this.books.push(newItem);
                    this.addBook={
                        title: '',
                        author: '',
                        isbn: '',
                        };
                    this.errorMessage = '';
                })
                .catch(response => {
                    console.error("Could not add book", response);
                    this.errorMessage = 'This book either already exists or is invalid. Check user books list';
                });
        }      
    },
} 
</script>

<style>

</style>