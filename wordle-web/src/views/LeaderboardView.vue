<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
      <v-progress-linear 
        v-model="progress[0]"
        color="amber"
        height="25"
      ><strong>First place (Me)</strong> </v-progress-linear>
      <v-progress-linear 
        v-model="progress[1]"
        color="#AFAFAF"
        height="25"
      ><strong>Second place (Also Me)</strong> </v-progress-linear>
      <v-progress-linear 
        v-model="progress[2]"
        color="#CD7F32"
        height="25"
      ><strong>Third place (Still Me)</strong> </v-progress-linear>
      <template v-for="i in 17" :key="i.id">
        <v-progress-linear 
          v-model="progress[i+3]"
          color="#757575"
          height="25"
        ></v-progress-linear>
      </template>

      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref } from 'vue'
//import Axios from 'axios'

const progress = ref([100,80,60,40,20,18,16,14,18,10])

//const overlay = ref(true)
/*
var num1;
var num2;
var num3;
var num4;
var num5;
var num6;
var num7;
var num8;
var num9;
var num10;

Axios.get('topTen')
  .then((response) => {
    
    setTimeout(() => {
      overlay.value = false
    }, 502)
  })
  .catch((error) => {
    console.log(error)
  })
*/


</script>

<style scoped>
 .v-progress-linear {
  border-radius: 8px;
  width: 99%;
  margin-bottom: 10px;
}
</style>
```



