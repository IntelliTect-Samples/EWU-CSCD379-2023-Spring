<template>
  <v-card class="text-center">
    <v-card-title class="display-1"> Personal Stats </v-card-title>
    <v-table>
      <thead>
        <tr>
          <th class="text-center">Games Played</th>
          <th class="text-center">Total Time Taken</th>
          <th class="text-center">Average Time Taken</th>
          <th class="text-center">Total Guess Attempts</th>
          <th class="text-center">Average Guess Attempts</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ players[0].gameCount }}</td>
          <td>{{ players[0].totalTimeInSeconds }}</td>
          <td>{{ players[0].averageTimeInSeconds }}</td>
          <td>{{ players[0].totalAttempts }}</td>
          <td>{{ players[0].averageAttempts }}</td>
        </tr>
      </tbody>
    </v-table>
    <v-card-item> Username: {{ username }} </v-card-item>
  </v-card>
</template>
