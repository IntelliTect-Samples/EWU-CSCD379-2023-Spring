<template>
  <v-container class="signin-container" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="6" lg="4">
        <v-card class="signin-card">
          <v-card-title class="signin-card-title"> Sign In </v-card-title>
          <v-card-text>
            <v-form @submit.prevent="signIn()">
              <v-text-field v-model="username" label="Username" outlined required></v-text-field>
              <v-text-field
                v-model="password"
                label="Password"
                outlined
                type="password"
                required
              ></v-text-field>
              <v-btn type="submit" color="primary" block class="mt-4"> Sign In </v-btn>
            </v-form>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { defineComponent, inject, ref, toRef, watch } from 'vue'
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'

const username = ref('')
const password = ref('')

function signIn() {
  // Handle sign in logic here
  console.log('Signing in...')

  //-----sign in stuff
  const signInService = inject(Services.SignInService) as SignInService
  signInService.signIn(username.value, password.value)

  watch(
    () => signInService.token,
    (value) => {
      console.log(`Signed in user: ${value.userName}`)
    }
  )
  //-------------
}
</script>

<style scoped>
.signin-container {
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
}

.signin-card {
  max-width: 400px;
  margin: 0 auto;
}

.signin-card-title {
  text-align: center;
  font-size: 24px;
}
</style>
