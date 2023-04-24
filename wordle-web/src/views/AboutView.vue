<template>
  <v-sheet color="blue" class="pt-10 my-5">
    <v-card color="indigo-darken-3" max-height="275" class="ma-5 pa-5" elevation="5" rounded="xl">
      <v-card-title>About</v-card-title>
      <body>
        This has been an interesting class so far, but I am not looking forward to the c# section as
        I have yet to use the language and this class is already taking up a decent amount of time.
        In terms of the current project, I'm struggling a lot with basic formatting with my current
        headache being my columns on the keyboard not having any spacing between them on a small
        screen and too much spacing on a large one. I'm hoping I can find a way to fix the distance
        between them. Also, Meg is great as a teacher, and I'm glad that the code is uploaded during
        class and available in lecture videos otherwise I would be left completely in the dust.
        Grant is pretty cool, but the assignment doesn't specify writing about him.
      </body>
    </v-card>
    <RouterLink to="/"><v-btn>Home</v-btn></RouterLink>
  </v-sheet>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
