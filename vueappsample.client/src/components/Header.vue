<template>
   {{msg}}
</template>

<script setup lang="ts">
    import { ref } from 'vue';

    const props = defineProps({
        msg: String
    })
  

</script>

<style>
</style>