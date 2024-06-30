<template>
    <h1>Todo List</h1>

    <input class="inputText"
           placeholder="Wreite Todo"
           v-on:keydown.shift.enter="addItem"
           v-model=todoItem />

    <button class="btn add_todo" v-on:click="addItem">
        Add Todo
    </button>

    <ul v-for="item in items" :key="items.id">
        <li>{{ item.name }} : {{ item.isComplete }}</li>
    </ul>


</template>

<script setup lang="ts">
    import { ref, onMounted, defineComponent } from 'vue';
    import axios from "axios";

    type Items = {
        name: string;
        isComplete: bool
    };

    let items = ref<[Items]>([]);
    let todoItem = ref("");

    const getTodo = () => {
        axios.get("https://localhost:7225/api/Todoitems")
            .then(response => {
                items.value = response.data
                console.log(response.data)
            })
            .catch(error => {
                console.log(error)
            })
    };

    const addItem = async () => {
        if (todoItem !== "") {
            await axios.post("https://localhost:7225/api/Todoitems", {
                name: todoItem.value,
                isComplete: false,
            })

        }
        // Ä“Ç‚Ýž‚Ý
        await getTodo();

    };

    //DOM“Ç‚Ýž‚ÝŒã‚É“WŠJ‚·‚é
    onMounted(async () => {
        await getTodo();
    })

</script>

<style>
</style>