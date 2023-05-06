<template>
  <v-dialog v-model="dialog" max-width="600px" title="Name dialog" persistent>
    <v-card height="auto">
      <v-card-title class="headline">Enter your username</v-card-title>
      <v-card-text>
        <v-text-field v-model="username" label="Username"></v-text-field>
        <v-row cols="auto" class="justify-center">
          <v-col cols="auto">
            <v-btn @click="submitName"> Submit </v-btn>
          </v-col>
          <v-col cols="auto">
            <v-btn @click="closeDialog"> Cancel </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-dialog>

  <v-dialog v-model="submitted" align="center" justify="center" class="fill-height">
    <v-card max-width="200px">
      <v-card-title class="headline">Username saved</v-card-title>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { onMounted, onUnmounted, ref } from 'vue'
import { eventBus } from '@/scripts/eventBus'

let dialog = ref()
let username = ref('')
let submitted = ref(false)
const updateModelValue = (newValue: unknown) => {
  dialog.value = newValue
}

// Mount event listener on component creation
onMounted(() => {
  eventBus.on('updateDialogValue', updateModelValue)
})
// Remove event listener on component destruction
onUnmounted(() => {
  eventBus.off('updateDialogValue', updateModelValue)
})

if (!localStorage.getItem('username')) {
  updateModelValue(true)
}

function closeDialog() {
  dialog.value = false
}

function submitName() {
  if (username.value.length > 0) {
    localStorage.setItem('username', username.value)
    submitted.value = true
    setTimeout(() => {
      submitted.value = false
    }, 1500)
    closeDialog()
  }
}
</script>
