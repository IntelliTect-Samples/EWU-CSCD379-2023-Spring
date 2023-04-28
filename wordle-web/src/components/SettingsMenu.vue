<template>
  <v-dialog transition="dialog-bottom-transition" scrollable width="auto">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" prepend-icon="mdi-cog" @keydown.enter.prevent></v-btn>
    </template>
    <template v-slot:default="{ isActive }">
      <v-card>
        <v-card-title>Wordle Settings</v-card-title>
        <v-divider></v-divider>

        <v-card-text>
          <v-list>
            <v-list-item>
              <v-btn prepend-icon="mdi-weather-sunny" @click="setDarkTheme"> Dark Mode </v-btn>
            </v-list-item>

            <v-list-item>
              <v-btn prepend-icon="mdi-weather-night" @click="setInverseTheme"> Light Mode </v-btn>
            </v-list-item>

            <v-list-item>
              <v-btn prepend-icon="mdi-bottle-tonic-skull" @click="setToxicLightTheme">
                Toxic Light
              </v-btn>
            </v-list-item>

            <v-list-item>
              <v-btn prepend-icon="mdi-bottle-tonic-skull" @click="setToxicDarkTheme">
                Toxic Dark
              </v-btn>
            </v-list-item>

            <v-list-item>
              <v-btn prepend-icon="mdi-tsunami" @click="setOceanLightTheme"> Ocean Light </v-btn>
            </v-list-item>

            <v-list-item>
              <v-btn prepend-icon="mdi-tsunami" @click="setOceanDarkTheme"> Ocean Dark </v-btn>
            </v-list-item>
          </v-list>
        </v-card-text>

        <v-card-actions>
          <v-btn color="blue-darken-1" variant="text" @click="isActive.value = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'SettingsMenu'
})
</script>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'light'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setToxicLightTheme() {
  theme.global.name.value = 'toxicLight'
}

function setOceanLightTheme() {
  theme.global.name.value = 'oceanLight'
}

function setToxicDarkTheme() {
  theme.global.name.value = 'toxicDark'
}

function setOceanDarkTheme() {
  theme.global.name.value = 'oceanDark'
}
</script>
