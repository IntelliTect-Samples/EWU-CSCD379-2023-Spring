<template>
  <div class="WordSelect">
    <v-menu>
      <template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props"> {{ validWords.length }} potential words </v-btn>
      </template>
      <v-list>
        <v-list-item v-for="word in validWords" :key="word" @click="emitWord(word)">
          <v-list-item-title>{{ word }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
  </div>
</template>

<script lang="ts">
export default {
  props: ['value', 'validWords']
}
</script>

<script setup lang="ts">
const emits = defineEmits<{
  (event: 'selectWord', value: string): void
}>()

function emitWord(word: string) {
  emits('selectWord', word)
}
</script>

<style scoped>
.v-select {
  width: fit-content;
}
</style>
