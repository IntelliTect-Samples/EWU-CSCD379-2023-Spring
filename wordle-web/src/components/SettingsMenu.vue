<script setup lang="ts">
import { useTheme } from 'vuetify'
import { ref } from 'vue'
import { watch } from 'vue'

const theme = useTheme()
const isDark = ref(true)

function setDefaultTheme() {
  if (isDark.value) {
    theme.global.name.value = 'dark'
  } else {
    theme.global.name.value = 'light'
  }
}

function setDesertTheme() {
  if (isDark.value) {
    theme.global.name.value = 'desertDark'
  } else {
    theme.global.name.value = 'desertLight'
  }
}

function setOceanTheme() {
  if (isDark.value) {
    theme.global.name.value = 'oceanDark'
  } else {
    theme.global.name.value = 'oceanLight'
  }
}

watch(isDark, () => {
  if (theme.global.name.value.includes('ocean')) {
    setOceanTheme()
  } else if (theme.global.name.value.includes('desert')) {
    setDesertTheme()
  } else {
    setDefaultTheme()
  }
})
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
        <v-toolbar color="primary">
          <v-toolbar-title class="flex text-center">
            <span class="text-h4"> Settings </span>
          </v-toolbar-title>
        </v-toolbar>
        <v-card-text>
          <v-card-title class="text-h5 pb-8"> Theme: </v-card-title>

          <v-switch inset v-model="isDark" :label="'Light/Dark'"></v-switch>

          <v-btn variant="tonal" color="#9575CD" @click="setDefaultTheme">Default</v-btn> &nbsp;
          <v-btn variant="tonal" color="#FF781E" @click="setDesertTheme">Desert</v-btn>&nbsp;
          <v-btn variant="tonal" color="#3079CC" @click="setOceanTheme">Ocean</v-btn>
        </v-card-text>
        <v-card-actions>
          <v-btn
            variant="text"
            density="compact"
            elevation="4"
            text
            size="x-large"
            @click="isActive.value = false"
            >Close</v-btn
          >
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>
