<template>
<main>
        <!--AddPrizes /-->
    <div class="prize-container">
        <button v-on:click='display=true' v-show="!display" v-if="$store.state.user.role == 'parent'" class="prize-column-one">Add a Prize</button> 
        <button v-on:click='display=false' v-show="display" v-if="$store.state.user.role == 'parent'" class="prize-column-one">Hide Add a Prize</button> 
        <div v-if="display" class="prize-column">
            <AddPrizes/>
        <!--router-link v-bind:to="{ name: 'AddPrizes' }" /-->
    </div>
    <div class="prize-column-two">
       <FamilyPrizes />
    </div>
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
.prize-container{
    margin: 2rem;
    display: grid;
    align-content: center;
    grid-gap: 10px;
    grid-template-areas:
      "add-prize"
      "prize-column"
      "view-prize";
}
.prize-column-one{
    grid-area: add-prize;

}
.prize-column-two{
    grid-area: view-prize;
    height: 50px;
}
.prize-column{
    grid-area: prize-column;
}
</style>