<template>
  <v-app>
    <navbar :theme="theme" />
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
export default defineComponent({});
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900");
@import url("https://fonts.googleapis.com/css?family=Material+Icons");
body {
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}
</style>