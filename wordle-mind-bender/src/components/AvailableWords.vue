<template>
  <v-dialog transition="dialog-bottom-transition">
    <template v-slot:activator="{ props }">
      <v-btn
        color="teal"
        v-bind="props"
        style="background-image: var(--btn-gradient)"
        class="elevation-7"
        >Available Words</v-btn
      >
    </template>
    <template v-slot:default="{ isActive }">
      <v-card class="mx-auto">
        <v-card-title color="correct" title="Available Words"></v-card-title>
        <v-card-text>
          <v-list v-for="(item, idx) in items" :key="idx">
            <v-list-item item-value="item.value">{{ item.title }}</v-list-item>
          </v-list>
        </v-card-text>
        <v-card-actions class="justify-end">
          <v-btn variant="text" @click=";(isActive.value = false), sayWord()">Close</v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue'
const items = [
  {
    title: 'Item #1',
    value: 1
  },
  {
    title: 'Item #2',
    value: 2
  },
  {
    title: 'Item #3',
    value: 3
  },
  {
    title: 'Item #4',
    value: 4
  }
]

const selectWord = ref(items[0])
const sayWord = () => {
  console.log(selectWord.value)
}
</script>
