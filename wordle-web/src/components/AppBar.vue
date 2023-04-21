<template>
  <div>
    <v-card>
      <v-layout>
        <v-app-bar app color="#5439AA">
          <RouterLink to="/"
            ><img id="XelaLogo" alt="Xela Games Logo" class="logo" :src="logo" width="60"
          /></RouterLink>

          <v-app-bar-title id="siteTitle">
            <RouterLink to="/"> Xela Games </RouterLink>
          </v-app-bar-title>

          <!-- Settings Menu -->
          <v-app-bar-nav-icon color="#ffffff">
            <SettingsMenu></SettingsMenu>
          </v-app-bar-nav-icon>

          <v-app-bar-nav-icon color="#ffffff" @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        </v-app-bar>

        <v-navigation-drawer app v-model="drawer" temporary location="end">
          <v-list density="compact" nav>
            <v-list-item title="Home" value="home" to="/"></v-list-item>
            <v-list-item title="About" value="about" to="/about"></v-list-item>
            <v-list-item title="Game" value="game" to="/game"></v-list-item>
            <v-list-item title="Wordle" value="wordle" to="/wordle"></v-list-item>
          </v-list>
        </v-navigation-drawer>
      </v-layout>
    </v-card>
  </div>
  <RouterView />
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
  color: #ffffff;
}
</style>
