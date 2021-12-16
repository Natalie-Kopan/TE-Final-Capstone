<template>
<main class="container">
    <h1 id="center"> <i class="fas fa-star"/> Activity Dashboard <i class="fas fa-star"/> </h1>
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
            isbn: String,
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