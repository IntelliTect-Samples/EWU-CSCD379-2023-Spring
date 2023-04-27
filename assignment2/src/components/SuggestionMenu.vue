<script lang="ts">
import { useTheme } from 'vuetify/lib/framework.mjs';
import { game } from '../scripts/wordList'

export default {
    data(){
        const main = new game()
        let tempList:string[] = []
        const wordList = main.words
        return{
            wordList, tempList,
            count: tempList.length,
            dialog: false,
            prim: useTheme().global.current.value.colors.primary
        }
    },
    methods: {
        validWords: function(guess:string[]){
            this.wordList.forEach(word => {
                for(let i = 0; i < 5; i++){
                    if(guess[i] != '?'){
                        if(word.split("")[i] == guess[i]){
                            this.tempList.push(word)
                        }
                    }
                }
            });
        },
        enterWord: function(guess:string){
          console.log(guess)
        }
    },
  props: ['guesses', 'display'],
  watch: {
    display() {
        this.dialog = this.$props.display
    }
  }
}
</script>

<template>
    <v-dialog
      v-model="dialog"
      width="auto"
    >
      <template v-slot:activator="{ props }">
        <v-btn color="prim" v-bind="props" elevation="14" variant="outlined" rounded="xl" id="key">
            <v-icon size="small">mdi-file-find</v-icon>
            {{ count }}
        </v-btn>
      </template>

      <v-card>
        <h3 class="text-center" style="padding: 15px; border-bottom: 3px white double;">Suggested Words</h3>
        <v-list density="compact" style="padding: 35px;">
          <v-list-item v-for="word in tempList" :key="word" :title="word" @click="enterWord(word)"></v-list-item>
        </v-list>
      </v-card>
    </v-dialog>
</template>

<style>
    #key {
        margin: 5px;
    }
</style>