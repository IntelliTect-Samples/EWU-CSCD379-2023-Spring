<script lang="ts">
export default {
    data(){
        return {
            addLetter: (c:string) => {
                //
            }, 
            remove: () => {
                //
            },
            enter: () => {
                //
            }
        }
    },
    props: ["guess", "colors"]
}
</script>

<template>
    <div id="board">
        <v-row>
            <v-card variant="outlined" class="tile"></v-card>
            <v-card variant="outlined" class="tile"></v-card>
            <v-card variant="outlined" class="tile"></v-card>
            <v-card variant="outlined" class="tile"></v-card>
            <v-card variant="outlined" class="tile"></v-card>
        </v-row>
    </div>
    <div id="keys">
        <v-row>
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
        <v-row>
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
        <v-row>
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
</template>

<style scoped>
    button {
        margin: 3px;
    }
    .tile {
        min-height: 75px;
        min-width: 75px;
        margin: 3px;
    }
    #board {
        margin-bottom: 25px;
    }
    #keys {
        margin-top: 25px;
    }
</style>