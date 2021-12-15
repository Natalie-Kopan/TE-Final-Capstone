<template>
<section class="library">
      <div style="display:flex; flex-direction:column; align-items:center">
        <button v-on:click='display=true' v-show="!display">Add a Book</button> 
        <button v-on:click='display=false' v-show="display">Hide Add a Book</button> 
        <div v-if="display">
          <AddBook />
        </div>
        </div>
      <h1 id="center">User's Library</h1>
  <Library />
</section>
</template>

<script>
import Library from '../components/Library.vue'
import AddBook from '../components/AddBook.vue'

export default {
    name: 'UserLibrary',
    components:{
        Library, AddBook
    },
    data(){
      return{
        display:false,
      }
    },
}
</script>

<style>
.library{
  justify-content: space-evenly;

}

</style>