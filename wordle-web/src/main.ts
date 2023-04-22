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
      dark:  {
        colors:{
          correct: 'green',
          misplaced: 'yellow',
          wrong: 'red'
        }
      },
      light:  {
        dark: false,
        colors:{
          correct: 'green',
          misplaced: 'yellow',
          wrong: 'red'
        }
      },
      themeOne: {
        colors: {
          correct: '#8A4F7D',
          misplaced: '#64B6AC',
          wrong: '#065A82'
        }
      },
      themeTwo: {
        colors: {
          correct: '#B4CEB3',
          misplaced: '#ED9B40',
          wrong: '#7A4419'
        }
      }
  }    
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
