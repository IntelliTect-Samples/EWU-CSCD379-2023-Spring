<template>
  <v-card>
    <main>-- L Page --</main>
  </v-card>

  <v-card>
    <v-table>
      <thead>
        <tr>
          <th class="text-left">player Name</th>
          <th class="text-left">Score</th>
          <th class="text-left">Agv Attempts</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in data().desserts" :key="item.name">
          <td>{{ item.name }}</td>
          <td>{{ item.calories }}</td>
          <td>{{ item.avgAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
  </v-card>
  <v-btn density="compact" @click="goBack"> Back </v-btn>
</template>

<script setup lang="ts">
import $router from '../router/index'

function goBack() {
  $router.go(-1)
}

function data() {
  return {
    desserts: [
      {
        name: 'Frozen Yogurt',
        calories: 159,
        avgAttempts: 12
      },
      {
        name: 'Ice cream sandwich',
        calories: 237,
        avgAttempts: 12
      },
      {
        name: 'Eclair',
        calories: 262,
        avgAttempts: 12
      },
      {
        name: 'Cupcake',
        calories: 305,
        avgAttempts: 12
      },
      {
        name: 'Gingerbread',
        calories: 356,
        avgAttempts: 12
      },
      {
        name: 'Jelly bean',
        calories: 375,
        avgAttempts: 12
      },
      {
        name: 'Lollipop',
        calories: 392,
        avgAttempts: 12
      },
      {
        name: 'Honeycomb',
        calories: 408,
        avgAttempts: 12
      },
      {
        name: 'Donut',
        calories: 452,
        avgAttempts: 12
      },
      {
        name: 'KitKat',
        calories: 518,
        avgAttempts: 12
      }
    ]
  }
}
</script>
