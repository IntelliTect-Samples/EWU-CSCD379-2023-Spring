<template>
  <v-parallax height="650" src="https://source.unsplash.com/zeInZepl_Hw">
    <div class="d-flex flex-column fill-height justify-center align-center text-white">
      <v-card>
        <v-card-title> Word Editor </v-card-title>

        <div class="text-center">
          <v-pagination v-model="page" :length="15" :total-visible="6"></v-pagination>
        </div>
      </v-card>
    </div>
  </v-parallax>
</template>

<style></style>

<script>
const page = true
</script>
