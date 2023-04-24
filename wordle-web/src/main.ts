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
    }
  },
  theme: {
    defaultTheme: 'light',
    themes: {
      christmas: {
        colors: {
          primary: '#c54245',
          secondary: '#346633',
          background: '#346633',
          surface: '#346633'
        }
      },
      halloween: {
        colors: {
          primary: '#E66C2C',
          secondary: '#E66C2C',
          background: '#121212',
          surface: '#121212'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
