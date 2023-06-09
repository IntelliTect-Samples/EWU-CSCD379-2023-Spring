<template>
  <v-btn @click="showDialog = true"> Login </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close">
    <v-card class="mx-auto" width="600px">
      <v-card-text>
        Username:
        <v-text-field v-model="newName" />
      </v-card-text>
      <v-card-text>
        Password:
        <v-text-field v-model="password" />
      </v-card-text>
      <v-card-actions>
        <v-spacer> </v-spacer>
        <v-btn @click="confirm">OK</v-btn>
        <v-btn @click="close">Cancel</v-btn>
      </v-card-actions>
      Here you go Meg<br />
      MotU: He-Man Password: an0thErP@s$word123<br />
      Regular user: Joe123 Password: s3curEp@ssw0rd123
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'
import { inject } from 'vue'
import { ref } from 'vue'

const signInService = inject(Services.SignInService) as SignInService
const newName = ref('')
const password = ref('')

const showDialog = ref(false)

const confirm = async () => {
  if (await signInService.signInAsync(newName.value, password.value)) close()
  else alert('Invalid username or password')
  showDialog.value = false
  location.reload()
}
const close = () => {
  showDialog.value = false
}
</script>
