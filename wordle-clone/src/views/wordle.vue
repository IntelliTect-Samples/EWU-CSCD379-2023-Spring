

<template>
  <div>{{ count }}</div>
</template>
<script setup lang="ts">
    import { ref } from 'vue'
    const count = ref(1)
    setInterval(() => {
        count.value++
    }, 1000)
</script>