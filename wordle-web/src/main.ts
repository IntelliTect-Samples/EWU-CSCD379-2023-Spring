import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { mdi } from 'vuetify/iconsets/mdi'

import './assets/main.css'
import '@mdi/font/css/materialdesignicons.css'

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import colors from 'vuetify/lib/util/colors'
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
          misplaced: colors.amber.lighten1,
          wrong: colors.grey.darken1,
          correct: colors.lightGreen.darken1,
          background: colors.grey.darken4,
          secondary: colors.grey.darken4
        }
      },
      light: {
        colors: {
          misplaced: colors.amber.darken1,
          wrong: colors.grey.lighten1,
          correct: colors.green.lighten1,
          background: colors.grey.lighten4,
          secondary: colors.grey.lighten4
        }
      },
      // Add Toxic Light, Ocean Light
      toxicLight: {
        colors: {
          background: colors.purple.lighten1,
          misplaced: colors.amber.lighten1,
          wrong: colors.purple.darken1,
          correct: colors.green.lighten1,
          secondary: colors.purple.lighten1
        }
      },
      toxicDark: {
        colors: {
          background: colors.purple.darken4,
          misplaced: colors.amber.darken1,
          wrong: colors.purple.darken2,
          correct: colors.green.lighten1,
          secondary: colors.purple.darken4
        }
      },
      oceanLight: {
        colors: {
          background: colors.blue.lighten5,
          misplaced: colors.lightBlue.lighten2,
          wrong: colors.blue.darken2,
          correct: colors.teal.lighten1,
          secondary: colors.blue.lighten5
        }
      },
      oceanDark: {
        colors: {
          background: colors.indigo.darken4,
          misplaced: colors.lightBlue.lighten2,
          wrong: colors.blue.darken2,
          correct: colors.teal.lighten1,
          secondary: colors.indigo.darken4
        }
      }
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
