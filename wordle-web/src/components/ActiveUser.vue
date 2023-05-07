<template>
  <v-btn @click="showDialog = true">
    {{ Player.Name.value }}
  </v-btn>
  <v-dialog :model-value="showDialog" @update:model-value="close" persistent>
    <v-card>
      <v-card-text>
        Set or change your username:
        <v-text-field v-model="newName" :placeholder="Player.Name.value" />
      </v-card-text>
      <v-card-actions>
        <v-btn @click="close">Cancel</v-btn>
        <v-btn @click="confirm">Confirm</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import { Player } from '@/scripts/playerService'
import { onMounted } from 'vue'
import { watch } from 'vue'
import { ref } from 'vue'

const showDialog = ref(false)
const newName = ref('')

const emit = defineEmits<{
  (e: 'typing', value: boolean): void
}>()

onMounted(() => {
  showDialog.value = Player.Name.value == 'Guest'
})

watch(showDialog, (value) => {
  Player.TypingName.value = value
  emit('typing', value)
})

const confirm = async () => {
  await Player.ChangeNameAsync(newName.value)
  close()
}

const close = () => {
  showDialog.value = false
}
</script>
