<template>
    <v-dialog
      v-model="user"
      width="500"
      persistent
    > <template v-slot:activator="{ props }">
        <v-btn
          v-bind="props"
        >
          {{ username }}
        </v-btn>
    </template>

<v-card>
  <v-card-text>
    <v-text-field 
        v-model="username"
        label="Username"
        
    ></v-text-field>
  </v-card-text>
  <v-card-actions>
    <v-btn color="primary" block @click="user = false">Close</v-btn>
  </v-card-actions>
</v-card>
</v-dialog>

</template>

<script setup lang="ts">
import { ref } from 'vue'

const user = ref(false)
const username = ref("Guest")






</script>