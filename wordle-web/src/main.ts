import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

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
      christmas: {
        colors: {
          correct: '#346633',
          misplaced: '#D3D3D3',
          wrong: '#c54245',
          primary: '#c54245'
        }
      },
      halloween: {
        colors: {
          correct: '#E66C2C',
          misplaced: '#D3D3D3',
          wrong: '#121212',
          primary: '#E66C2C'
        }
      },
      dark: {
        colors: {
          correct: '#4CAF50',
          misplaced: '#FFC107',
          wrong: '#F44336',
          primary: '#000000'
        }
      },
      light: {
        colors: {
          correct: '#F44336',
          misplaced: '#FFC107',
          wrong: '#4CAF50',
          primary: '#DEE4E7'
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
