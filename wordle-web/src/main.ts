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
    defaultTheme: "dark",
    themes: {
      dark:{
        colors: {
          correct: '#4caf50',
          misplaced: '#ffc107',
          wrong: '#f44336',
        }
      },
      inverse: {
        colors: {
          correct: '#F44336',
          misplaced: '#03A9F4',
          wrong: '#4CAF50',
        }
      },

      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFEB3B',
          wrong: '#F44336',
        }
      },

      pastel: {
        colors: {
          correct: '#66BB6A',
          misplaced: '#FFF176',
          wrong: '#EF5350',
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
