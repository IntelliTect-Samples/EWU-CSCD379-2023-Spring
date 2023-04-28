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
          primary:'#000000',
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      inverse: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336'
        }
      },
      rainbow:{
        colors:{
          background: '#FF0000',
          surface: '#FF7F00',
          primary: '#FFFF00',
          secondary:'#0000FF',
          correct: '#00FF00',
          misplaced:'#FFFF00',
          wrong:'9400D3',
        }
      },
      zen:{
        colors:{
          background: '#C9DC87',
          surface: '#080808',
          primary: '#DCD0FF',
          secondary: '#DDE26A',
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
