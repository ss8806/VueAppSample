<template>


    <button class="Home" v-on:click="pushPage()">
        Home
    </button>

    <h1>Todo List</h1>

    <input class="inputText"
           placeholder="Write Todo"
           v-on:keydown.shift.enter="addItem"
           v-model=todoItem />

    <button class="btn add_todo" v-on:click="addItem">
        Add Todo
    </button>

    <ul>
        <li v-for="item in items" :key="items.id">
            <span v-if="!item.edit"
                  v-text="item.name"
                  v-on:click="changeEdit(item)">
            </span>
            <input :type="text"
                   v-if="item.edit"
                   v-model="item.name"
                   v-on:keydown.shift.enter="updateItem(item.id, item)">
            <button class="btn del_todo" v-on:click="delItem(item.id)">
                Del
            </button>

        </li>

    </ul>
</template>

<script setup lang="ts">
    import { ref, onMounted, defineComponent } from 'vue';
    import axios from "axios";
    import { useRouter } from 'vue-router'

    type Items = {
        name: string;
        isComplete: bool
    };

    let items = ref<[Items]>([]);
    let todoItem = ref("");

    const router = useRouter();

    const pushPage = () => {
        router.push({ path: "/" });
    };

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

            todoItem = '';

        }
        // Ä“Ç‚Ýž‚Ý
        await getTodo();

    };

    const delItem = async (id) => {
        await axios.delete("https://localhost:7225/api/Todoitems/" + id)
        // Ä“Ç‚Ýž‚Ý
        await getTodo();

    };

    const changeEdit = (item) => {
        item.edit = true;
    };

    const updateItem = async (id, item) => {
        if (item.name === '') {
            await delItem(id)
        }
        await axios.put("https://localhost:7225/api/Todoitems/" + id, {
            id: item.id,
            name: item.name,
            isComplete: item.isComplete,
        })
        // Ä“Ç‚Ýž‚Ý
        await getTodo();
        item.edit = false;
    };

    //DOM“Ç‚Ýž‚ÝŒã‚É“WŠJ‚·‚é
    onMounted(async () => {
        await getTodo();
    })

</script>

<style>
</style>