<template>
<section>
    <Library/>
    <UserProgress />
</section>

</template>

<script>
import AuthService from '../services/AuthService';
import UserProgress from '../components/UserProgress.vue';
import Library from '../components/Library.vue' 

export default {
    name: 'ParentView',
    components:{
        Library, UserProgress
    },
}
</script>

<style>

</style>