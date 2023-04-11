<template>
  <div >
      {{ count }}
      <h1>Worlde Game</h1>
      <v-text-field label="Label"></v-text-field>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
const count = ref(1)
setInterval(() => { count.value++}, 1000 )
</script>