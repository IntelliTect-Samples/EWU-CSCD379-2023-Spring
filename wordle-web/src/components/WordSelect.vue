<template>
  <div class="WordSelect">
    <v-select :value="value" :items="validWords" @input="$emit('input', $event)"></v-select>
    {{ validWords.length }} potential words
  </div>
</template>

<script lang="ts">
export default {
  props: ['value', 'validWords']
}
</script>

<style scoped>
.v-select {
  width: fit-content;
}
</style>
