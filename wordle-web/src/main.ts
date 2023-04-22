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
          correct: '#599c5b',
          misplaced: '#c1a03e',
          wrong: '#b2564f'
        }
      },
      lightCalm: {
        colors: {
          correct: '#5ebb61',
          misplaced: '#d7b942',
          wrong: '#c35e57'
        },
      },
      darkEnergizing: {
        dark:true,
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      lightEnergizing: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        },
      }
    }
  }
})
const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
