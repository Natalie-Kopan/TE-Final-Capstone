<template>
  <section class="container">
    <h1>Family</h1>
    <ViewFamily />
  </section>
</template>

<script>
import ViewFamily from '../components/ViewFamily.vue'

export default {
    name: 'FamilyDisplay',
    components:{
        ViewFamily,
    },
}
</script>
