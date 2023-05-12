<template>
  <v-btn @click.stop="dialog = !dialog">
    <v-icon>mdi-login</v-icon>
    {{ usersName }}
  </v-btn>

  <v-dialog v-model="dialog" transition="dialog-bottom-transition" width="auto" persistent>
    <v-card class="justify-center text-center" width="520px" height="280px">
      <v-card class="mt-2 mb-3">Please enter a user name</v-card>
      You are currently logged in as: {{ usersName }}
      <v-text-field
        label="Enter a User Name"
        variant="outlined"
        v-model="inputUserName"
        @input="updateUserName"
        class="mt-4 ml-4 mr-4"
      ></v-text-field>
      <div class="button-container">
        <v-btn variant="outlined" @click="saveUserName" :disabled="!inputUserName">Enter</v-btn>
        <v-btn variant="outlined" @click="cancelUserName">Cancel</v-btn>
      </div>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { watch, ref } from 'vue'

const dialog = ref(true)
const localName = localStorage.getItem('usersName')
const usersName = ref('guest')
const inputUserName = ref('')

if (localName !== null) {
  usersName.value = localStorage.getItem('usersName')!
}

function updateUserName() {
  usersName.value = inputUserName.value
}

function saveUserName() {
  usersName.value = inputUserName.value
  dialog.value = false
  localStorage.setItem('usersName', usersName.value)
  sendUsername()
}

function cancelUserName() {
  dialog.value = false
}

const emits = defineEmits<{
  (event: 'setKeyboard', toggle: boolean): void
  (event: 'sendUsername', value: string): void
}>()

function setKeyboard(toggle: boolean) {
  emits('setKeyboard', toggle)
}

function sendUsername() {
  emits('sendUsername', usersName.value)
}

watch(dialog, async (newStatus) => {
  if (newStatus) {
    setKeyboard(false)
  } else {
    setKeyboard(true)
  }
})
</script>

<style scoped>
.button-container {
  display: flex;
  justify-content: center;
  margin-bottom: 20px;
}
.button-container > * {
  margin: 0 20px;
}
</style>
