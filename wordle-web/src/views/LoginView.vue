<template>
  <v-container class="d-flex justify-center align-center">
    <v-card style="width: 500px">
      <v-card-title>Login</v-card-title>
      <v-card-item>
        <v-text-field label="Email:" @input="updateEmail($event.target.value)"></v-text-field>
        <v-text-field
          type="password"
          label="Password:"
          @input="updatePassword($event.target.value)"
        ></v-text-field>
      </v-card-item>
      <v-card-actions style="display: flex; justify-content: right">
        <v-btn @click="signInService.signIn(email, password)" to="/">Login</v-btn>
      </v-card-actions>
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
