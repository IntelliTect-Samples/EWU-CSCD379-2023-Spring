<template>
    <v-row dense v-for="(key, i) in keyboardLetters" :key="i">
        <v-col cols="auto" v-for="char in key" :key="char">
            <LetterButton :letter="new Letter(char)" @click="letterClick(new Letter(char))" />
        </v-col>
    </v-row>
</template>

<script setup lang="ts">
import type { Letter } from '@/scripts/letter';


const keyboardLetters = [
    ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
    ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
    ['z', 'x', 'c', 'v', 'b', 'n', 'm', '?']
]

const emits = defineEmits<{
    (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
    emits('letterClick', letter)
}
</script>
