<template>
<main>
    <FamilyPrizes />
     <AddPrizes v-if="$store.state.user.role == 'parent'"/>
</main>
</template>

<script>
import AddPrizes from '../components/AddPrizes.vue'
import FamilyPrizes from '../components/FamilyPrizes.vue'

export default {
    components: {
        AddPrizes,
        FamilyPrizes,
    }
}
</script>

<style>

</style>