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

const pastel = {
  dark: true,
  colors: {
    correct: '#D2FFF3',
    misplaced: '#FFF3D2',
    wrong: '#F3D2FF',
  }
}

const pastelAndLight = {
  dark: false,
  colors: {
    correct: '#D2FFF3',
    misplaced: '#FFF3D2',
    wrong: '#F3D2FF',
    background: '#FFFFFF'
  }
}

const neon = {
  dark: true,
  colors: {
    correct: '#00FFFF',
    misplaced: '#FFFF00',
    wrong: '#FF00FF',
  }
}

const neonAndLight = {
  dark: false,
  colors: {
    correct: '#00FFFF',
    misplaced: '#FFFF00',
    wrong: '#FF00FF',
  }
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
      pastel,
      pastelAndLight,
      neon,
      neonAndLight,
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
