<script lang="ts">
export default {
    data() {
        let guesses = ["", "", ""];
        for (let i = 3; i < this.guess; i++) {
            guesses.push("");
        }
        return {
            guesses,
            cur: 0,
            prim: useTheme().global.current.value.colors.primary,
            row1: ['Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'],
            row2: ['A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L']
        };
    },
    methods: {
        addLetter: function(c: string) {
                if(this.guesses[this.cur].length < 5){
                    this.guesses[this.cur] += c;
                }
                console.log(this.guesses)
            },
            remove: function() {
                if(this.guesses[this.cur].length > 0){
                    this.guesses[this.cur] = this.guesses[this.cur].slice(0, 4);
                }
                console.log(this.guesses)
            },
            enter: function() {
                //
                if (this.cur < this.guesses.length) {
                    //
                    console.log(this.cur);
                    this.cur += 1;
                    console.log(this.cur);
                }
            },
    },
    watch: {
        guess() {
            if (this.guess < this.guesses.length) {
                for (let i = this.guesses.length; i > this.guess; i--) {
                    this.guesses.pop;
                }
            }
            else {
                for (let i = this.guesses.length; i < this.guess; i++) {
                    this.guesses.push("");
                }
            }
        },
        colors() {
            //Refresh button colors on theme change somehow
        }
    },
    props: ["guess", "colors"],
    components: { SuggestionMenu }
}
import { useTheme } from 'vuetify/lib/framework.mjs';
import SuggestionMenu from './SuggestionMenu.vue'
</script>

<template>
    <div id="board">
        <v-row justify="center" v-for="g in guesses">
            <v-card variant="outlined" class="tile">{{ g.split("")[0] }}</v-card>
            <v-card variant="outlined" class="tile">{{ g.split("")[1] }}</v-card>
            <v-card variant="outlined" class="tile">{{ g.split("")[2] }}</v-card>
            <v-card variant="outlined" class="tile">{{ g.split("")[3] }}</v-card>
            <v-card variant="outlined" class="tile">{{ g.split("")[4] }}</v-card>
        </v-row>
    </div>
    <div id="keys">
        <v-row justify="center">
            <v-btn v-for="lett in row1" elevation="14" variant="tonal" @click="addLetter(lett)" :color="$props.colors[0]" rounded="xl">{{ lett }}</v-btn>
        </v-row>
        <v-row justify="center">
            <v-btn v-for="lett in row2" elevation="14" variant="tonal" @click="addLetter(lett)" :color="$props.colors[0]" rounded="xl">{{ lett }}</v-btn>
            <v-btn elevation="14" variant="outlined" @click="remove()" color="prim" rounded="xl" class="exc"><v-icon>mdi-backspace-outline</v-icon></v-btn>
        </v-row>
        <v-row justify="center">
            <SuggestionMenu :guesses="guesses"></SuggestionMenu>
            <v-btn elevation="14" variant="outlined" @click="addLetter('?')" color="prim" rounded="xl" class="exc">?</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('Z')" :color="$props.colors[0]" rounded="xl">Z</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('X')" :color="$props.colors[0]" rounded="xl">X</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('C')" :color="$props.colors[0]" rounded="xl">C</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('V')" :color="$props.colors[0]" rounded="xl">V</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('B')" :color="$props.colors[0]" rounded="xl">B</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('N')" :color="$props.colors[0]" rounded="xl">N</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('M')" :color="$props.colors[0]" rounded="xl">M</v-btn>
            <v-btn elevation="14" variant="outlined" @click="enter()" color="prim" rounded="xl" class="exc">Enter</v-btn>
        </v-row>
    </div>
</template>

<style scoped>
    button {
        margin: 5px;
        background-image: linear-gradient(#d9d9d900, #bfbebe29, #8b8b8b92);
    }
    .exc {
        background-image: none;
    }
    .tile {
        min-height: 70px;
        min-width: 70px;
        margin: 3px;
        background: radial-gradient(#00000088, #14141488, #ffffff22);
    }
    #board {
        margin-top: 25px;
        margin-bottom: 25px;
    }
    #keys {
        margin-top: 25px;
        margin-bottom: 25px;
    }
    #suggest {
        max-height: 300px;
        overflow-y: scroll;
        margin-bottom: 25px;
    }
</style>