<template>

<section>
    <!--This is a set up for an extra feature to connect with outside API
    DELETE IF NOT ABLE TO GET TO THIS FEATURE
    <div class="container">
    <form>
        <h4> Search for Book To Add</h4>
        <label for="titleSearch" class="form-label">Title</label>
        <input type="text" class="form-control" id="titleSearch"
            placeholder="Search Book Title">
        <label for="authorSearch" class="form-label">Author</label>
        <input type="text" class="form-control" id="authorSearch"
            placeholder="Search Book Author">
        <label for="isbnSearch" class="form-label">ISBN</label>
        <input type="text" class="form-control" id="isbnSearch"
            placeholder="Search Book ISBN">
        <button type="submit" class="submit">Search</button>
    </form>
    </div> -->
    
    <div class="container">
    <form v-on:submit.prevent="addedBook">
        <div class="form-part">
        <h4 class="addbook" id="center-title"> Add A Book </h4>
        <p v-if="errorMessage" class="alert alert-danger">
            {{errorMessage}}
        </p>
        <label for="title" class="booklabel">Title</label>
            <input type="text" class="form-control" id="title" 
                v-model.trim="addBook.title"
                required 
                placeholder="Enter a Book title">
        </div>
        <div class="form-part">
        <label for="author" class="booklabel">Author</label>
            <input type="text" class="form-control" id="author" 
                v-model.trim="addBook.author"
                required 
                placeholder="Enter a Book author">
        </div>
        <div class="form-part">
        <label for="isbn" class="booklabel">ISBN</label>
            <input type="text" class="form-control" id="isbn" 
                v-model.trim="addBook.isbn"
                required 
                placeholder="Enter a Book ISBN">
        </div>
        <div>
        <button class="library-btn" type="submit"> Add</button>
        </div>
    </form>
    </div>
</section>
</template>

<script> 
import AuthService from '../services/AuthService';

export default {
    name: 'AddBook',
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
                    this.$store.commit('BOOK_ADDED', this.addBook);
                    this.books.push(newItem);
                    this.addBook={
                        title: '',
                        author: '',
                        isbn: '',
                        };
                    this.errorMessage = '';
                    //if (response.status == 201) {
                       // this.$router.push({ name: 'UserLibrary' });
                    //}
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
.booklabel {
    font-size: 50px !important;
    color: #92D5F2;
    letter-spacing: 5px;    
}

.addbook {
    color: #92D5F2;
    font-size: 50px;
    text-align: center;
}

.library-btn {
    text-align: center;
    background: #313131;
    cursor: pointer;
}



</style>