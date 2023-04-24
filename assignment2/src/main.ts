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
    primary: '#bfbfbf',
    correct: '#1e6b1e',
    misplaced: '#eba10d',
    wrong: '#6d1212',
    unknown: '#7979a0'
  }
}
const autumnDark = {
  dark: true,
  colors: {
    primary: '#ff4500',
    correct: '#e65400',
    misplaced: '#d69200',
    wrong: '#9d0e01',
    unknown: '#a44b1e'
  }
}
const coffeeDark = {
  dark: true,
  colors: {
    primary: '#c17149',
    correct: '#c86a1e',
    misplaced: '#cb864d',
    wrong: '#612c00',
    unknown: '#a0532c'
  }
}
const unicornVomitDark = {
  dark: true,
  colors: {
    primary: '#ff0066',
    correct: '#89d813',
    misplaced: '#9999ff',
    wrong: '#ff0066',
    unknown: '#cc3399'
  }
}
const defaultLight = {
  dark: false,
  colors: {
    primary: '#333333',
    correct: '#1e6b1e',
    misplaced: '#eba10d',
    wrong: '#6d1212',
    unknown: '#505050'
  }
}
const autumnLight = {
  dark: false,
  colors: {
    primary: '#a51900',
    correct: '#e65400',
    misplaced: '#d69200',
    wrong: '#9d0e01',
    unknown: '#a44b1e'
  }
}
const coffeeLight = {
  dark: false,
  colors: {
    primary: '#4b2a1b',
    correct: '#c86a1e',
    misplaced: '#cb864d',
    wrong: '#612c00',
    unknown: '#a0532c'
  }
}
const unicornVomitLight = {
  dark: false,
  colors: {
    primary: '#ff0066',
    correct: '#89d813',
    misplaced: '#9999ff',
    wrong: '#ff0066',
    unknown: '#cc3399'
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
      defaultDark, defaultLight, autumnDark, autumnLight, coffeeDark, coffeeLight, unicornVomitDark, unicornVomitLight
    }
  }
})

const app = createApp(App)

app.use(vuetify)

app.use(router)

app.mount('#app')