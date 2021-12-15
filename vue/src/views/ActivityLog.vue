<template>
<section class="activityLog container">
  <h1>Activity Dashboard</h1>
    <div style="display:flex; flex-direction:column; align-items:center">
        <button class="add-button library-btn" v-on:click='display=true' v-show="!display">Add an Activity</button> 
        <button class="add-button library-btn" v-on:click='display=false' v-show="display">Hide Add an Activity</button> 
    <div v-if="display">
        <AddActivity v-bind:isbn="isbn"/>
    </div> 
    </div> 
  
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
                display: false,
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
.activityLog{
  justify-content: space-evenly;

}

</style>