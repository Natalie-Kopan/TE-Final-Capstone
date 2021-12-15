<template>
<section class="library">
      <div style="display:flex; flex-direction:column; align-items:center">
        <div class="library-btn" v-on:click='display=true' v-show="!display">Add a Book</div> 
        <div class="library-btn" v-on:click='display=false' v-show="display">Hide Add a Book</div> 
        <div v-if="display">
          <AddBook />
        </div>
        </div>
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


</style>