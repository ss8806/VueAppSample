<template>
    <h1>{{msg}}</h1>
    
</template>

<script setup lang="ts">
    import { ref } from 'vue';

    const props = defineProps({
        msg: String
    })
  

</script>

<style>
</style>