<template>
    <h3>Available Words</h3>
    <v-list>
        <v-list-item v-for="word in validWords" :key="word">
            <v-list-item-content>
                <v-list-item-title>{{ word }}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>
    </v-list>
</template>

<script lang="ts">

// import { Word } from '@/scripts/word';
import { defineComponent } from 'vue';

export default defineComponent({
    props: {
        validWords: Array<string>
    }
})
</script>