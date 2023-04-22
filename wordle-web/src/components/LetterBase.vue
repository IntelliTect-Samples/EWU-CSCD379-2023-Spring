<template>
  <v-btn :color="color" v-bind:="$attrs">
    <span class="font-weight-bold ">{{ props.char.toUpperCase() }}</span>
  </v-btn>
</template>

<script lang="ts">
export default {
  inheritAttrs:false
}
</script>

<script setup lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs'

export interface Props {
  char?: string
  color?: string
}
const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'default'
})
</script>
