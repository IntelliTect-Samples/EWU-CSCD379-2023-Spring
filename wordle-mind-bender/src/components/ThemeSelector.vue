<template>
  <v-dialog transition="dialog-bottom-transition" width="30rem">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" class="ml-1"><v-icon icon="mdi-cog" size="x-large"></v-icon></v-btn>
    </template>
    <template v-slot:default="{ isActive }">
      <v-card>
        <v-toolbar title="Settings"></v-toolbar>
        <v-card-text>
          <v-select
            label="Select Theme"
            v-model="selectedTheme"
            :items="themeList"
            item-title="name"
            item-value="value"
            @update:modelValue="setTheme()"
          ></v-select>
        </v-card-text>
        <v-card-actions class="justify-end">
          <v-btn variant="text" @click="isActive.value = false">Close</v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script setup lang="ts">
import { useTheme } from 'vuetify'
import { ref } from 'vue'
const theme = useTheme()
const themeList = [
  {
    name: 'Dark',
    value: 'dark'
  },
  {
    name: 'Light',
    value: 'light'
  },
  {
    name: 'Mossy Woodland',
    value: 'MossyWoodland'
  },
  {
    name: 'Mossy Woodland Daylight',
    value: 'MossyWoodlandLight'
  },
  {
    name: 'Ocean Mist',
    value: 'OceanMist'
  },
  {
    name: 'Dark Ocean Mist',
    value: 'OceanMistDark'
  }
]
const selectedTheme = ref(themeList[0].name)
const setTheme = () => {
  theme.global.name.value = selectedTheme.value
  console.log(selectedTheme.value)
}
</script>
