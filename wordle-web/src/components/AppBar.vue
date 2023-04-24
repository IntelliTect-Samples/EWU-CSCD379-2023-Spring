<template>
  <v-card class="mx-auto" max-width="448" zIndex="0">
    <v-layout>
      <v-app-bar density="compact">
        <template v-slot:prepend>
          <v-btn icon="mdi-menu" @click.stop="hamburgerDrawer = !hamburgerDrawer"> </v-btn>
        </template>
        <v-icon icon="mdi-head-cog" @click.stop="$router.push('/')" size="x-large"></v-icon>
        <v-app-bar-title @click.stop="$router.push('/')">Wordle</v-app-bar-title>
        <template v-slot:append>
          <v-btn icon="mdi-cog" @click.stop="settingDrawer = !settingDrawer"> </v-btn>
        </template>
      </v-app-bar>

      <v-navigation-drawer temporary v-model="hamburgerDrawer" location="left">
      </v-navigation-drawer>

      <v-navigation-drawer v-model="settingDrawer" location="right">
        <v-list>
          <v-btn @click="setInverseTheme"> Inverse Theme </v-btn>
          <v-btn @click="setDarkTheme"> Dark Theme </v-btn>
        </v-list>
      </v-navigation-drawer>
      <v-main> </v-main>
    </v-layout>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
const hamburgerDrawer = ref(false)
const settingDrawer = ref(false)
</script>
