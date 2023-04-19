<template>
  <div class="keyboard">
    <v-card color="lightgrey" mx-auto variant="outlined">
      <v-card-item>
        <v-row class="justify-center">
          <v-col v-for="(key, index) in keys[0]" :key="index" cols="auto" class="px-1">
            <v-btn size="small" class="key" @click="onKeyClick(key)">{{ key }}</v-btn>
          </v-col>
        </v-row>
        <v-row class="justify-center">
          <v-col v-for="(key, index) in keys[1]" :key="index" cols="auto" class="px-1">
            <v-btn size="small" class="key" @click="onKeyClick(key)">{{ key }}</v-btn>
          </v-col>
        </v-row>
        <v-row class="justify-center">
          <v-col cols="auto" class="px-1">
            <v-btn size="small" class="key special-key" @click="onKeyClick('Enter')">Enter</v-btn>
          </v-col>
          <v-col v-for="(key, index) in keys[2]" :key="index" cols="auto" class="px-1">
            <v-btn size="small" class="key" @click="onKeyClick(key)">{{ key }}</v-btn>
          </v-col>
          <v-col cols="auto" class="px-1">
            <v-btn size="small" class="key special-key" @click="onKeyClick('Backspace')"
              >Delete</v-btn
            >
          </v-col>
        </v-row>
      </v-card-item>
    </v-card>

    <v-divider class="my-2"></v-divider>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'
import type { PropType } from 'vue'

export default defineComponent({
  props: {
    guess: {
      type: String as PropType<string>,
      required: true
    }
  },
  created() {
    document.addEventListener('keydown', (event) => {
      this.onKeyClick(event.key)
    })
  },
  data() {
    return {
      keys: [
        ['q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'],
        ['a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l'],
        ['z', 'x', 'c', 'v', 'b', 'n', 'm']
      ]
    }
  },
  methods: {
    onKeyClick(key: string) {
      this.$emit('key-pressed', key)
    }
  }
})
</script>

<style scoped>
.key {
  min-width: 40px;
  width: 40px;
  border-radius: 0;
}

.special-key {
  min-width: 60px;
  width: 60px;
}

@media (max-width: 600px) {
  .key {
    font-size: 0.8rem;
    min-width: 35px;
    width: 35px;
  }

  .special-key {
    font-size: 0.8rem;
    min-width: 55px;
    width: 55px;
  }
}
</style>
