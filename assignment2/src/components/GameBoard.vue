<script lang="ts">
export default {
    data() {
        let guesses = reactive(["", "", ""]);
        for (let i = 3; i < this.guess; i++) {
            guesses.push("");
        }
        let wordList:string[] = []
        let board = [[new letter('Q', 0), new letter('W', 0), new letter('E', 0), new letter('R', 0), new letter('T', 0), new letter('Y', 0), new letter('U', 0), new letter('I', 0), new letter('O', 0), new letter('P', 0)], [new letter('A', 0), new letter('S', 0), new letter('D', 0), new letter('F', 0), new letter('G', 0), new letter('H', 0), new letter('J', 0), new letter('K', 0), new letter('L', 0)], [new letter('Z', 0), new letter('X', 0), new letter('C', 0), new letter('V', 0), new letter('B', 0), new letter('N', 0), new letter('M', 0)]]
        let sound = new Audio(s.default)
        sound.volume = 1
        //Credit to classmates whose implementation I imitated to complete the sound effect EC
        //Fair warning though it kinda sucks because I didn't know where to find just... A free generic clicky sound mp3?
        //So I recorded a click of my wireless mouse. And there's a just noticeable delay between the start of the sound and the actual click.
        //It's obnoxious.
        return {
            guesses,
            x: 0, y: 0,
            prim: useTheme().global.current.value.colors.primary,
            main: new game(),
            wordList, snack: false,
            board, sound
        };
    },
    methods: {
        addLetter: function(c: string) {
            if(this.y < 5){
                this.guesses[this.x] += c
                this.y++
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
            this.sound.play()
        },
        remove: function() {
            if(this.y > 0){
                this.guesses[this.x] = this.guesses[this.x].slice(0, this.y - 1)
                this.y--
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
            this.sound.play()
            console.log(this.main.secret)
        },
        enter: function() {
            if(this.main.contains(this.guesses[this.x])){
                if (this.x < this.guesses.length) {
                    this.x++
                    this.y = 0
                    //Yes I am aware the color doesn't change and that is a fundamental necessity for the game to function...
                    //Though to be fair it wasn't explicitly required in this assignments instructions.
                    //(Unless we're counting that under "make it look like Wordle"...)
                    //I wasted too much time trying to figure out how to move data between the components to get
                    //the themes/settings to work fully as I wanted them to and it just came around and bit me.
                    //Also doesn't help I kinda made my own way of things because some of the in-class implementations made
                    //no sense to me, and like a stubborn fool I prefer to make my own messy code that I understand than
                    //just trial-and-error copy paste some other people's nonsense that I don't understand...
                    //So yeah. It's a wreck. It's embarrassing. I'll admit it.
                    //I'll... Try to fix it. Maybe. Or just copy the random nonsense from main for Assignment3... Idk...
                    //Feedback is appreciated just maybe try not to be too brutal. I already know it sucks, I more need to know how to fix it.
                }
            } else {
                this.snack = true
            }
            this.wordList = this.main.validWords(this.guesses[this.x])
            this.sound.play()
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
    components: { SuggestionMenu, LetterKey }
}
import { useTheme } from 'vuetify/lib/framework.mjs';
import SuggestionMenu from './SuggestionMenu.vue'
import LetterKey from './LetterKey.vue'
import { reactive } from 'vue'
import { game } from '../scripts/wordList'
import { letter } from '../scripts/letter'
import * as s from '../assets/clickSound.mp3'
</script>

<template>
    <v-snackbar v-model="snack" :timeout="2500">Please enter a valid word</v-snackbar>
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
            <LetterKey v-for="item in board[0]" :letter="item.char" :status="item.status" @letterClick="addLetter"></LetterKey>
            <!-- <v-btn elevation="14" variant="tonal" @click="addLetter('Q')" :color="$props.colors[0]" rounded="xl" ref="Q">Q</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('W')" :color="$props.colors[0]" rounded="xl">W</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('E')" :color="$props.colors[0]" rounded="xl">E</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('R')" :color="$props.colors[0]" rounded="xl">R</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('T')" :color="$props.colors[0]" rounded="xl">T</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('Y')" :color="$props.colors[0]" rounded="xl">Y</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('U')" :color="$props.colors[0]" rounded="xl">U</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('I')" :color="$props.colors[0]" rounded="xl">I</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('O')" :color="$props.colors[0]" rounded="xl">O</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('P')" :color="$props.colors[0]" rounded="xl">P</v-btn> -->
        </v-row>
        <v-row justify="center">
            <LetterKey v-for="item in board[1]" :letter="item.char" :status="item.status" @letterClick="addLetter"></LetterKey>
            <!-- <v-btn elevation="14" variant="tonal" @click="addLetter('A')" :color="$props.colors[0]" rounded="xl">A</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('S')" :color="$props.colors[0]" rounded="xl">S</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('D')" :color="$props.colors[0]" rounded="xl">D</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('F')" :color="$props.colors[0]" rounded="xl">F</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('G')" :color="$props.colors[0]" rounded="xl">G</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('H')" :color="$props.colors[0]" rounded="xl">H</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('J')" :color="$props.colors[0]" rounded="xl">J</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('K')" :color="$props.colors[0]" rounded="xl">K</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('L')" :color="$props.colors[0]" rounded="xl">L</v-btn> -->
            <v-btn elevation="14" variant="outlined" @click="remove()" color="prim" rounded="xl" class="exc"><v-icon>mdi-backspace-outline</v-icon></v-btn>
        </v-row>
        <v-row justify="center">
            <SuggestionMenu :guesses="guesses" :i="x" :list="wordList"></SuggestionMenu>
            <v-btn elevation="14" variant="outlined" @click="addLetter('?')" color="prim" rounded="xl" class="exc">?</v-btn>
            <LetterKey v-for="item in board[2]" :letter="item.char" :status="item.status" @letterClick="addLetter"></LetterKey>
            <!-- <v-btn elevation="14" variant="tonal" @click="addLetter('Z')" :color="$props.colors[0]" rounded="xl">Z</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('X')" :color="$props.colors[0]" rounded="xl">X</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('C')" :color="$props.colors[0]" rounded="xl">C</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('V')" :color="$props.colors[0]" rounded="xl">V</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('B')" :color="$props.colors[0]" rounded="xl">B</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('N')" :color="$props.colors[0]" rounded="xl">N</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('M')" :color="$props.colors[0]" rounded="xl">M</v-btn> -->
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