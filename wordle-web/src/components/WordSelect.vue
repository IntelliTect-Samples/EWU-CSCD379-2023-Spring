<template>
  <div class="WordSelect">
    <v-select :items="validWords"></v-select>
  </div>
</template>

<script setup lang="ts">
export interface WordSelectProps {
  validWords: Array<string>
}

const props = defineProps<WordSelectProps>()
</script>

<style scoped>
.v-select {
  width: fit-content;
}
</style>
