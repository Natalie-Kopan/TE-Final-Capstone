<template>
<main class="container">
    <h1>Activity Dashboard</h1>
  <AddActivityByUserId v-bind:isbn="isbn" v-bind:userId="userId"/>
  <ViewActivityByUserId v-bind:isbn="isbn" v-bind:userId="userId"/>
</main>
</template>

<script>
import AddActivityByUserId from "../components/AddActivityByUserId.vue"
import ViewActivityByUserId from "../components/ViewActivityByUserId.vue"
export default {
    name: 'ActivityLogByUserId',
    data(){
        return {
            isbn: '',
            userId: '',
        }
    },    
    components:{
        AddActivityByUserId,
        ViewActivityByUserId,
    },
    created() {
        this.isbn = this.$route.params.isbn
        this.userId = +this.$route.params.userId
    }
}
</script>

<style>

</style>