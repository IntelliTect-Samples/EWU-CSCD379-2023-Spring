<template>
  <v-app>
    <v-app-bar color="primary" elevation="2">
      <img
        id="XelaLogo"
        alt="Xela Games Logo"
        class="logo ms-4"
        :src="logo"
        width="60"
        @click="$router.push('/')"
      />

      <v-app-bar-title font-size="" id="siteTitle" @click="$router.push('/')">
        Xela Games
      </v-app-bar-title>

      <v-app-bar-nav-icon>
        <SettingsMenu></SettingsMenu>
      </v-app-bar-nav-icon>

      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" temporary location="end">
      <v-list>
        <v-list-item title="Home" value="home" to="/"></v-list-item>
        <v-list-item title="About" value="about" to="/about"></v-list-item>
        <v-list-item title="Game" value="game" to="/game"></v-list-item>
        <v-list-item title="Wordle" value="wordle" to="/wordle"></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container>
        <RouterView />
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import logo from '@/assets/Xela_Games_Logo.png'
import SettingsMenu from '@/components/SettingsMenu.vue'
</script>

<script lang="ts">
export default {
  data() {
    return {
      drawer: false,
      dialog: false
    }
  }
}
</script>

<style scoped>
#siteTitle {
  font-size: 26px;
}
</style>
