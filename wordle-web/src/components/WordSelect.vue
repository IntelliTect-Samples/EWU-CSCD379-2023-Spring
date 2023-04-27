<template>
  <div class="WordSelect">
    <v-select :items="validWords"></v-select>
    {{ validWords.length }} potential words
  </div>
</template>

<script lang="ts">
export default {
  props: ['validWords']
}
</script>

<style scoped>
.v-select {
  width: fit-content;
}
</style>
