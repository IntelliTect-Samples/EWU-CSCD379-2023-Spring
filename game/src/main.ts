import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import './assets/main.css'
import { createVuetify } from 'vuetify/lib/framework.mjs'

const vuetify = createVuetify({ components, directives })

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
