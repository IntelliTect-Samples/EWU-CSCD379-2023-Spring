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

const defaultDark = {
  dark: true,
  colors: {
    primary: '#ff4500',
  }
}
const defaultLight = {
  dark: false,
  colors: {
    primary: '#660066',
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
    defaultTheme: 'defaultDark',
    themes: {
      defaultDark, defaultLight,
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')