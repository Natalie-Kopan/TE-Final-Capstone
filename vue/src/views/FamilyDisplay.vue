<template>
  <section class="container">
        <div style="display:flex; flex-direction:column; align-items:center">
        <button v-on:click='display=true' v-show="!display" v-if="$store.state.user.role == 'parent'">Add a Family Member</button> 
        <button v-on:click='display=false' v-show="display" v-if="$store.state.user.role == 'parent'">Hide Add a Family Member</button> 
        <div v-if="display">
            <AddFamily/>
        <!--router-link v-bind:to="{ name: 'AddPrizes' }" /-->
    </div>
        </div>
    <h1>Family</h1>
    <ViewFamily />
  </section>
</template>

<script>
import ViewFamily from '../components/ViewFamily.vue'
import AddFamily from '../components/AddFamily.vue'

export default {
    name: 'FamilyDisplay',
    components:{
        ViewFamily,
        AddFamily
    },
    data() {
    return {
        display: false,
    }
    },
}
</script>
