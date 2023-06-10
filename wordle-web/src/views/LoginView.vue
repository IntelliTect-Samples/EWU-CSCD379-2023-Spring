<template>
  <v-container class="d-flex justify-center align-center">
    <v-card style="width: 500px">
      <v-card-title>Login</v-card-title>
      <v-card-item>
        <v-text-field ref="$input" label="User Name" v-model="username" ></v-text-field>
        <v-text-field
          v-model="password"
          type="password"
          label="Password:"
        ></v-text-field>
      </v-card-item>
      <v-card-actions style="display: flex; justify-content: right">
        <v-btn @click="signOut" v-if="signInService.isSignedIn" class="mt-3">Sign Out</v-btn>
        <v-btn @click="signIn" v-else @keyup.enter="signIn">Sign In</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script setup lang="ts">
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'
import { reactive } from 'vue'
import { inject } from 'vue'
import { ref } from 'vue'
import { useDisplay } from 'vuetify/lib/framework.mjs'
const signInService = inject(Services.SignInService) as SignInService
const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>
// refs for storing the username and password
const username = ref('')
const password = ref('')
const showDialog = ref(false)
const $input = ref<HTMLInputElement>()
const signIn = async () => {
  await signInService.signInAsync(username.value, password.value)
  if (signInService.isSignedIn) {
    close()
  } else {
    $input.value?.focus()
  }
}
const signOut = () => {
  signInService.signOut()
  close()
}
const close = () => {
  showDialog.value = false
}
</script>
