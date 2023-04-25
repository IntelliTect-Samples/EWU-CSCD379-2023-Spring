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
    defaultTheme: "dark",
    themes: {
      dark: {
        colors:{
        misplaced: "",
        wrong: "#2A2A2A",
        correct: "#4CAF50",
        background:"#444444",
        secondary:"#444444"
      }
    },
      light: {
        colors:{
        misplaced: "#FFC107",
        wrong: "#444444",
        correct: "#4CAF50",
        background:"#f4f4f4f4",
        secondary:"#f4f4f4f4"
      }
    },
      toxic: {
        colors:{
        background:"#401D4E",
        misplaced: "#F7DC6F",
        wrong: "#8E44AD",
        correct: "#58D68D",
        secondary:"#401D4E"
      }
    },
      ocean: {
        colors:{
        background: "#1A5276",
        misplaced: "#85C1E9",
        wrong: "#1A72AC",
        correct: "#1ABC9C",
        secondary: "#1A5276"
      }
    },
    }
  }
})


const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')
