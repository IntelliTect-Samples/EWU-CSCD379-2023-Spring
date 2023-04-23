<template>
  <v-card :color="props.color">
    <v-btn id=gradient :elevation="0">
        {{ props.char }}
    </v-btn>
  </v-card>
</template>

<style scoped>
  #gradient {
    background-image: linear-gradient(
      to bottom right,
      rgba(0, 0, 0, 0.5),
      rgba(255, 255, 255, 0.5)
    );
    background-color: transparent;
  }
</style>

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

<script lang="ts">
  export default {
    data: () => ({
      overlay: true,
    }),
  }
</script>
