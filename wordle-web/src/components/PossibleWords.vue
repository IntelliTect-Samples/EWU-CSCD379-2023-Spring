<template>
  <v-card class="mx-auto" max-width="250">
    <v-card-item class="justify-center">
      <v-card-title>Possible Words: {{ WordsService.validWords(props.guess).length }}</v-card-title>
    </v-card-item>

    <v-card-actions class="justify-center">
      <v-btn @click="dialog = !dialog">Select</v-btn>
    </v-card-actions>
    <v-dialog
      v-model="dialog"
      activator="#select"
      transition="dialog-bottom-transition"
      width="auto"
    >
      <v-card width="270px">
        <v-select
          no-data-text="Please enter at least one letter"
          label="Available Words"
          :items="WordsService.validWords(props.guess)"
          v-model="selected"
          @update:model-value="wordSelection(selected)"
          onchange="wordSelection(this.value)"
        >
        </v-select>
      </v-card>
    </v-dialog>
  </v-card>
</template>

<script setup lang="ts">
import { WordsService } from '@/scripts/wordsService'
import type { WordleGame } from '@/scripts/wordleGame'
import { ref } from 'vue'

const props = defineProps<{
  game: WordleGame
  guess: string
}>()

const emits = defineEmits<{
  (event: 'wordSelection', value: string): void
}>()

function wordSelection(selection: string) {
  emits('wordSelection', selection)
  dialog.value = false
}

const dialog = ref(false)
const selected = ref('')
</script>
