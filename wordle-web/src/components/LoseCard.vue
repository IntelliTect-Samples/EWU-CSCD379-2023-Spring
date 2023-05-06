<template>
  <v-dialog width="auto" v-bind:model-value="props.ifLoss">
    <v-card>
      <v-card-item>
        <v-card-subtitle> oh no! </v-card-subtitle>
        <v-card-title> You lost! </v-card-title>
      </v-card-item>

      <v-card-actions>
        <v-btn variant="outlined" @click="restartGame"> Click to Restart Game </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
const props = defineProps<{
  ifLoss: boolean
}>()

const emits = defineEmits<{
  (event: 'restartGame'): void
}>()

function restartGame() {
  emits('restartGame')
}
</script>
