<template>
  <v-btn v-bind:="$attrs" @click="show = !show">Hints: {{ words.length }}</v-btn>
  <v-dialog
    :model-value="show"
    @update:model-value="show = false"
    scrollable
    width="400"
    height="50%"
  >
    <v-card>
      <v-card-title class="d-flex align-center bg-primary">
        Hints
        <v-spacer />
        <v-btn icon variant="tonal" @click="show = !show" size="small"
          ><v-icon icon="mdi-window-close"
        /></v-btn>
      </v-card-title>
      <v-card-text>
        <v-row>
          <v-col v-for="word in partial" :key="word" cols="4">
            <v-btn color="default" variant="elevated" width="100">{{ word }}</v-btn>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-btn v-if="index" variant="elevated" color="primary" @click="index--">Previous</v-btn>
        <v-spacer />
        <v-btn v-if="canGoNext" variant="elevated" color="primary" @click="index++">Next</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { WordleGame } from '@/scripts/wordleGame'
import { computed, ref, watch } from 'vue'

const props = defineProps<{
  game: WordleGame
}>()

const show = ref(false)
const index = ref(0)

watch(show, (value) => {
  if (value) {
    index.value = 0
  }
})

const maxQty = 48
const words = computed(() => props.game.validWords)
const partial = computed(() => {
  const start = index.value * maxQty
  return words.value.slice(start, start + maxQty)
})

const canGoNext = computed(() => words.value.length - (index.value * maxQty + maxQty) > 0)
</script>
