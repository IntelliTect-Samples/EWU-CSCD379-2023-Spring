<template>
  <v-btn
    :color="props.color"
    :elevation="12"
    :flat="true"
    class = "my-button"
    >{{ props.char }}
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
.my-button {
  width: 50px;
  min-width: 50px;
  height: 50px;
  min-height: 50px;
  background-image: linear-gradient(to right, #00000040, #FFFFFF40) !important;
}

</style>


