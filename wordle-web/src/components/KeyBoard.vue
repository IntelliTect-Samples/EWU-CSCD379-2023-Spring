<template>
    <v-row dense v-for="(key, i) in keyboardLetters" :key="i">
        <v-col cols="auto" v-for="(char, j) in key" :key="j">
            <LetterButton :letter="new Letter(char)" @click="letterClick(new Letter(char))" />
        </v-col>
    </v-row>
</template>

<script setup lang="ts">
import { Letter } from '@/scripts/letter';
import { computed } from 'vue';

const props = defineProps<{
    guessedLetters: Letter[]
}>()

const keyboardLetters = computed(() => {
    const keyboardLetters: Letter[][] = [];

    const keyboardChars = [
        ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
        ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
        ['z', 'x', 'c', 'v', 'b', 'n', 'm'],
    ];
    
    for (const row of keyboardChars) {
        const letters: Letter[] = [];
        for (const key of row) {
            letters.push(new Letter(key));
            row.push(props.guessedLetters.find(l) => l.char === key ?? new Letter(key))
        }
        keyboardLetters.push(letters);
    }
    return keyboardLetters;
})

const emits = defineEmits<{
    (event: 'letterClick', value: Letter): void
}>()

function letterClick(letter: Letter) {
    emits('letterClick', letter)
}

</script>
