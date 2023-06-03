<template>
  <v-container class="d-flex justify-center align-center">
    <v-card style="width: 500px">
      <div>Login</div>

      <v-text-field label="Email:" @input="updateEmail($event.target.value)"></v-text-field>
      <v-text-field label="Password:" @input="updatePassword($event.target.value)"></v-text-field>
      <div style="display: flex; justify-content: right; margin: 0.6em">
        <v-btn @click="signInService.signIn(email, password)">Login</v-btn>
      </div>
    </v-card>
  </v-container>
</template>
<script setup lang="ts">
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'
import { inject, ref } from 'vue'
const signInService = inject(Services.SignInService) as SignInService

const email = ref<string>('')

const password = ref<string>('')

const updateEmail = (text: string) => {
  email.value = text
}

const updatePassword = (text: string) => {
  password.value = text
}
</script>
