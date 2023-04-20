<template>
    <v-row dense v-for="(key, i) in keyboardLetters" :key="i">
        <v-col cols="auto" v-for="letter in key" :key="letter">
            <LetterButton :letter="letter"></LetterButton>
        </v-col>
    </v-row>
</template>

<script setup lang="ts">

const keyboardLetters = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm', '?']
]
</script>