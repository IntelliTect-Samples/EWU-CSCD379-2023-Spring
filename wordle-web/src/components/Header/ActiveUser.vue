<!--
---- Component to 'HeaderAppBar.vue', responsible displaying username along with keeping it up to date...
--->

<template>
  <v-btn @click="toggleDialog = true">
    {{ playerService.player.playerName }}
  </v-btn>

  <!-- TODO: Figure out why why do ':model-value="toggleDialog" @update:model-value="close"' over 'v-model="toggleDialog"' -->
  <v-dialog
    :model-value="toggleDialog"
    @update:model-value="close"
    max-width="600px"
    title="Name dialog"
    persistent
  >
    <v-card>
      <v-card-text>
        Set or change your username:
        <v-text-field ref="$input" v-model="newName" @keyup.enter="confirm" />
      </v-card-text>
      <v-card-actions class="justify-center">
        <v-btn elevation="6" @click="confirm">OK</v-btn>
        <v-btn elevation="6" @click="close">Cancel</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { PlayerService } from '@/scripts/services/playerService'
import { Services } from '@/scripts/services/services'
import { nextTick } from 'vue'
import { watch } from 'vue'
import { inject } from 'vue'
import { ref } from 'vue'

const playerService = inject(Services.PlayerService) as PlayerService
let newName = playerService.player.playerName

const toggleDialog = ref(false)
const $input = ref<HTMLInputElement>()

// TODO: Understand what nextTick does and the $input values.
watch(toggleDialog, (value) => {
  if (value) {
    nextTick(() => {
      $input.value!.focus()
      $input.value!.select()
    })
  }
})

const confirm = async () => {
  await playerService.ChangeNameAsync(newName)
  close()
}
const close = () => {
  toggleDialog.value = false
}
</script>
