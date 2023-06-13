<template>
  <v-btn icon>
    <v-icon>mdi-login</v-icon>
    <v-dialog
      width="75%"
      height="75%"
      v-model="dialog"
      activator="parent"
      transition="dialog-top-transition"
    >
      <v-card width="100%" height="75%">
        <v-card-item class="justify-end">
          <v-btn icon dark @click="dialog = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-item>
        <v-card-title class="text-center">Login</v-card-title>

        <v-chip-group outlined class="justify-center ma-10 pa-10">
          <v-card-title class="text-center">Please enter your information:</v-card-title>
          <v-text-field label="User" v-model="username" variant="outlined"></v-text-field>
          <v-text-field label="Password" v-model="password" variant="outlined"></v-text-field>
        </v-chip-group>
        <v-chip-group class="justify-center ma-10 pa-10">
          <v-chip size="small" @click="wordleLogin">Login</v-chip>
          <v-card-title class="text-center">{{ result }}</v-card-title>
        </v-chip-group>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const username = ref('')
const password = ref('')
const result = ref('')

function wordleLogin() {
  if (username.value == 'Realuser') {
    result.value = 'Wrong password. Try "im20dude".'
    if (password.value == 'im20dude') {
      localStorage.setItem('user', username.value)
      localStorage.setItem('age', 'under')
      result.value = 'Success. use "im21dude" if you are normal and can be trusted.'
    } else if (password.value == 'im21dude') {
      localStorage.setItem('user', username.value)
      localStorage.setItem('age', 'above')
      result.value = 'Success. You can update common words.'
    }
  } else {
    result.value = 'Wrong user. Try "Realuser".'
  }

  console.log(localStorage.getItem('user'))
  console.log(localStorage.getItem('age'))
}

let dialog = ref(false)
</script>
