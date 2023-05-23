<!--
---- Component to 'HeaderAppBar.vue', responsible for the settings card UI.
--->

<template>
  <v-dialog transition="fab-transition" width="350px" title="Settings" temporary>
    <v-card rounded="lg">
      <v-card-title id="card-title" elevation="6">
        <v-icon>mdi-cog</v-icon> Settings
        <v-btn icon @click.stop="emitSettingsCardValue(false)" class="float-right">
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

        <v-list-item>
          <v-card color="#424242">
            <v-btn color="black" @click="toggleDarkMode">Dark Mode</v-btn>
            <v-card-text> Correct: Green </v-card-text>
            <v-card-text> Misplaced: Orange </v-card-text>
            <v-card-text> Wrong: Red </v-card-text>
          </v-card>
        </v-list-item>

        <v-list-item>
          <v-card color="#424242">
            <v-btn color="#6D4C41" @click="toggleCowboyMode">Cowboy</v-btn>
            <v-card-text> Correct: Blue </v-card-text>
            <v-card-text> Misplaced: Light-Orange </v-card-text>
            <v-card-text> Wrong: Blue-Grey </v-card-text>
          </v-card>
        </v-list-item>

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
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()
const emit = defineEmits<{
  // Emits new name value to parent component.
  (event: 'updateSettingsCardValue', value: boolean): void
}>()

function emitSettingsCardValue(newValue: boolean) {
  emit('updateSettingsCardValue', newValue)
}

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

<style>
#card-title {
  border-bottom: 1px solid;
}
</style>
