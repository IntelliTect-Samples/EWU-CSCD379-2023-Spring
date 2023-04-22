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
    defaultTheme: 'darkCalm',
    themes: {
      darkCalm: {
        dark:true,
        colors: {
          correct: '#538d4e',
          misplaced: '#bfa746',
          wrong: '#3a3a3c',
          default: '#797979',
        }
      },
      lightCalm: {
        colors: {
          correct: '#538d4e',
          misplaced: '#bfa746',
          wrong: '#7d7d7d',
          default: '#d3d6da',
        },
      },
      darkEnergizing: {
        dark:true,
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#3a3a3c',
          default: '#797979',
        }
      },
      lightEnergizing: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336',
          default: '#d3d6da'
        },
      }
    }
  }
})
const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
