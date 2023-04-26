<template>
  <v-app-bar id="toolbar">
    <img
      alt="books logo"
      class="logo"
      src="@/assets/books.png"
      width="50"
      height="50"
      @click="router.push('/')"
    />

    <v-app-bar-title @click="router.push('/')">The Good Word</v-app-bar-title>

    <v-btn icon="mdi-cog" @click.stop="settings = !settings"></v-btn>

    <v-app-bar-nav-icon @click.stop="menu = !menu"></v-app-bar-nav-icon>
  </v-app-bar>

  <v-dialog width="350px" title="Settings" v-model="settings" app temporary>
    <v-card rounded="lg">
      <v-card-title id="card-title" elevation="6">
        <v-icon>mdi-cog</v-icon> Settings
        <v-btn icon @click.stop="settings = !settings" class="float-right">
          <v-icon class="float-right">mdi-close</v-icon>
        </v-btn>
      </v-card-title>

      <v-list density="compact" class="pa-3">
        <v-list-item-title>Theme</v-list-item-title>
        <v-divider class="py-3"></v-divider>
        <v-list-item>
          <v-card color="#424242">
            <v-btn color="white" @click="toggleLightMode">Light Mode</v-btn>
            <v-card-text> Correct: Green </v-card-text>
            <v-card-text> Misplaced: Orange </v-card-text>
            <v-card-text> Wrong: Red </v-card-text>
          </v-card>
        </v-list-item>

        <!--        <v-divider></v-divider>-->

        <v-list-item>
          <v-card color="#424242">
            <v-btn color="black" @click="toggleDarkMode">Dark Mode</v-btn>
            <v-card-text> Correct: Green </v-card-text>
            <v-card-text> Misplaced: Orange </v-card-text>
            <v-card-text> Wrong: Red </v-card-text>
          </v-card>
        </v-list-item>

        <!--        <v-divider></v-divider>-->

        <v-list-item>
          <v-card color="#424242">
            <v-btn color="#6D4C41" @click="toggleCowboyMode">Cowboy</v-btn>
            <v-card-text> Correct: Blue </v-card-text>
            <v-card-text> Misplaced: Light-Orange </v-card-text>
            <v-card-text> Wrong: Blue-Grey </v-card-text>
          </v-card>
        </v-list-item>

        <!--        <v-divider></v-divider>-->

        <v-list-item>
          <v-card color="#424242">
            <v-btn color="#01579B" @click="toggleAquaMode">Aqua</v-btn>
            <v-card-text> Correct: Teal </v-card-text>
            <v-card-text> Misplaced: Yellow </v-card-text>
            <v-card-text> Wrong: Pink </v-card-text>
          </v-card>
        </v-list-item>
      </v-list>
    </v-card>
  </v-dialog>

  <v-navigation-drawer v-model="menu" location="right" app temporary>
    <v-list density="compact">
      <v-list-item title="Menu" class="py-6"></v-list-item>
      <v-divider class="py-3"></v-divider>
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
import router from '@/router'

const theme = useTheme()
let menu = ref(false)
let settings = ref(false)

// watch(menu, (val) => {
//   if (val) {
//     settings.value = false
//   }
// })

watch(settings, (val) => {
  if (val) {
    menu.value = false
  }
})

function toggleDarkMode() {
  theme.global.name.value = 'dark'
  localStorage.setItem('theme', 'dark')
}
function toggleLightMode() {
  theme.global.name.value = 'light'
  localStorage.setItem('theme', 'light')
}
function toggleCowboyMode() {
  theme.global.name.value = 'cowboy'
  localStorage.setItem('theme', 'cowboy')
}
function toggleAquaMode() {
  theme.global.name.value = 'aqua'
  localStorage.setItem('theme', 'aqua')
}
</script>

<style scoped>
#toolbar {
  width: 100%;
  padding: 6px 24px;
  font-size: 26px;
  font-weight: bold;
  border-bottom: 1px solid #656464;
  min-height: 65px;
}

#card-title {
  border-bottom: 1px solid;
}
</style>
