<script lang="ts">
export default {
  props: ['title', 'body']
}
</script>

<template>
  <h1>{{ title }}</h1>
  <p>{{ body }}</p>
</template>