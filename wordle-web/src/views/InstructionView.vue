<template>
  <v-container>
    <v-card color="yellow">
      <v-card-title class="primary">
        <h2 class="white--text">Instructions</h2>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Objective: </b></h3>
        <p>
          The goal of Wordle is to guess a five-letter target word within a limited number of
          attempts.
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Target Word: </b></h3>
        <p>
          The computer selects a random five-letter target word at the beginning of each game. The
          <br />target word is usually a common English word.<br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Guessing: </b></h3>
        <p>
          On each guess, you enter a five-letter word that you think might be the target word. You
          <br />can only guess valid English words with five letters.<br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Feedback: </b></h3>
        <p>
          After each guess, you will receive feedback in the form of colored squares:
          <br />
          <v-btn color="correct">"Correct"</v-btn> Green Square: A letter in your guess is in the
          correct position in the<br />
          target word.
          <br />
          <v-btn color="misplaced">"Misplaced"</v-btn> Yellow Square: A letter in your guess is in
          the target word, but in a different<br />
          position.
          <br />
          <v-btn color="wrong">"Wrong"</v-btn> Red Square: A letter in your guess is not in the
          target word.
          <br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Limited Attempts: </b></h3>
        <p>
          You have six attempts to guess the target word correctly. If you cannot guess the word
          <br />within six attempts, the game ends.<br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Strategy: </b></h3>
        <p>
          Use the feedback from each guess to narrow down the possibilities. Adjust your subsequent
          <br />guesses based on the information provided by the colored squares.<br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Winning: </b></h3>
        <p>
          If you correctly guess the target word within the allowed attempts (six guesses or
          fewer),<br />
          you win the game.<br />
        </p>
      </v-card-title>

      <v-card-title class="primary">
        <h3 class="white--text"><b>Difficulty: </b></h3>
        <p>
          The difficulty of Wordle comes from deducing the target word based on the limited<br />feedback.
          With each guess and feedback, you can eliminate possibilities and work towards<br />identifying
          the correct word.<br />
        </p>
      </v-card-title>
    </v-card>
  </v-container>
</template>
