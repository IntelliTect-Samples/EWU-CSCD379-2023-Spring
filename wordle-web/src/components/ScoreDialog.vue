<template>
  <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="300">
    <v-card>
      <div class="d-flex justify-center pa-2 bg-primary text-h6">
        You {{ gameResult?.wasGameWon ? 'Win' : 'Lose' }}
      </div>
      <v-card-text class="d-flex flex-column align-center">
        <v-row dense>
          <v-col cols="6" class="text-end">Attempts -</v-col>
          <v-col cols="6">{{ gameResult?.attempts }}</v-col>
          <v-col cols="6" class="text-end">Duration -</v-col>
          <v-col cols="6">{{ duration }}</v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn @click="close" variant="elevated" color="primary"> Play Again </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { GameResult } from '@/scripts/gameResult'
import { computed } from 'vue'
import { formatTime } from '@/scripts/helpers'

const props = defineProps<{
  modelValue: boolean
  gameResult: GameResult
}>()

const duration = computed(() => {
  return props.gameResult ? formatTime(props.gameResult.durationInSeconds) : '???'
})

const emit = defineEmits<{
  (e: 'update:model-value', value: boolean): void
}>()

function close() {
  emit('update:model-value', false)
}
</script>
