<template>
  <section class="container">
        <div style="display:flex; flex-direction:column; align-items:center">
        <button  v-on:click='display=true' v-show="!display" v-if="$store.state.user.role == 'parent'" class="library-btn" style="background-color: #313131">Add a Family Member</button> 
        <button v-on:click='display=false' v-show="display" v-if="$store.state.user.role == 'parent'" class="library-btn" style="background-color: #313131">Hide Add a Family Member</button> 
        <div v-if="display">
            <AddFamily/>
        <!--router-link v-bind:to="{ name: 'AddPrizes' }" /-->
    </div>
        </div>
    <h1 class="title-page" id="center-title">Current Family Users</h1>
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
