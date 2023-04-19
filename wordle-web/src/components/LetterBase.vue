<template>
    
    <v-btn color="props.color">
        {{ props.char }}
    </v-btn>
</template>

<script setup lang="ts">
import { defineProps } from 'vue';

export interface Props {
    char?: string
    color?: string
}

const props= withDefaults( defineProps<Props>(),
    {
        char: '?',
        color: 'primary'
    }
)
</script>