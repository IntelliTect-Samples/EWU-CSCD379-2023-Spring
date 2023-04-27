<script lang="ts">
export default {
    data() {
        let guesses = reactive(["", "", ""]);
        for (let i = 3; i < this.guess; i++) {
            guesses.push("");
        }
        let wordList:string[] = []
        return {
            guesses,
            x: 0, y: 0,
            prim: useTheme().global.current.value.colors.primary,
            main: new game(),
            wordList,
        };
    },
    methods: {
        addLetter: function(c: string) {
            if(this.y < 5){
                this.guesses[this.x] += c
                this.y++
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
        },
        remove: function() {
            if(this.y > 0){
                this.guesses[this.x] = this.guesses[this.x].slice(0, this.y - 1)
                this.y--
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
            console.log(this.main.secret)
        },
        enter: function() {
            if(this.main.contains(this.guesses[this.x])){
                if (this.x < this.guesses.length) {
                    this.x++
                    this.y = 0
                }
            } else {
                //
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
        },
    },
    watch: {
        guess() {
            /* if (this.guess < this.guesses.length) {
                for (let i = this.guesses.length; i > this.guess; i--) {
                    this.guesses.pop;
                }
            }
            else {
                for (let i = this.guesses.length; i < this.guess; i++) {
                    this.guesses.push("");
                }
            } */
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
import { reactive } from 'vue';
import { game } from '../scripts/wordList';
</script>

<template>
    <div id="board">
        <v-row justify="center" v-for="g in guesses">
            <v-card variant="outlined" class="tile text-center">{{ g.split("")[0] }}</v-card>
            <v-card variant="outlined" class="tile text-center">{{ g.split("")[1] }}</v-card>
            <v-card variant="outlined" class="tile text-center">{{ g.split("")[2] }}</v-card>
            <v-card variant="outlined" class="tile text-center">{{ g.split("")[3] }}</v-card>
            <v-card variant="outlined" class="tile text-center">{{ g.split("")[4] }}</v-card>
        </v-row>
    </div>
    <v-container id="keys">
        <v-row justify="center">
            <v-btn elevation="14" variant="tonal" @click="addLetter('Q')" :color="$props.colors[0]" rounded="xl">Q</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('W')" :color="$props.colors[0]" rounded="xl">W</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('E')" :color="$props.colors[0]" rounded="xl">E</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('R')" :color="$props.colors[0]" rounded="xl">R</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('T')" :color="$props.colors[0]" rounded="xl">T</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('Y')" :color="$props.colors[0]" rounded="xl">Y</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('U')" :color="$props.colors[0]" rounded="xl">U</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('I')" :color="$props.colors[0]" rounded="xl">I</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('O')" :color="$props.colors[0]" rounded="xl">O</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('P')" :color="$props.colors[0]" rounded="xl">P</v-btn>
        </v-row>
        <v-row justify="center">
            <v-btn elevation="14" variant="tonal" @click="addLetter('A')" :color="$props.colors[0]" rounded="xl">A</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('S')" :color="$props.colors[0]" rounded="xl">S</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('D')" :color="$props.colors[0]" rounded="xl">D</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('F')" :color="$props.colors[0]" rounded="xl">F</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('G')" :color="$props.colors[0]" rounded="xl">G</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('H')" :color="$props.colors[0]" rounded="xl">H</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('J')" :color="$props.colors[0]" rounded="xl">J</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('K')" :color="$props.colors[0]" rounded="xl">K</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('L')" :color="$props.colors[0]" rounded="xl">L</v-btn>
            <v-btn elevation="14" variant="outlined" @click="remove()" color="prim" rounded="xl" class="exc"><v-icon>mdi-backspace-outline</v-icon></v-btn>
        </v-row>
        <v-row justify="center">
            <SuggestionMenu :guesses="guesses" :i="x" :list="wordList"></SuggestionMenu>
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
    </v-container>
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
        min-height: 60px;
        min-width: 60px;
        margin: 3px;
        background: radial-gradient(#00000088, #14141488, #ffffff22);
        font-size: 35px;
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