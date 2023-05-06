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

<<<<<<< Updated upstream
//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
<<<<<<< Updated upstream
  Axios.defaults.baseURL = 'https://localhost:7053/'
} else {
  Axios.defaults.baseURL = 'wordletest2023.azurewebsites.net/'
=======
  Axios.defaults.baseURL = 'https://localhost:5173/'
} else {
  Axios.defaults.baseURL = 'wordleJB.azurewebsites.net/'
>>>>>>> Stashed changes
=======
if (process.env.NODE_ENV === 'development') {
  Axios.defaults.baseURL = 'http://localhost:5001/'
} else {
  Axios.defaults.baseURL = 'https://wordleJB.azurewebsites.net/'
>>>>>>> Stashed changes
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
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      inverse: {
        colors: {
          correct: '#F44336',
          misplaced: '#FFC107',
          wrong: '#4CAF50'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
