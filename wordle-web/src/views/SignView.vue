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
            <v-card>
              <v-card-title>Default Accounts</v-card-title>
              <p>UserName: AdminIntellitect.com</p>
              <p>PassWord: P@ssw0rd123</p>
              <p>--Has admin and special roles.</p>
              <p>----</p>
              <p>UserName: matt.com</p>
              <p>PassWord: P@ssw0rd123</p>
              <p>--Has admin and special roles.</p>
              <p>----</p>
              <p>UserName: meg.com</p>
              <p>PassWord: P@ssw0rd1234</p>
              <p>--Has admin and special roles, and a claim of MasterOfTheUniverse.</p>
              <p>----</p>
              <p>UserName: FrostyTheSnowman.com</p>
              <p>PassWord: P@ssw0rd12345</p>
              <p>--Has admin and special roles, and a claim of MasterOfTheUniverse, also is the only one old enough to add or remove words.</p>
            </v-card>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
    
  </v-container>
 
</template>

<script setup lang="ts">
import { inject, ref, watch } from 'vue'
import { Services } from '../scripts/services'
import type { SignInService } from '../scripts/signInService'

const username = ref('')
const password = ref('')
const signInService = inject(Services.SignInService) as SignInService

function signIn() {
  // Handle sign in logic here
  console.log('Signing in...')

  //-----sign in stuff
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
