<template>
  <v-btn :color="c" v-bind:="$attrs">
    <span class="font-weight-bold">{{ props.char }}</span>
  </v-btn>
</template>

<script lang="ts">
export default {
  inheritAttrs:false
}
</script>

<script setup lang="ts">
import { computed } from 'vue'
import { useTheme } from 'vuetify/lib/framework.mjs'

export interface Props {
  char?: string
  color?: string
}

const theme = useTheme();

const c = computed(()=>{
  if (!props.color){
    console.log('no color');
    return theme.global.name.value.includes('light') ? "#000000" : '#FFFFFF';
  }else{
    return props.color;
  }
})

const props = withDefaults(defineProps<Props>(), {
  char: '?'
})
</script>
