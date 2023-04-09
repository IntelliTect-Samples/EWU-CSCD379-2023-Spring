import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'



const vuetify = createVuetify({
    components,
    directives,
    icons: {
        defaultSet: 'mdi',
        sets: {
            mdi
        },
    },
    theme: {
        defaultTheme: 'myCustomTheme',
        themes: {
            myCustomTheme: {
                dark: true,
                colors: {
                    something: '#00ff00',
                    arabicaMint: '#c0ffee'
                }
            }
        }
    },
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
