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
  display: {
    mobileBreakpoint: 'sm',
    thresholds: {
      xs: 0,
      sm: 340,
      md: 540,
      lg: 800,
      xl: 1280
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
          primary: '#000000'
        }
      },
      inverse: {
        colors: {
          correct: '#F44336',
          misplaced: '#FFC107',
          wrong: '#4CAF50',
          primary: '#DEE4E7'
        }
      },
      calm: {
        colors: {
          correct: '#70877F',
          misplaced: '#C4A77D',
          wrong: '#EF946C',
          primary: '#2F2963',
          background: '454372'
        }
      },
      colorful: {
        colors: {
          correct: '#1B998B',
          misplaced: '#FFFD82',
          wrong: '#E84855',
          primary: '#2D3047',
          background: '454372'
        }
      },
      darkCalm: {
        dark: true,
        colors: {
          correct: '#70877F',
          misplaced: '#C4A77D',
          wrong: '#EF946C',
          primary: '#2F2963',
          background: '454372'
        }
      },
      darkColorful: {
        dark: true,
        colors: {
          correct: '#1B998B',
          misplaced: '#FFFD82',
          wrong: '#E84855',
          primary: '#2D3047',
          background: '454372'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
