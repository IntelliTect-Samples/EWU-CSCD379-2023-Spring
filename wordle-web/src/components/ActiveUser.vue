<template>
  <v-btn @click="showDialog = true">
    {{ playerService.player.name }}
  </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close" persistent>
    <v-card>
      <v-card-text>
        Set or change your username:
        <v-text-field ref="$input" v-model="newName" @keyup.enter="confirm" />
      </v-card-text>
      <v-card-actions>
        <v-spacer> </v-spacer>
        <v-btn @click="confirm">OK</v-btn>
        <v-btn @click="close">Cancel</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import { nextTick } from 'vue'
import { watch } from 'vue'
import { inject } from 'vue'
import { ref } from 'vue'

const playerService = inject(Services.PlayerService) as PlayerService
let newName = playerService.player.name

const showDialog = ref(false)
const $input = ref<HTMLInputElement>()

watch(showDialog, (value) => {
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
  showDialog.value = false
}
</script>
