<template>
  <v-card
    class="mx-auto"
    max-width="300"
    max-height="auto"
  >
    <v-list>
      <v-list-item
        v-for="(item, i) in props.items"
        :key="i"
        :value="item"
        active-color="primary"
        variant="plain"
        :title="item"
        @click="fillGuess(item)"
      />
    </v-list>
  </v-card>
</template>

<script setup lang="ts">
  const props = defineProps<{
    items: string[]
  }
  >()

const emits = defineEmits<{
  (event: 'fillGuess', value: string): void
}>()

function fillGuess(guess: string) {
  emits('fillGuess', guess)
}
</script>