<script lang="ts">
export default {
  props: ['title', 'body']
}
</script>

<template>
  <h2>{{ title }}</h2>
  <p>{{ body }}</p>
</template>