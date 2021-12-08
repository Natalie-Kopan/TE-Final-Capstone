<template>

<section>
    <div class="container">
    <form v-on:submit.prevent="addedBook">
        <div class="form-part">
        <label for="title" class="form-label">Title</label>
            <input type="text" class="form-control" id="title" 
                v-model.trim="addBook.title"
                required 
                placeholder="Enter a Book title">
        </div>
        <div class="form-part">
        <label for="author" class="form-label">Author</label>
            <input type="text" class="form-control" id="author" 
                v-model.trim="addBook.author"
                required 
                placeholder="Enter a Book author">
        </div>
        <div class="form-part">
        <label for="isbn" class="form-label">ISBN</label>
            <input type="text" class="form-control" id="isbn" 
                v-model.trim.number="addBook.isbn"
                required 
                placeholder="Enter a Book ISBN">
        </div>
        <div>
        <button type="submit" class="submitBook"> Add</button>
        </div>
    </form>
    <p v-if="errorMessage">
        {{errorMessage}}
    </p>
    </div>
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
form{
    border: 2px solid black;
    border-radius: 10px;
    width: 450px;
    height: 280px;
    margin: 20px;
    align-self: center;
}

 .submitBook{
    border-radius: 10px;
    bottom: 0;
}


</style>