<template>
  <v-card title="Available Words">
    <v-card-text>
      <v-list>
        <v-list-item v-for="word in words" :key="word">
          <v-list-item-title>{{ word }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
const props = defineProps<{
  words: string[];
}>();
</script>
