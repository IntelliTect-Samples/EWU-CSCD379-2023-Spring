<template>
  <v-btn :size="size" elevation="8" :color="props.color">
    {{ props.char }}
  </v-btn>
</template>

<script setup lang="ts">
import {computed} from "vue";
import { useDisplay } from "vuetify/lib/framework.mjs";

export interface Props {
  char?: string
  color?: string
}

const props = withDefaults(defineProps<Props>(), {
  char: '?',
  color: 'grey'
})

const { mobile, xs } = useDisplay();

const size = computed(() => {
  if (mobile.value && (xs.value)) {
    console.log(mobile.value)
    return 'x-small';
  }
  return 'default';
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

