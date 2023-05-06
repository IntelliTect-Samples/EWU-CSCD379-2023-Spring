<template>
  <v-sheet>
    <v-card>
      <v-card-title>Leader Board</v-card-title>
      <div> 
        <p>First</p>
        <v-progress-linear 
        v-model="progress"
        color="amber"
        height="25"
        striped
      ><strong>First place</strong> </v-progress-linear>
      </div>


      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
  </v-sheet>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const progress = ref(80)

</script>

<style scoped>
 .v-progress-linear {
  border-radius: 8px;
  width: 99%;
}

</style>
```



