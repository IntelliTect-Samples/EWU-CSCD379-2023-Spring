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


//Check if the app is running on localhost
if (window.location.hostname === 'localhost' || window.location.hostname === '127.0.0.1') {
  Axios.defaults.baseURL = 'http://localhost:5006/'
} else {
  Axios.defaults.baseURL = 'https://wordle2023-nparkman.azurewebsites.net'
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
          primary: '#B2EBF2',
          surface: '#37474F',
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      light: {
        colors: {
          primary: '#B2EBF2',
          surface: '#E0F7FA',
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      Protanopia_Deuteranopia: {
        dark: true,
        colors: {
          primary: '#1A237E',
          surface: '#7986CB',
          correct: '#0D47A1',
          misplaced: '#FFFF00',
          wrong: '#795548'
        }
      },
      Tritanopia: {
        dark: true,
        colors: {
          primary: '#311B92',
          surface: '#5E35B1',
          correct: '#546E7A',
          misplaced: '#FCE4EC',
          wrong: '#FF1744'
        }
      },
      Protanopia_DeuteranopiaLight: {
        dark: false,
        colors: {
          primary: '#1A237E',
          surface: '#7986CB',
          correct: '#0D47A1',
          misplaced: '#FFFF00',
          wrong: '#795548'
        }
      },
      TritanopiaLight: {
        dark: false,
        colors: {
          primary: '#311B92',
          surface: '#5E35B1',
          correct: '#546E7A',
          misplaced: '#FCE4EC',
          wrong: '#FF1744'
        }
      }
    }
  }
})
const app = createApp(App)

// Create basic services
const signInService = reactive(SignInService.instance)
app.provide(Services.SignInService, signInService)

app.use(vuetify)

app.use(router)

app.mount('#app')
