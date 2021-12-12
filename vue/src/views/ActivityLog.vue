<template>
<section class="activityLog">
  <h1>Activity Dashboard</h1>
  <AddActivity v-bind:isbn="isbn"/>
  <ViewActivity v-bind:isbn="isbn"/>
</section>
</template>

<script>
import ViewActivity from '../components/ViewActivity.vue'
import AddActivity from '../components/AddActivity.vue'


export default {
    name: 'Activity',
        data(){
            return {
                isbn: '',
            }
        },    
    components:{
        ViewActivity,
        AddActivity
    },
    created() {
        this.isbn = +this.$route.params.isbn
    }
}
</script>

<style>
.library{
  justify-content: space-evenly;

}

</style>