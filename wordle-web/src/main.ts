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
        dark: true,
        colors: {
          primary: '#1b1b1b',
          correct: '#538d4e',
          misplaced: '#bfa746',
          wrong: '#3a3a3c',
          default: '#797979'
        }
      },
      lightCalm: {
        colors: {
          primary: '#6c6c6c',
          correct: '#538d4e',
          misplaced: '#bfa746',
          wrong: '#7d7d7d',
          default: '#d3d6da'
        }
      },
      darkEnergizing: {
        dark: true,
        colors: {
          primary: '#ffffff',
          correct: '#4CAF50',
          misplaced: '#e78e00',
          wrong: '#3a3a3c',
          default: '#797979'
        }
      },
      lightEnergizing: {
        colors: {
          primary: '#141414',
          correct: '#4CAF50',
          misplaced: '#ef8801',
          wrong: '#F44336',
          default: '#d3d6da'
        }
      },
      darkEaster: {
        dark: true,
        colors: {
          correct: '#00b8ac',
          misplaced: '#6000e7',
          wrong: '#c63ebd',
          default: '#797979'
        }
      },
      lightEaster: {
        colors: {
          correct: '#00b8ac',
          misplaced: '#6000e7',
          wrong: '#c63ebd',
          default: '#d3d6da'
        }
      }
    }
  }
})
const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
