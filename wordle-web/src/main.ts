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
    defaultTheme: 'Dark',
    themes: {
      Dark: {
        dark: true,
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
          
        }
      },
      Light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      Inverse: {
        colors: {
          correct: '#F44336',
          misplaced: '#FFC107',
          wrong: '#4CAF50'
        }
      },
      DarkDelight: {
        dark: true,
        colors: {
          correct: '#64B5F6',
          misplaced: '#FFCE07',
          wrong: '#AA00FF'
        }
      },
      LightDelight: {
        colors: {
          correct: '#64B5F6',
          misplaced: '#FFCE07',
          wrong: '#AA00FF'
        }
      },
      DarkClam: {
        dark: true,
        colors: {
          correct: '#C5E1A5',
          misplaced: '#F0F4C3',
          wrong: '#FFCDD2'
        }
      },
      LightClam: {
        colors: {
          correct: '#C5E1A5',
          misplaced: '#F0F4C3',
          wrong: '#FFCDD2'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
