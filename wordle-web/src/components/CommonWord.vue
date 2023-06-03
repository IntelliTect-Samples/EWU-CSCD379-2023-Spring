<template>
  <v-card height="200px">
    <v-card-text>
      Change Common Word:
      <v-text-field
        @input="editText($event.target.value)"
        variant="outlined"
        style="display: flex; flex-direction: column; flex-grow: 1; max-width: 500px"
      />
    </v-card-text>
    <v-card-actions>
      <v-spacer />
      <v-btn @click="changeToCommon()">Change Common Word</v-btn>
    </v-card-actions>
  </v-card>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const input = ref<string>()

const editText = (text: string) => {
  input.value = text
}

const changeToCommon = () => {
  console.log(input.value)
}
</script>
