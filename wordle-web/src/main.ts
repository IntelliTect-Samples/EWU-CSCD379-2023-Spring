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

const cowboy = {
  dark: false,
  colors: {
    background: '#4E342E',
    surface: '#6D4C41',
    correct: '#4CAF50',
    misplaced: '#EF6C00',
    incorrect: '#D50000',
  }
}

const aqua = {
  dark: true,
  colors: {
    background: '#37474F',
    surface: '#01579B',
    correct: '#4CAF50',
    misplaced: '#EF6C00',
    incorrect: '#D50000',
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
    defaultTheme: "dark",
    themes: {
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#EF6C00',
          incorrect: '#D50000',
          stale: 'grey'
        }
      },
      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#EF6C00',
          incorrect: '#D50000',
          stale: 'grey'
        }
      },
      cowboy,
      aqua,
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
