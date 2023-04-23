<template>
  <div class="WordSelect">
    <v-select :list="validWords"></v-select>
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
