<template>
    <v-btn :color="props.color">
        {{ props.text }}
    </v-btn>
</template>

<script setup lang="ts">
export interface props {
    text?: string;
    color?: string;
    }

    const props = withDefaults(defineProps<props>(), {
        text: "?",
        color: "grey",
    });
</script>