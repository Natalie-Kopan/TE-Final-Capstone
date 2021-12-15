<template>
<main>
        <!--AddPrizes /-->
    <div style="display:flex; flex-direction:column; align-items:center">
        <button v-on:click='display=true' v-show="!display" v-if="$store.state.user.role == 'parent'">Add a Prize</button> 
        <button v-on:click='display=false' v-show="display" v-if="$store.state.user.role == 'parent'">Hide Add a Prize</button> 
        <div v-if="display">
            <AddPrizes/>
        <!--router-link v-bind:to="{ name: 'AddPrizes' }" /-->
    </div>
       <FamilyPrizes />

    </div>
</main>
</template>

<script>
import FamilyPrizes from '../components/FamilyPrizes.vue'
import AddPrizes from '../components/AddPrizes.vue'

export default {
components: {
    FamilyPrizes,
   AddPrizes
    },
data() {
    return {
        display: false,
    }
    },
}
</script>

<style>

</style>