<template>
  <v-card
    class="align-center text-center mx-auto"
    max-height="100%"
    max-width="90%"
    min-height="90%"
    min-width="25%"
    rounded
    title="How to Play Wordle"
  >
    <v-card-text class="bodyText">
      The rules of Wordle are elegantly simple. Your objective is to guess a secret five-letter word
      in as few guesses as possible. To submit a guess, type any five-letter word and press enter.
    </v-card-text>
    <v-card-text class="bodyText">
      All of your guesses must be real words, according to a dictionary of five-letter words that
      Wordle allows as guesses. You can’t make up a non-existent word, like AEIOU, just to guess
      those letters.
    </v-card-text>
    <v-card-text class="bodyText">
      As soon as you’ve submitted your guess, the game will color-code each letter in your guess to
      tell you how close it was to the letters in the hidden word.
    </v-card-text>
    <v-card-text class="subText">
      <li>A red square means that this letter does not appear in the secret word at all</li>
      <li>
        A yellow square means that this letter appears in the secret word, but it’s in the wrong
        spot within the word
      </li>
      <li>
        A green square means that this letter appears in the secret word, and it’s in exactly the
        right place
      </li>
      <li>
        Getting a green square or yellow square will get you closer to guessing the real secret
        word, since it means you’ve guessed a correct letter.
      </li>
    </v-card-text>
    <v-card-text class="bodyText">
      For example, let’s say you guess “WRITE” and get two green squares on the W and the R, and
      gray squares for the I, T, and E. Your next guess might be WRONG, WRACK, or WRUNG, since these
      words start with WR and don’t contain the letters I, T, or E.
    </v-card-text>
    <v-card-text class="bodyText">
      Alternatively, let’s say you guess “WRITE” and get two green squares on the T and the E, and
      gray squares for the W, R, and I. In that case, your next guess might be BASTE, ELATE, or
      LATTE, since these words end with TE and don’t contain the letters W, R, or I.
    </v-card-text>
    <v-card-text class="bodyText">
      Remember that the same letter can appear multiple times in the secret word, and there’s no
      special color coding for letters that appear repeatedly. For example, if the secret word is
      BELLE and you guess a word with one L and one E, Wordle won’t tell you that both those letters
      actually appear twice.
    </v-card-text>
    <v-card-actions>
      <a href="/wordle">
        <v-btn class="bodyText">Play Wordle</v-btn>
      </a>
    </v-card-actions>
  </v-card>
</template>

<style scoped>
@media (max-width: 600px) {
  .bodyText {
    font-size: 12px;
  }
  .subText {
    font-size: 10px;
  }
}

@media (min-width: 601px) {
  .bodyText {
    font-size: 16px;
  }
  .subText {
    font-size: 14px;
  }
}

@media (min-width: 1200px) {
  .bodyText {
    font-size: 20px;
  }
  .subText {
    font-size: 18px;
  }
}
</style>
