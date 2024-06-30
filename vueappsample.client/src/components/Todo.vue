<template>
    <h1>Todo List</h1>
    <ul v-for="item in items" :key="items.id">
        <li>{{ item.name }}</li>
    </ul>
</template>

<script setup lang="ts">
    import { ref, onMounted, defineComponent } from 'vue';
    import axios from "axios";


    type Items = {
        name: string;
    };

    let items = ref([]);

    const getTodo = async () => {
        axios.get("https://localhost:7225/api/Todoitems")
            .then(response => {
                items.value = response.data
                console.log(response.data)
            })
            .catch(error => {
                console.log(error)
            })
    };

    //DOM“Ç‚Ýž‚ÝŒã‚É“WŠJ‚·‚é
    onMounted(async () => {
        await getTodo();
    })

</script>

<style>

</style>