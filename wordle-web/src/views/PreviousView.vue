<template>
  <v-card>
    <v-card-title>Daily Words</v-card-title>
    <v-row dense v-for="(day, i) in previous" :key="i">
      <v-col>
        <v-btn>{{ day }}</v-btn>
      </v-col>
    </v-row>
  </v-card>
</template>

<script setup lang="ts">
import { previousWords } from '@/scripts/previousWords'

const previous = previousWords
</script>
