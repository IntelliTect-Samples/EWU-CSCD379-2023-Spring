<template>
  <div>
    <v-chip
      color="green-lighten-2"
      append-icon="mdi-magnify"
      label
      :clickable="true"
      @click="showDialog = true"
    >
      {{ validWords?.length || 0 }} Valid Words
    </v-chip>
    <v-dialog v-model="showDialog" class="mx-auto" max-width="450">
      <v-card>
        <v-card-title>Valid Words </v-card-title>
        <v-list>
          <v-list-item v-for="(word) in validWords" :key="word">
            <v-btn
              @click="selectWord(word)"
                color="primary"
              variant="text"
              >{{ word }}
            </v-btn>
          </v-list-item>
        </v-list>
      </v-card>
    </v-dialog>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
  props: {
    validWords: Array<string>
  },
  data() {
    return {
      showDialog: false,
      
    }
  },
  computed: {
    wordCount() {
      return this.validWords?.length
    }
  },
  methods: {
    selectWord(word: string) {
      this.$emit('word-selected', word)
      this.showDialog = false
    }
  }
})
</script>
