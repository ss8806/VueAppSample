import { createRouter, createWebHistory } from 'vue-router';
import Home from "./components/TheWelcome.vue";
import Todo from "./components/Todo.vue";

const routes = [
    { path: '/', name: 'home', component: Home },
    { path: '/todo', name: 'todo', component: Todo },
]

const router = createRouter({
    history: createWebHistory(), // HTML5 History ÉÇÅ[Éh
    routes,
})

export default router;