import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

// Vuetify.
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
import Axios from 'axios'

// Check if the app is running on localhost.
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7053/'
} else {
  Axios.defaults.baseURL = 'https://wordleweb2023.azurewebsites.net/'
}

const app = createApp(App)
const themeInUse = localStorage.getItem('theme') || 'aqua'
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
    defaultTheme: themeInUse,
    themes: {
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#EF6C00',
          wrong: '#D50000',
          unknown: '#9E9E9E'
        }
      },
      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#EF6C00',
          wrong: '#D50000',
          unknown: '#9E9E9E'
        }
      },
      cowboy: {
        dark: false,
        colors: {
          background: '#4E342E',
          surface: '#6D4C41',
          correct: '#01579B',
          misplaced: '#FF7043',
          wrong: '#263238',
          unknown: '#A1887F'
        }
      },
      aqua: {
        dark: true,
        colors: {
          background: '#37474F',
          surface: '#01579B',
          correct: '#009688',
          misplaced: '#CDDC39',
          wrong: '#C51162',
          unknown: '#4FC3F7'
        }
      }
    }
  }
})

app.use(vuetify)
app.use(router)
app.mount('#app')
