<template>
    <h1>Todo List</h1>
    <tr v-for="item in items" :key="items.name">
        <td>{{ item.name }}</td>
    </tr>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from "axios";


    //axios.defaults.baseURL = 'http://localhost:7225';
    //axios.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
    //axios.defaults.headers.post['Access-Control-Allow-Origin'] = '*';

    export default defineComponent({
        components: {
        },
        directives: {
        },
        filters: {
        },
        props: {

        },
        data() {
            return {
                items: [],
            }
        },
        computed: {
        },
        watch: {
        },
        beforeCreate() {
        },
        created() {
            this.getTodo();
        },
        beforeMount() {
        },
        mounted() {
            
        },
        updated() {
        },
        activated() {
        },
        deactivated() {
        },
        beforeDestroy() {
        },
        destroyed() {
        },
        methods: {

            getTodo: function () {
                axios.get("https://localhost:7225/api/Todoitems")
                    .then(response => {
                        this.items = response.data
                        console.log(response.data)
                    })
                    .catch(err => {
                        console.error(err)
                    })
            }

        },
    });
</script>

<style>
</style>