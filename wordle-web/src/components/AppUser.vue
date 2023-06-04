<template>
  <v-btn @click="showDialog = true">
    <span v-if="signInService.isSignedIn">
      {{ signInService.token.userName }}
    </span>
    <span v-else> Sign In </span>
  </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close" persistent>
    <v-card>
      <v-card-text>
        <v-text-field label="Username" v-model="username" type="email"></v-text-field>
        <v-text-field label="Password" v-model="password" type="password"></v-text-field>
      </v-card-text>
      <v-card-actions>
        <v-spacer> </v-spacer>
        <v-btn @click="confirm">Sign In</v-btn>
        <v-btn @click="close">Cancel</v-btn>
        <v-btn v-if="signInService.isSignedIn" @click="signOut">Sign Out</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import { Services } from '@/scripts/services'
import { inject } from 'vue'
import { ref } from 'vue'
import type { SignInService } from '@/scripts/signInService'

const signInService = inject(Services.SignInService) as SignInService

const showDialog = ref(false)
const username = ref('')
const password = ref('')

const confirm = async () => {
  signInService.signIn(username.value, password.value)
  username.value = ''
  password.value = ''
  close()
}
const close = () => {
  username.value = ''
  password.value = ''
  showDialog.value = false
}

const signOut = () => {
  username.value = ''
  password.value = ''
  signInService.signOut()
  close()
}
</script>
