<template>
  <v-btn 
  style="
       width: 75px;
       min-width: 50px;
       height: 60px;
       min-height: 50px;
     "
     :color = "props.color"
     :elevation="12"
     :flat="true"
     :style="{ 'background-image': 'linear-gradient(to right, #00000040, #FFFFFF40) !important'}"
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
  color: 'primary'
})

</script>
