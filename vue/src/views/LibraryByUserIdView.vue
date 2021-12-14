<template>
  <LibraryByUserId v-bind:userId="userId"/>
</template>

<script>

import LibraryByUserId from '../components/LibraryByUserId.vue'

export default {
    name: 'LibraryByUserIdView',
    components: {
        LibraryByUserId,
    },
    data(){
        return {
            userId: '',
        }
    },
    created() {
        this.userId = +this.$route.params.userId
    }
}
</script>

<style>

</style>