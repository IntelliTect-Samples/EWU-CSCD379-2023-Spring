<template>
  <div class="keyboard">
    <v-row class="justify-center">
      <v-col v-for="(key, index) in keys[0]" :key="index" cols="auto" class="px-1">
        <v-btn class="key" @click="onKeyPress(key)">{{ key }}</v-btn>
      </v-col>
    </v-row>
    <v-row class="justify-center">
      <v-col v-for="(key, index) in keys[1]" :key="index" cols="auto" class="px-1">
        <v-btn class="key" @click="onKeyPress(key)">{{ key }}</v-btn>
      </v-col>
    </v-row>
    <v-row class="justify-center">
      <v-col cols="auto" class="px-1">
        <v-btn class="key special-key" @click="onKeyPress('Enter')">Enter</v-btn>
      </v-col>
      <v-col v-for="(key, index) in keys[2]" :key="index" cols="auto" class="px-1">
        <v-btn class="key" @click="onKeyPress(key)">{{ key }}</v-btn>
      </v-col>
      <v-col cols="auto" class="px-1">
        <v-btn class="key special-key" @click="onKeyPress('Delete')">Delete</v-btn>
      </v-col>
    </v-row>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { VRow, VCol, VBtn } from "vuetify/components";

export default defineComponent({
  components: {
    VRow,
    VCol,
    VBtn,
  },
  data() {
    return {
      keys: [
        ["Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P"],
        ["A", "S", "D", "F", "G", "H", "J", "K", "L"],
        ["Z", "X", "C", "V", "B", "N", "M"],
      ],
    };
  },
  methods: {
    onKeyPress(key: string) {
      this.$emit("key-press", key);
    },
  },
});
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
