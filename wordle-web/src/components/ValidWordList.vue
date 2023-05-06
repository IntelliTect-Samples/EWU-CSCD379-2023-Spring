<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" scrollable width="auto"
      ><template v-slot:activator="{ props }">
        <v-btn color="primary" v-bind="props" @click="props">{{
          `(${items.length}) Possible Words`
        }}</v-btn>
      </template>
      <v-card>
        <v-card-title>Select Words</v-card-title>
        <v-divider></v-divider>
        <v-card-text style="height: 300px; max-width: 150px">
          <v-hover> 
            <v-btn
              v-for="(item, index) in items"
              :key="index"
              :text="wordGuess === item"
              @click="typeof item === 'string' && (wordGuess = item)"
            >
              {{ item }}
            </v-btn>
            </v-hover> 
        </v-card-text>
        <v-divider></v-divider>

        <v-card-actions>
          <v-btn color="blue-darken-1" variant="text" @click="dialog = false"> Close </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script setup lang="ts">
//v-select is like 3 line of code including the template
import { ref, watchEffect } from 'vue'

const dialog = ref(false)
const wordGuess = ref<string>('')
defineProps({
  items: {
    type: Array,
    default: () => []
  }
})

const emit = defineEmits<{
  (validguess: 'change', value: string): void
}>()

function save() {
  emit('change', wordGuess.value)
  dialog.value = false
}

watchEffect(() => save())
</script>
