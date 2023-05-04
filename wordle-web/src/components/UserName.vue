<template>
  <v-btn @click.stop="dialog = !dialog">
    <v-icon>mdi-login</v-icon>
    {{ UserName }}
  </v-btn>

  <v-dialog v-model="dialog" transition="dialog-bottom-transition" width="auto" persistent>
    <v-card class="justify-center text-center" width="400px" height="320px">
      Enter a user name:
      <v-text-field
        label="Label"
        variant="outlined"
        v-model="inputUserName"
        @input="updateUserName"
      ></v-text-field>
      <v-btn variant="outlined" @click="saveUserName">Enter</v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const dialog = ref(false)
const UserName = ref('guest')
const inputUserName = ref('')

function updateUserName() {
  UserName.value = inputUserName.value
}

function saveUserName() {
  UserName.value = inputUserName.value
  dialog.value = false
}

function clearInput() {
  inputUserName.value = ''
}
</script>
