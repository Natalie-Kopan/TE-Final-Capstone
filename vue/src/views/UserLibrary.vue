<template>
<section class="library">
  <h1>User's Library</h1>
  <Library />
</section>
</template>

<script>
import Library from '../components/Library.vue'

export default {
    name: 'userLibrary',
    components:{
        Library,
    },
}
</script>

<style>
.library{
  justify-content: space-evenly;

}

</style>