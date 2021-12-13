<template>
  <section class="dashboard">
  <h1>Main Dashboard</h1>
  <Library />
  <ViewActivity />
  <FamilyPrizes />
</section>
</template>

<script>
import ViewActivity from '../components/ViewActivity.vue'
import FamilyPrizes from '../components/FamilyPrizes.vue'
import Library from '../components/Library.vue'

export default {
    name: 'Dashboard',   
    components:{
        ViewActivity,
        FamilyPrizes,
        Library
    },
}
 
</script>

<style>

</style>