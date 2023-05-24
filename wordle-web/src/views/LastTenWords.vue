<template>
<v-card>
    <v-card-title>Last 10 Wordle of the day</v-card-title>
    <v-table density="compact" >
        <thead>
      <tr>
        <th class="text-left">
        Date
        </th>
        <th class="text-left">
        Statistics
        </th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="item in dummy"
        :key="item"
      >
        <td>{{ item }}</td>
      </tr>
    </tbody>
    </v-table>
</v-card>

</template>

<script setup lang="ts">
import { ref } from 'vue';


const dummy = ref(["dummy", "dummy", "dummy", "dummy", "dummy", "dummy", "dummy", "dummy", "dummy", "dummy"])


</script>