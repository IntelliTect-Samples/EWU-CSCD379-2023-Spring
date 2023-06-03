import { createApp, reactive } from 'vue'
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
import { Services } from './scripts/services'
import { SignInService } from './scripts/signInService'
import { PlayerService } from './scripts/playerService'

//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'https://localhost:7053/'
} else {
  Axios.defaults.baseURL = 'https://wordle2023.azurewebsites.net/'
}

// Provide the useDisplay to other components so that it can be used in testing.

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
          wrong: '#F44336',
          unknown: '#222222'
        }
      },
      light: {
        colors: {
          correct: '#6CCF70',
          misplaced: '#FFD137',
          wrong: '#F46356',
          unknown: '#eeeeee'
        }
      }
    }
  }
})

const app = createApp(App)

// Create basic services
const signInService = reactive(SignInService.instance)
app.provide(Services.SignInService, signInService)

const playerService = new PlayerService()
playerService.setupPlayerAsync()
app.provide(Services.PlayerService, playerService)

app.use(vuetify)

app.use(router)

app.mount('#app')
