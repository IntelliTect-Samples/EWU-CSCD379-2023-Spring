<template>
  <v-dialog transition="dialog-bottom-transition" scrollable width="auto">
    <template v-slot:activator="{ props }">
      <v-btn v-bind="props" prepend-icon="mdi-chart-box-outline"> Leaderboard </v-btn>
    </template>
    <template v-slot:default="{ isActive }">
      <v-card>
        <v-card-title>LeaderBoard</v-card-title>
        <v-divider></v-divider>
        <v-card-text></v-card-text>
        <v-card-text>
          <v-table>
            <template v-slot:default>
              <thead>
                <tr>
                  <th class="text-left md">Name</th>
                  <v-divider vertical :thickness="12"></v-divider>
                  <th class="text-right">Score</th>
                </tr>
              </thead>
              <tbody>
                <!-- <tr v-for="item in items" :key="item.name"> -->
                <!-- <td>{{ item.name }}</td>
                  <td>{{ item.score }}</td> -->
                <!-- </tr> -->

                <td>Jake</td>
                <v-divider vertical :thickness="12"></v-divider>
                <td>1,000,000</td>
              </tbody>
            </template>
          </v-table>
        </v-card-text>
        <v-card-actions>
          <v-btn color="blue-darken-1" variant="text" @click="isActive.value = false">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </template>
  </v-dialog>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  name: 'LeaderBoard'
})
</script>
