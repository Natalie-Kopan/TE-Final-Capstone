<template>
  <section>
    <h1>User's Books</h1>
  </section>
</template>

<script>
import AuthService from '../services/AuthService';

export default {
    name: 'userLibrary',
    data(){
      return{  
      }
    },
    methods:{
      displayBooks(){
          AuthService.displayUserBookLibrary(this.userId)
              .then(response => {
                    return response.data;
                    
                    //this.errorMessage = '';
                })
                .catch(response => {
                    console.error("Could not add book", response);
                    this.errorMessage = 'This book either already exists or is invalid. Check user books list';
                });
    }}

}
</script>

<style>

</style>