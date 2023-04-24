<template>
  <div id="gradient">
    <v-btn class="shadow-5 elevation-10" :color="props.color">
      {{ props.char }}
    </v-btn>
  </div>
</template>
<style scoped>
#gradient {
  background: linear-gradient(to right, #e1e1e1, #747474);
}
</style>

<script setup lang="ts">
// Working on implementing the gradient background for the letter buttons
// import { computed } from 'vue'
export interface Props {
  char?: string
  color?: string
}

// const myGradient = computed(() => {
//   if (props.color == "misplaced") {
//     return 'linear-gradient(to right, #ff44AC, #ff5e62)'
//   }
//   if (props.color == "correct") {
//     return 'linear-gradient(to right, #00f2fe, #4facfe)'
//   }
//   if (props.color == "wrong") {
//     return 'linear-gradient(to right, #ff9966, #ff5e62)'
//   }
// })

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>
