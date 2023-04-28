<template>
  <v-btn 
    class="justify-center key-gradient key" 
    size="small" 
    :color="props.color " 
    elevation="6"
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
.key {
  width: 1rem;
  height: 3rem;
  font-size: 1rem;
  font-weight: bolder;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  border-radius: 5px;
  
 

}
  .key-gradient {
  background-image: linear-gradient(to top, #6F6F6F31, #B5B5B5C9);
}

</style>
