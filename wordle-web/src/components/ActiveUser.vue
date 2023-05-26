<template>
  <v-btn @click="showDialog = true">
    {{ playerService.player.name }}
  </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close" persistent>
    <v-card
      :class="display.xs ? 'w-100' : display.sm ? 'w-75' : display.md ? 'w-50' : 'w-25'"
      class="justify-center mx-auto"
    >
      <v-card-title>
        Set or change your username:
        <v-text-field class="mt-4" ref="$input" v-model="newName" @keyup.enter="confirm" />
      </v-card-title>
      <v-card-actions>
        <v-btn @click="confirm">OK</v-btn>
        <v-btn @click="close">Cancel</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import type { PlayerService } from '@/scripts/playerService'
import { Services } from '@/scripts/services'
import { nextTick, reactive } from 'vue'
import { watch } from 'vue'
import { inject } from 'vue'
import { ref } from 'vue'
import { useDisplay } from 'vuetify'

const display = inject(Services.Display, () => reactive(useDisplay())) as unknown as ReturnType<
  typeof useDisplay
>

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
