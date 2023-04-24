<script lang="ts">
export default {
    data() {
        let guesses = ["", "", ""];
        for (let i = 3; i < this.guess; i++) {
            guesses.push("");
        }
        let cur = 0
        let display = false
        return {
            addLetter: (c: string) => {
                guesses[cur] += c;
            },
            remove: () => {
                //
            },
            enter: () => {
                //
                if (cur < guesses.length) {
                    //
                    console.log(cur);
                    cur += 1;
                    console.log(cur);
                }
            },
            displaySuggestions() {
                //display ? "false" : "true";
                let temp = guesses[cur].split("")
                //this.$refs.suggestions.validWords(temp)
            },
            guesses,
            cur,
            display
        };
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
            <v-btn elevation="14" variant="tonal" @click="addLetter('Q')" :color="$props.colors[0]" rounded="xl">Q</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('W')" :color="$props.colors[1]" rounded="xl">W</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('E')" :color="$props.colors[2]" rounded="xl">E</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('R')" :color="$props.colors[3]" rounded="xl">R</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('T')" :color="$props.colors[0]" rounded="xl">T</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('Y')" :color="$props.colors[0]" rounded="xl">Y</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('U')" :color="$props.colors[0]" rounded="xl">U</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('I')" :color="$props.colors[0]" rounded="xl">I</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('O')" :color="$props.colors[0]" rounded="xl">O</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('P')" :color="$props.colors[0]" rounded="xl">P</v-btn>
        </v-row>
        <v-row justify="center">
            <v-btn elevation="14" variant="tonal" @click="remove()" :color="$props.colors[0]" rounded="xl"><v-icon>mdi-backspace-reverse-outline</v-icon></v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('A')" :color="$props.colors[0]" rounded="xl">A</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('S')" :color="$props.colors[0]" rounded="xl">S</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('D')" :color="$props.colors[0]" rounded="xl">D</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('F')" :color="$props.colors[0]" rounded="xl">F</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('G')" :color="$props.colors[0]" rounded="xl">G</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('H')" :color="$props.colors[0]" rounded="xl">H</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('J')" :color="$props.colors[0]" rounded="xl">J</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('K')" :color="$props.colors[0]" rounded="xl">K</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('L')" :color="$props.colors[0]" rounded="xl">L</v-btn>
        </v-row>
        <v-row justify="center">
            <v-btn elevation="14" variant="tonal" @click="displaySuggestions()" :color="$props.colors[0]" rounded="xl"><v-icon>mdi-chevron-down-circle-outline</v-icon></v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('?')" :color="$props.colors[0]" rounded="xl">?</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('Z')" :color="$props.colors[0]" rounded="xl">Z</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('X')" :color="$props.colors[0]" rounded="xl">X</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('C')" :color="$props.colors[0]" rounded="xl">C</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('V')" :color="$props.colors[0]" rounded="xl">V</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('B')" :color="$props.colors[0]" rounded="xl">B</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('N')" :color="$props.colors[0]" rounded="xl">N</v-btn>
            <v-btn elevation="14" variant="tonal" @click="addLetter('M')" :color="$props.colors[0]" rounded="xl">M</v-btn>
            <v-btn elevation="14" variant="tonal" @click="enter()" :color="$props.colors[0]" rounded="xl"><v-icon>mdi-arrow-left-bottom</v-icon></v-btn>
        </v-row>
    </div>
    <SuggestionMenu v-model="display" :guesses="guesses" id="suggest" ref="suggestions"></SuggestionMenu>
</template>

<style scoped>
    button {
        margin: 5px;
        background-image: linear-gradient(#d9d9d900, #bfbebe29, #8b8b8b92);
    }
    .tile {
        min-height: 75px;
        min-width: 75px;
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