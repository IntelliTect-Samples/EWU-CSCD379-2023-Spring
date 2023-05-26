<template>
  <v-parallax height="650" src="https://source.unsplash.com/7CME6Wlgrdk">
    <div class="d-flex flex-column fill-height justify-center align-center text-black">
      <h2
        class="text-h2 font-weight-bold mb-4"
        style="
          font-family: 'Macondo', cursive !important;
          text-shadow: -1px -1px 0 #c12a007c, 1px -1px 0 #c12a007c, -1px 1px 0 #c12a007c,
            1px 1px 0 #c12a007c;
        "
      >
        How to Play
      </h2>
      <div
        style="
          background-color: #1d1d1d55;
          padding: 25px 25px;
          border-radius: 15px;
          font-family: 'Alegreya', serif !important;
          box-shadow: -1px -1px 5 #c12a007c, 1px -1px 5 #c12a007c, -1px 1px 5 #c12a007c,
            1px 1px 5 #c12a007c;
          max-width: 650px;
        "
      >
        <v-row
          ><p class="font-weight-bold">
            Never played Wordle before? No worries! Here's a few quick and easy steps on how the
            game works.
          </p></v-row
        >
        <v-row
          ><p class="font-weight-bold">
            First you'll enter a word, then the letters will change to one of the corresponding
            colors seen below. This will be based upon whether the letters are: Correct, Misplaced
            or Wrong.
          </p></v-row
        >
        <v-row
          ><v-btn color="correct" size="x-small" class="mr-2" style="font-size: 0.9em">A</v-btn>
          <p>
            <strong>Correct</strong> means that the letter exists within the word and in that exact
            place.
          </p></v-row
        >
        <v-row
          ><v-btn color="misplaced" size="x-small" class="mr-2" style="font-size: 0.9em">A</v-btn>
          <p>
            <strong>Misplaced</strong> means that the letter exists within the word but not in that
            exact place.
          </p></v-row
        >
        <v-row
          ><v-btn color="wrong" size="x-small" class="mr-2" style="font-size: 0.9em">A</v-btn>
          <p>
            <strong>Wrong</strong> means that the letter does not exist within the word at all.
          </p></v-row
        >
        <v-row
          ><p class="font-weight-bold">
            Then you will guess another word based upon this information until you have either run
            out of guesses or successfully guessed the correct word.
          </p></v-row
        >
        <v-row
          ><p class="font-weight-bold">
            If you so choose, you may also utilize the Wordle Helper. This will suggest the most
            probable and second most probable word - as well as a few other potential words - based
            upon the letter information you have gotten thus far and potentially increase your
            chance of success.
          </p></v-row
        >
      </div>
    </div>
  </v-parallax>
</template>
<style>
@import url('https://fonts.googleapis.com/css2?family=Macondo&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Alegreya&display=swap');
</style>
