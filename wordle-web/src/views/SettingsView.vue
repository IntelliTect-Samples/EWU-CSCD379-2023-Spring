<template>
    <v-card
      class="mx-auto"
      max-width="500"
      variant="outlined"
    >
      <v-card-item>
        <div>
          <div class="text-overline mb-1">
            Settings
          </div>
          <div class="text-h6 mb-1">
            Change Background color?
          </div>
        </div>
      </v-card-item>
  
      <div class="wrapper mx-5">
      <v-btn @click="setInverseTheme"> Light Mode </v-btn>
      <v-btn @click="setDarkTheme"> Dark Mode </v-btn>
      <v-btn @click="setDarkDarkTheme"> Dark Dark Mode </v-btn>
      <v-btn @click="setNeonTheme"> Neon Mode </v-btn>
      <NavBar/>
    </div>

      <v-card-actions>
        <v-btn variant="outlined" to="/wordle">
          Back to Game
        </v-btn>
      </v-card-actions>
    </v-card>
  </template>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'
import { ref } from 'vue'
const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}
function setDarkDarkTheme(){
  theme.global.name.value = 'darkDark'
}
function setNeonTheme(){
  theme.global.name.value = 'neon'
}
let dialog = ref(false)



</script>