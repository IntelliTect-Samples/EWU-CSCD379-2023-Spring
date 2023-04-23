<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" fullscreen :scrim="false" transition="dialog-bottom-transition">
      <template v-slot:activator="{ props }">
        <v-btn dark v-bind="props">
          <v-icon>mdi-cog</v-icon>
        </v-btn>
      </template>
      <v-card>
        <!-- HEADER BAR-->
        <v-toolbar dark>
          <v-btn icon dark @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
          <v-toolbar-title>Settings</v-toolbar-title>
          <v-spacer></v-spacer>
        </v-toolbar>

        <v-divider></v-divider>
        <!-- Body-->
        <v-btn @click="toggleDefaultLight">Change Color To Default Light Mode</v-btn>
        <v-btn @click="toggleDefaultDark">Change Color To Default Dark Mode</v-btn>
        <v-btn @click="toggleTheme2Light">Change Color To Ocean Light</v-btn>
        <v-btn @click="toggleTheme2Dark">Change Color To Ocean Dark</v-btn>
        <v-btn @click="toggleTheme3Light">Change Color To Forest Light</v-btn>
        <v-btn @click="toggleTheme3Dark">Change Color To Forest Dark</v-btn>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify'

export default {
  data() {
    const theme = useTheme()

    return {
      dialog: false,
      theme,
      toggleDefaultLight: () => (theme.global.name.value = 'light'),
      toggleDefaultDark: () => (theme.global.name.value = 'dark'),
      toggleTheme2Light: () => (theme.global.name.value = 'oceanlight'),
      toggleTheme2Dark: () => (theme.global.name.value = 'oceandark'),
      toggleTheme3Light: () => (theme.global.name.value = 'forestlight'),
      toggleTheme3Dark: () => (theme.global.name.value = 'forestdark')
    }
  }
}
</script>

<style>
.dialog-bottom-transition-enter-active,
.dialog-bottom-transition-leave-active {
  transition: transform 0.2s ease-in-out;
}
</style>
