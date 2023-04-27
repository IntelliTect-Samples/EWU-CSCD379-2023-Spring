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
    defaultTheme: 'defaultDark',
    themes: {
      defaultDark: {
        dark: true,
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      defaultLight: {
        dark: false,
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      neonDark: {
        dark: true,
        colors: {
          correct: '#00FFFF',
          misplaced: '#FFFF00',
          wrong: '#FF00FF'
        }
      },
      neonLight: {
        dark: false,
        colors: {
          correct: '#00FFFF',
          misplaced: '#FFFF00',
          wrong: '#FF00FF'
        }
      },
      pastelDark: {
        dark: true,
        colors: {
          correct: '#D2FFF3',
          misplaced: '#FFF3D2',
          wrong: '#F3D2FF'
        }
      },
      pastelLight: {
        dark: false,
        colors: {
          correct: '#D2FFF3',
          misplaced: '#FFF3D2',
          wrong: '#F3D2FF',
          background: '#FFFFFF'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
