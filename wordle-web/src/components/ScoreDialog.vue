<template>
  <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="300">
    <v-card>
      <div class="test-h2">
        You {{ gameResult?.success ? 'Win' : 'Loose' }}
      </div>
      <v-card-text class="flex-column align-center">
        <v-row dense>
          <v-col cols="5" class="">Score -</v-col>
          <v-col cols="5">{{ gameResult?.score }}</v-col>
          <v-col cols="5" class="">Attempts -</v-col>
          <v-col cols="5">{{ gameResult?.attempts }}</v-col>
          <v-col cols="5" class="">Duration -</v-col>
          <v-col cols="5">{{ duration }}</v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn @click="close" variant="elevated" color="primary"> Again </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { GameResult } from '@/scripts/wordleGame'
import { computed } from 'vue'
import { formatTime } from '@/scripts/time'

const props = defineProps<{
  modelValue: boolean
  gameResult?: GameResult
}>()

const duration = computed(() => {
  return props.gameResult ? formatTime(props.gameResult?.duration) : '???'
})

const emit = defineEmits<{
  (e: 'update:model-value', value: boolean): void
}>()

function close() {
  emit('update:model-value', false)
}
</script>
