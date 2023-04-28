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
    defaultTheme: 'light',
    themes: {
      dark: {
        colors: {
          misplaced: '#FFC107',
          wrong: '#424242',
          correct: '#558B2F',
          background: '#212121',
          secondary: '#212121'
        }
      },
      light: {
        colors: {
          misplaced: '#FFC107',
          wrong: '#BDBDBD',
          correct: '#8BC34A',
          background: '#ECEFF1',
          secondary: '#ECEFF1'
        }
      },
      toxicLight: {
        colors: {
          background: '#BA68C8',
          misplaced: '#FFC107',
          wrong: '#9C27B0',
          correct: '#8BC34A',
          secondary: '#BA68C8'
        }
      },
      toxicDark: {
        colors: {
          background: '#311B92',
          misplaced: '#FFC107',
          wrong: '#5E35B1',
          correct: '#8BC34A',
          secondary: '#311B92'
        }
      },
      oceanLight: {
        colors: {
          background: '#E3F2FD',
          misplaced: '#81D4FA',
          wrong: '#1565C0',
          correct: '#26A69A',
          secondary: '#E3F2FD'
        }
      },
      oceanDark: {
        colors: {
          background: '#1A237E',
          misplaced: '#81D4FA',
          wrong: '#1565C0',
          correct: '#26A69A',
          secondary: '#1A237E'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
