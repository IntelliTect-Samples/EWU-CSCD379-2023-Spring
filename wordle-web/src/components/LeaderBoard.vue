<template>
  <v-card width="400" title="Top players:" subtitle="Top 10 players will be shown below">
    <v-list-item active-color="primary" display="flex">
      <template v-slot:prepend>
        <v-list-item-title class="pe-5"> # </v-list-item-title>
        <v-icon icon="mdi-account"></v-icon>
      </template>

      <v-list-item-title>Player Name: Average Score: </v-list-item-title>
    </v-list-item>

    <v-list-item
      v-for="(item, i) in props.playerName"
      :key="i"
      :value="item"
      active-color="primary"
      display="flex"
    >
      <template v-slot:prepend>
        <v-list-item-title class="pe-5">{{ i }}</v-list-item-title>
        <v-icon icon="mdi-account"></v-icon>
      </template>

      <v-list-item-title>{{ item.name }} {{ item.average }}</v-list-item-title>
    </v-list-item>
  </v-card>
</template>

<script setup lang="ts">
import type { Player } from '@/scripts/Player'

const props = defineProps<{
  playerName: Array<Player>
}>()
</script>
