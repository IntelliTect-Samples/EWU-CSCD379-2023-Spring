<template>
  <v-btn elevation="8" :color="props.color" height="50px">
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})
</script>

<style scoped>
.v-btn:hover{  
  background-position: right center;
  text-decoration: none;
}
.v-btn {
  background-image: linear-gradient(to right, #232526 0%, #414345  51%, #232526  100%);
  transition: 0.5s;
  background-size: 200% auto;
  display: block;
}
</style>

