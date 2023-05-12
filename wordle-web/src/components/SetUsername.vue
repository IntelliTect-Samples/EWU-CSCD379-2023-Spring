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
    <v-btn @click="user = false">Close</v-btn>
    <v-btn @click="setUsername">Confirm</v-btn>
  </v-card-actions>
</v-card>
</v-dialog>

</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';



const user = ref(true)
const username = ref("Guest")

if (localStorage.getItem('username') === 'Guest') {
  user.value = true
} else if (localStorage.getItem('username') === null){
  localStorage.setItem('username', username.value)
} else {
  user.value = false
}


onMounted(() => {
  if (localStorage.getItem('username') != null) {
    username.value = localStorage.getItem('username')!
  }
})
function setUsername() {
  user.value = false
  localStorage.setItem('username', username.value)
}




</script>