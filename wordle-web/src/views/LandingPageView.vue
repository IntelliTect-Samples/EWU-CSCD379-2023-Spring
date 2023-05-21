<template>
  <v-container fluid class="fill-height">
    <v-layout align-center justify-center>
      <v-flex text-center>
        <h1>Welcome to My Website</h1>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
export default {
  mounted() {
    setTimeout(() => {
      this.$router.push('/wordle')
    }, 5000)
  }
}
</script>
