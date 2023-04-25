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
          correct: '#64AF6A',
          misplaced: '#FFEA61',
          wrong: '#EA4C46',
          surface: '#271a52',
          primary: '#5439AA',
          secondary: '#27AE6A'
        }
      },

      light: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFEB3B',
          wrong: '#F44336',
          surface: '#afa2da',
          primary: '#7555d9',
          secondary: '#4c3791'
        }
      },

      oceanLight: {
        colors: {
          correct: '#F5F8FC',
          misplaced: '#3079CC',
          wrong: '#112B48',
          background: '#B9D2EE',
          surface: '#B9D2EE',
          primary: '#2865AB',
          secondary: '#498AD4'
        }
      },

      oceanDark: {
        colors: {
          correct: '#F5F8FC',
          misplaced: '#3079CC',
          wrong: '#112B48',
          background: '#06172B',
          surface: '#06172B',
          primary: '#2865AB',
          secondary: '#498AD4'
        }
      },

      desertLight: {
        colors: {
          correct: '#FEDFC9',
          misplaced: '#FF781E',
          wrong: '#B34700',
          background: '#FFB380',
          surface: '#FFB380',
          primary: '#FF7316',
          secondary: '#FC6500'
        }
      },

      desertDark: {
        colors: {
          correct: '#FEDFC9',
          misplaced: '#FF781E',
          wrong: '#B34700',
          background: '#5C2602',
          surface: '#5C2602',
          primary: '#FF7316',
          secondary: '#FC6500'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
