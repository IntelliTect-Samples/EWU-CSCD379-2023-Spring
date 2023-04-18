<template>
    <LetterBase :text="props.letter.letter" :color="props.letter.color"></LetterBase>
</template>

<script setup lang="ts">
import type {Letter} from "@/scripts/letter";
//import LetterBase from "@/components/LetterBase.vue";

export interface props {
    letter: Letter;
}

const props = defineProps<props>();
</script>