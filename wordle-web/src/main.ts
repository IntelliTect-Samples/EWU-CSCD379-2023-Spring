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
import Axios from 'axios'

//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7053/'
} else {
  Axios.defaults.baseURL = 'https://wordle2023.azurewebsites.net/'
}

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
    defaultTheme: 'dark',
    themes: {
      dark: {
        dark: true,
        colors: {
          correct: '#03fc45',
          misplaced: '#fcf003',
          wrong: '#fc032c'
        }
      },
      light: {
        dark: false,
        colors: {
          correct: '#03fc45',
          misplaced: '#fcf003',
          wrong: '#fc032c'
        }
      },
      unicornDark: {
        dark: true,
        colors: {
          correct: '#8A4F7D',
          misplaced: '#64B6AC',
          wrong: '#065A82'
        }
      },
      unicornLight: {
        dark: false,
        colors: {
          correct: '#8A4F7D',
          misplaced: '#64B6AC',
          wrong: '#065A82'
        }
      },
      pumpkinDark: {
        dark: true,
        colors: {
          correct: '#ff9a00',
          misplaced: '#c900ff',
          wrong: '#CD113B'
        }
      },
      pumpkinLight: {
        dark: false,
        colors: {
          correct: '#ff9a00',
          misplaced: '#c900ff',
          wrong: '#CD113B'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
