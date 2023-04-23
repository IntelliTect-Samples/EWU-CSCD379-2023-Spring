<template>
  <v-app-bar id="toolbar">
    <img
      alt="books logo"
      class="logo"
      src="@/assets/books.png"
      width="50"
      height="50"
      color="white"
    />

    <v-app-bar-title>The Good Word</v-app-bar-title>

    <v-btn icon="mdi-arrow-right-bold-hexagon-outline" @click.stop="settings = !settings"></v-btn>

    <v-app-bar-nav-icon @click.stop="menu = !menu"></v-app-bar-nav-icon>
  </v-app-bar>

  <v-navigation-drawer title="Settings" v-model="settings" location="left" app temporary>
    <v-list>
      <v-list-item title="Themes"></v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list density="compact">
      <v-list-item>
        <v-btn @click="toggleLightMode">Light Mode</v-btn>
      </v-list-item>

      <v-list-item>
        <v-btn @click="toggleDarkMode">Dark Mode</v-btn>
      </v-list-item>

      <v-list-item>
        <v-btn @click="toggleCowboyMode">Cowboy</v-btn>
      </v-list-item>

      <v-list-item>
        <v-btn @click="toggleAquaMode">Aqua</v-btn>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>

  <v-navigation-drawer v-model="menu" location="right" app temporary>
    <v-list>
      <v-list-item title="Menu"></v-list-item>
    </v-list>

    <v-divider></v-divider>

    <v-list density="compact">
      <v-list-item>
        <v-btn to="/">Home</v-btn>
      </v-list-item>

      <v-list-item>
        <v-btn to="/about">About</v-btn>
      </v-list-item>

      <v-list-item>
        <v-btn to="/wordle">Play Game</v-btn>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()
let menu = ref(false)
let settings = ref(false)

watch(menu, (val) => {
  if (val) {
    settings.value = false
  }
})

watch(settings, (val) => {
  if (val) {
    menu.value = false
  }
})

function toggleDarkMode() {
  theme.global.name.value = 'dark'
}
function toggleLightMode() {
  theme.global.name.value = 'light'
}
function toggleCowboyMode() {
  theme.global.name.value = 'cowboy'
}
function toggleAquaMode() {
  theme.global.name.value = 'aqua'
}

</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464; /* TODO: Maybe a different color? */
  min-height: 65px;
}
</style>
