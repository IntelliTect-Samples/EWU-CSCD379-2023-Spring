<template>
  <v-btn @click="showDialog = true">
    <span v-if="!signInService.isSignedIn">Not signed in</span>
    <span v-else>{{ signInService.token.userName }}</span>
  </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close">
    <v-card
      :class="display.xs ? 'w-100' : display.sm ? 'w-75' : display.md ? 'w-50' : 'w-25'"
      class="justify-center mx-auto"
    >
      <v-card-text v-if="!signInService.isSignedIn">
        <v-text-field
          ref="$input"
          v-model="username"
          label="User Name"
          outlined
          dense
          hide-details
          class="mt-3"
        ></v-text-field>
        <v-text-field
          v-model="password"
          label="Password"
          type="password"
          outlined
          dense
          hide-details
          class="mt-3 mb-0"
        ></v-text-field>
      </v-card-text>
      <v-card-actions class="ml-3 mb-3">
        <v-btn @click="signOut" v-if="signInService.isSignedIn" class="mt-3">Sign Out</v-btn>
        <v-btn @click="signIn" v-else @keyup.enter="signIn">Sign In</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
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
