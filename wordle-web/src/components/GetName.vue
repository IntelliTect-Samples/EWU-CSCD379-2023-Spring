<template>
  <v-btn flat @click="setOverlay">{{ thisName }}</v-btn>
  <v-dialog v-model="overlay" persistent class="w-25">
    <v-card>
      <v-text-field v-model="thisName" label="Name" />
      <v-btn @click="setOverlay">close</v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const props = withDefaults(
  defineProps<{
    name: string
  }>(),
  {
    name: 'guest'
  }
)

const overlay = ref(false)
const thisName = ref('guest')

const emits = defineEmits<{
  (event: 'overlay', value: string): void
}>()

function setOverlay() {
  overlay.value = !overlay.value
  emits('overlay', thisName.value)
}
</script>
