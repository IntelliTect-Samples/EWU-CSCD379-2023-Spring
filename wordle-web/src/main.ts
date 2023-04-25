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
    defaultTheme: "dark",
    themes: {
      dark: {
        colors: {
          primary: 'grey',
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      inverse: {
        colors: {
          primary: 'grey',
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      darkDark: {
        dark: true,
        colors: {
          primary: '#0000',
          secondary: '#0000',
          correct: '#013220',
          misplaced: '#696700',
          wrong: '#671B0E'
        }
      },
      neon: {
        dark: true,
        colors: {
          primary: '#bf00ff',
          secondary: '#0000',
          correct: '#39ff14',
          misplaced: '#fefe22',
          wrong: '#ff2400 '
        }
      },


    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
