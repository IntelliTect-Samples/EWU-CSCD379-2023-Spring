<template>
  <v-btn @click="showDialog = true"> Sign In! </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="showDialog = !showDialog">
    <v-card>
      <v-card-title> Sign In </v-card-title>
      <v-text-field
        class="pa-5"
        v-model="username"
        label="Username"
        variant="outlined"
      ></v-text-field>
      <v-text-field
        class="pa-5"
        v-model="password"
        label="Password"
        variant="outlined"
      ></v-text-field>
      <v-btn class="pb-5" @click="signIn(username, password)"> Sign In </v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref, inject } from 'vue'
import type { SignInService } from '../scripts/signInService'
import { Services } from '../scripts/services'

const signInService = inject(Services.SignInService) as SignInService

const showDialog = ref(false)
const username = ref('')
const password = ref('')

function signIn(user: string, pass: string) {
  signInService.signInAsync(user, pass)
  console.log(signInService.isSignedIn)
  console.log(signInService.token)
}
</script>
