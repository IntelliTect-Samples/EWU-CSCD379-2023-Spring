import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

import '@mdi/font/css/materialdesignicons.css'
import './assets/main.css'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const MossyWoodland = {
  dark: true,
  colors: {
    correct: '#18392b',
    misplaced: '#6b4318',
    wrong: '#4E342E',
    notGuessed: '#524945'
  }
}

const MossyWoodlandLight = {
  dark: false,
  colors: {
    correct: '#17734c',
    misplaced: '#ab661b',
    wrong: '#7a4b40',
    notGuessed: '#8f7f78'
  }
}

const OceanMist = {
  dark: false,
  colors: {
    correct: '#057ffa',
    misplaced: '#31a5f7',
    wrong: '#74a3cc',
    notGuessed: '#c1d4e6'
  }
}

const OceanMistDark = {
  dark: true,
  colors: {
    correct: '#032dff',
    misplaced: '#1683f7',
    wrong: '#5c86ab',
    notGuessed: '#abbdcf'
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
    defaultTheme: 'light',
    themes: {
      MossyWoodland,
      MossyWoodlandLight,
      OceanMist,
      OceanMistDark,
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336',
          notGuessed: '#9E9E9E',
          background: '#212121'
        }
      },
      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336',
          notGuessed: '#9E9E9E'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
