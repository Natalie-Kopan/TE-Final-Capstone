<template>
    <form v-on:submit.prevent="addedBook">
        <div >
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
                v-model.trim="addBook.isbn"
                required 
                placeholder="Enter a Book ISBN">
        </div>
        <button type="submit" class="btn btn-succes"> Add</button>
    </form>
</template>

<script> 
import AuthService from '../services/AuthService';

export default {
    name: 'book',
        data() {
        return {
            addBook: {
                title: '',
                author: '',
                isbn: '',
            },
            books:[]
        }
    },
    methods: {
        addedBook() {
            AuthService.addNewBook(this.addBook)
                .then(response => {
                    books = response.data;
                })
                .catch(response => {
                    console.error("Could not add book", response);
                    alert("Could not add book. Please try again.");
                });
        }
            
    },
    created(){

    }
} 
</script>

<style>

</style>