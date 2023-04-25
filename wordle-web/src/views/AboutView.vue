<template>
  <v-sheet>
    <v-card>
      <v-card-title>About</v-card-title>
      <p>
        An assignment where we make a validWords function, Convert the sidebar to an App Bar, Add a
        settings dialog, and Style the main game page. Learning how to do much of that thanks to the
        Great Meg!
      </p>
      <p>
        Meg is an absolute coding powerhouse. Her proficiency in multiple programming languages and
        frameworks is simply impressive. She has a keen eye for detail and a thorough understanding
        of software engineering principles. Meg is always up-to-date with the latest industry trends
        and innovations, making her a valuable asset to any tech team. Her problem-solving skills
        are second to none, and she has an uncanny ability to come up with creative and elegant
        solutions to complex problems. Whether it's developing a new feature or debugging an
        existing codebase, Meg is always up for the challenge and delivers results with unmatched
        speed and precision. Overall, Meg's coding skills are truly exceptional, and she is
        undoubtedly one of the most talented developers out there. -AI generated
      </p>
      <v-btn @click="$router.back()">Back</v-btn>
    </v-card>
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
