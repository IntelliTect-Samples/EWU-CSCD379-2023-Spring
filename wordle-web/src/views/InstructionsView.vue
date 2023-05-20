<template>
    <v-responsive min-width="300px">
        <v-card>
            <v-card-item>
                <v-card-title>How To Play</v-card-title>
            </v-card-item>

            <v-card-item>
                <v-card-text>
                    The Good Word is a guessing game where the goal of the game is to guess
                    a randomly selected 5 letter word. You can use a keyboard to type, or you
                    can use the interactive keyboard on the screen to click buttons. You get a
                    total of 6 guesses in order to find the correct word. If a letter guessed
                    is correct then it will change colors to GREEN, if a letter guessed is 
                    correct but in the wrong location it will change colors to YELLOW, if a letter 
                    guessed is incorrect it will change colors to RED. After guessing the correct
                    word or after guessing incorrectly 6 times the game will end and your score will be
                    recorded and saved. Are you ready to start guessing?
                </v-card-text>
            </v-card-item>
        </v-card>
    </v-responsive>

    <br />

    <v-responsive min-width="300px">
        <v-card>
            <v-card-item>
                <v-card-title>Wildcards (?) And The Valid-Guesses Tool </v-card-title>
            </v-card-item>

            <v-card-item>
                <v-card-text>
                    Wildcards and the Valid-Guesses tool are designed to help you solve the correct word.
                </v-card-text>
            </v-card-item>

            <v-card-item>
                <v-card-text>
                    The Valid-Guesses tool is used to help you find valid words based on the letters
                    that are input. 
                </v-card-text>
            </v-card-item>

            <v-card-item>
                <v-card-text>
                    Wildcards, otherwise know as a question mark (?), are used to substitute for letters you
                    are uncertain about. For example,  
                </v-card-text>
            </v-card-item>
        </v-card>
    </v-responsive>
</template>

<script setup lang="ts">

</script>