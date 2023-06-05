<template>
  <v-btn @click="toggleDialog = true">
    <span v-if="!signInService.isSignedIn">Not signed in</span>
    <span v-else>{{ signInService.token.userName }}</span>
  </v-btn>

  <v-dialog
    :model-value="toggleDialog"
    @update:model-value="close"
    max-width="600px"
    title="Sign In"
    persistent
  >
    <v-card>
      <div class="d-flex justify-center pa-2 text-h6">Sign In</div>
      <v-card-text>
        <v-row>
          <v-col cols="12">
            <v-text-field v-model="username" label="User Name"> </v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field v-model="password" label="Password" type="password"> </v-text-field>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions class="justify-center">
        <v-btn @click="signInAsync" variant="elevated" color="success"> Sign In </v-btn>
        <v-btn @click="close" variant="elevated" color="error"> Cancel </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { inject, ref } from 'vue'
import { Services } from '@/scripts/services/services'
import type { SignInService } from '@/scripts/signInService'

const signInService = inject(Services.SignInService) as SignInService
const toggleDialog = ref(false)
const username = ref('')
const password = ref('')

async function signInAsync() {
  if (await signInService.signInAsync(username.value, password.value)) {
    close()
  } else {
    alert('Invalid user name or password')
  }
}

function close() {
  toggleDialog.value = false
}
</script>
