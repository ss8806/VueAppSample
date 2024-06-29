<template>
    todo sample
</template>

<script lang="ts">
    import { defineComponent } from 'vue';
    import axios from "axios";


    //axios.defaults.baseURL = 'http://localhost:7059';
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
            }
        },
        computed: {
        },
        watch: {
        },
        beforeCreate() {
        },
        created() {

        },
        beforeMount() {
        },
        mounted() {
           
            this.getTodo();

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
                        this.result = response.data
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