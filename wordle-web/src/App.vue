<template>
  <v-app>
    <v-main>
      <router-view to="/home"></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import router from "./router";

export default defineComponent({});
</script>



