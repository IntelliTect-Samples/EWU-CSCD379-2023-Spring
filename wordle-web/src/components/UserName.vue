<template>
  <v-btn @click.stop="dialog = !dialog">
    <v-icon>mdi-login</v-icon>
    {{ usersName }}
  </v-btn>

  <v-dialog v-model="dialog" transition="dialog-bottom-transition" width="auto" persistent>
    <v-card class="justify-center text-center" width="500px" height="150px">
      You are currently logged in as: {{ usersName }}
      <v-text-field
        label="Enter a User Name"
        variant="outlined"
        v-model="inputUserName"
        @input="updateUserName"
      ></v-text-field>
      <v-btn variant="outlined" @click="saveUserName" :disabled="!inputUserName">Enter</v-btn>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { watch } from 'vue'
import { ref } from 'vue'

const dialog = ref(false)
const usersName = ref('guest')
const inputUserName = ref('')

function updateUserName() {
  usersName.value = inputUserName.value
}

function saveUserName() {
  usersName.value = inputUserName.value
  dialog.value = false
}

const emits = defineEmits<{
  (event: 'disableKeyboard'): void
  (event: 'enableKeyboard'): void
}>()

function disableKeyboard() {
  emits('disableKeyboard')
}

function enableKeyboard() {
  emits('enableKeyboard')
}

watch(
  () => dialog.value,
  (newStatus) => {
    if (newStatus) {
      disableKeyboard()
    } else {
      enableKeyboard()
    }
  }
)
</script>
