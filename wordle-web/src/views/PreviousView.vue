<template>
  <v-card>
    <v-card-title>Daily Words</v-card-title>
    <v-row dense v-for="day, i in previous" :key="i">
        <v-col>
            <v-btn>{{ day.toLocaleDateString() }}</v-btn>
        </v-col>
    </v-row>
  </v-card>
</template>

<script setup lang="ts">
const today = Date.now()
const previous = Array<Date>(10)

for (let i = 0; i < 10; i++) {
  previous[i] = new Date(today - 86400000 * i)
}
</script>
