<template>
<main>
    <FamilyPrizes />
    <AddPrizes />
    <!-- <button v-on:click='false' v-if="$store.state.user.role == 'parent' ">
        <div v-if="!click">
        <router-link v-bind:to="{ name: 'AddPrizes' }" />
        </div>
        Add A Prize
    </button> -->
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
        click: true,
    }
    },
}
</script>

<style>

</style>