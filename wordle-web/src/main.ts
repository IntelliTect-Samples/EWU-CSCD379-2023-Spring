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

const easter = {
  dark: true,
  colors: {
    background: "#90CAF9",
    surface: "#EA80FC",
    primary: "#FFF59D",
    secondary: "#BBDEFB",
    error: "#C51162",
    info: "#2196F3",
    success: "#1DE9B6",
    warning: "#FFB74D",
  },
};
const christmasSweater = {
  dark: true,
  colors: {
    background: "#D50000",
    surface: "#66BB6A",
    primary: "#00B0FF",
    secondary: "#FFEE58",
    error: "#f44336",
    info: "#FAFAFA",
    success: "#76FF03",
    warning: "#fb8c00",
  },
};

const vuetify = createVuetify({
  components,
  directives,
  theme: {
    defaultTheme: 'dark',
    themes: {
      christmasSweater,
      easter,
    }

  },
  icons: {
    defaultSet: 'mdi',
    sets: {
        mdi
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
