<template>
  <v-btn class="elevation-20" :color="props.color" dense :style="{'background-image': 'linear-gradient(315deg, #00000040, #ffffff40) !important'}" >
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
