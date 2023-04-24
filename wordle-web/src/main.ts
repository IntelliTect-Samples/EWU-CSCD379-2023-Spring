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
    defaultTheme: 'dark',
    themes: {
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336',
          primary: '#101010',
          surface: "#ffffff"
        }
      },
      inverse: {
        colors: {
          correct: '#F44336',
          misplaced: '#FFC107',
          wrong: '#4CAF50',
          primary: '#eeeeee'
        }
      },
      khorne: {
        colors: {
          correct: '#FFD700',
          misplaced: '#f1c78e',
          wrong: '#101010',
          primary: '#6a0001'
        }
      },
      corn: {
        colors: {
          correct: '#FFD700',
          misplaced: '#9b673c',
          wrong: '#403703',
          primary: '#FFD700',
          background: '#afbd22'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
