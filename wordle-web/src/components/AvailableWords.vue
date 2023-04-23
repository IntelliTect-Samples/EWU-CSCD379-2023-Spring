<template>
    <v-btn>Hints: {{ words.length }}</v-btn>
</template>

<script lang="ts" setup>
import type { WordleGame } from '@/scripts/wordleGame';
import { computed } from 'vue';

const props = defineProps<{
    game: WordleGame
}>();

const words = computed(()=> props.game.validWords)

</script>