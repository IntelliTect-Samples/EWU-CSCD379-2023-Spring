<script setup lang="ts">
</script>

<template>
  <main>
    <v-card class="mx-auto">
      <v-card-item>
        <v-card-title>This is a title</v-card-title>
      </v-card-item>

      <v-card-text>
        Lorem Ipsum is simply dummy text of the printing and typesetting industry. 
        Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
        when an unknown printer took a galley of type and scrambled it to make a type 
        specimen book. It has survived not only five centuries, but also the leap into 
        electronic typesetting, remaining essentially unchanged. It was popularised in
         the 1960s with the release of Letraset sheets containing Lorem Ipsum passages,
          and more recently with desktop publishing software like Aldus PageMaker including
           versions of Lorem Ipsum.
      </v-card-text>


      <v-card-actions>
        <RouterLink to="/">
          <v-btn variant="outlined" to="/">
            Back to Home!
          </v-btn>
        </RouterLink>
      </v-card-actions>
    </v-card>
  </main>
</template>
