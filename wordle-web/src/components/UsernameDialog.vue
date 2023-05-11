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
            <v-btn @click="continueAsGuest"> Continue as Guest </v-btn>
          </v-col>
        </v-row>
      </v-card-text>
    </v-card>
  </v-dialog>

  <v-dialog v-model="submitted">
    <v-card max-width="200px">
      <v-card-title class="headline">Username saved</v-card-title>
    </v-card>
  </v-dialog>
</template>

<script setup lang="ts">
import { onMounted, onUnmounted, ref, watch } from 'vue'
import { eventBus } from '@/scripts/eventBus'

let dialog = ref()
let username = ref('')
let submitted = ref(false)

const emits = defineEmits<{
  // Emits new name value to parent component.
  (event: 'updateNameValue', value: string): void
}>()
// Use the value emitted from 'WordleView.vue' close or open the dialog.
const updateDialogValue = (newValue: unknown) => {
  dialog.value = newValue
}

onMounted(() => {
  // Listen for 'updateDialogValue' event from 'WordleView.vue'.
  eventBus.on('updateDialogValue', updateDialogValue)
})
onUnmounted(() => {
  // Stop listening for 'updateDialogValue' event from 'WordleView.vue'.
  eventBus.off('updateDialogValue', updateDialogValue)
})

// Watch for changes to the username value and emit the new value to 'WordleView.vue'.
watch(
  () => username.value,
  (newValue) => {
    emits('updateNameValue', newValue)
  }
)

if (!localStorage.getItem('username')) {
  updateDialogValue(true)
}

function continueAsGuest() {
  username.value = 'Guest'
  submitName()
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
