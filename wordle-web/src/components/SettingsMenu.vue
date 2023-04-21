<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

const theme = useTheme()

function setInverseTheme() {
  theme.global.name.value = 'inverse'
}

function setDarkTheme() {
  theme.global.name.value = 'dark'
}

function setLightTheme() {
  theme.global.name.value = 'light'
}

function setPastelTheme() {
  theme.global.name.value = 'pastel'
}
</script>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({})
</script>

<template>
  <v-dialog transition="dialog-bottom-transition" width="auto">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" icon>
        <v-icon size="25px" icon="mdi:mdi-cog" />
      </v-btn>
    </template>
    <template v-slot:default="{ isActive }">
      <v-card width="500px" height="350px">
        <v-toolbar color="#5439AA">
          <v-toolbar-title class="flex text-center">
            <span class="text-h4 bold">Settings</span>
          </v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <V-text class="text-h5 bold"> Theme: </V-text> <br /><br />
          <v-btn variant="tonal" color="#27AE6A" @click="setInverseTheme">Inverse</v-btn> &nbsp;
          <v-btn variant="tonal" color="#9575CD" @click="setDarkTheme">Dark</v-btn> &nbsp;
          <v-btn variant="tonal" color="#FFEE58" @click="setLightTheme">Light</v-btn> &nbsp;
          <v-btn variant="tonal" color="#BA68C8" @click="setPastelTheme">Pastel</v-btn>
        </v-card-text>
        <v-card-actions>
          <v-btn color="#B0BEC5" text size="x-large" @click="isActive.value = false">Close</v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>
