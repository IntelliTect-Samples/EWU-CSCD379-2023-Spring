<template>
  <v-dialog persistent :model-value="dialogOpen" @close-dialog="closeDialog" width="auto">
    <v-card>
      <v-card-title>Welcome to Wordle!</v-card-title>
      <v-text-field
        label="username"
        v-model="playerName"
        @keydown="onUsernameInput"
        @keyup.enter="submitName"
      ></v-text-field>
      <v-card-actions>
        <v-btn @click="submitName">Submit</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { ref, defineComponent, watchEffect } from 'vue'

export default defineComponent({
  props: {
    dialogOpen: {
      type: Boolean,
      required: true
    }
  },
  emits: ['update:dialogOpen', 'username-submitted', 'close-dialog', 'update-input'],
  setup(props, { emit }) {
    const playerName = ref('')

    watchEffect(() => {
      emit('update-input', playerName.value)
    })

    function submitName() {
      emit('username-submitted', playerName.value)
      emit('update:dialogOpen', false)
    }

    function onUsernameInput(event: KeyboardEvent) {
      event.stopPropagation()
    }

    function closeDialog() {
      emit('update:dialogOpen', false)
    }

    return { playerName, submitName, onUsernameInput, closeDialog }
  }
})
</script>
