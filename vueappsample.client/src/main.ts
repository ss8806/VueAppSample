import './assets/main.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router';

const app = createApp(App)
app.use(router) // Vue Routerを使用する
app.mount('#app')
/*createApp(App).mount('#app')*/
