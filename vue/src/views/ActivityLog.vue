<template>
<section class="activityLog">
  <h1>Activity Log</h1>
  <ActivityLog />
</section>
</template>

<script>
import ActivityLog from '../components/ViewActivity.vue'


export default {
    name: 'Activity',
    components:{
        ActivityLog,
    },
}
</script>

<style>
.library{
  justify-content: space-evenly;

}

</style>