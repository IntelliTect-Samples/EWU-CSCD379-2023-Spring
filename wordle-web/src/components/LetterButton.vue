<template>
  <LetterBase :char="props.letter.char" :class="letterClass"></LetterBase>
</template>

<script setup lang="ts">
import { LetterStatus, type Letter } from '@/scripts/letter'
import LetterBase from './LetterBase.vue'
import { computed } from 'vue'

export interface Props {
  letter: Letter
}

const props = defineProps<Props>()

const letterClass = computed(() => {
  if (!props.letter.char) return 'empty'

  switch (props.letter.status) {
    case LetterStatus.Correct:
      return 'correct'
    case LetterStatus.Wrong:
      return 'wrong'
    case LetterStatus.Misplaced:
      return 'misplaced'
    case LetterStatus.NotGuessed:
      return 'default'
  }
  return ''
})
</script>

<style scoped>
.correct {
  background-image: linear-gradient(
    to bottom,
    rgba(var(--v-theme-correct), 1) 0%,
    rgba(var(--v-theme-correct), 0.5) 70%,
    rgba(var(--v-theme-correct), 0.5) 85%,
    rgba(var(--v-theme-correct), 0.8) 100%
  );
}

.wrong {
  background-image: linear-gradient(
    to bottom,
    rgba(var(--v-theme-wrong), 1) 0%,
    rgba(var(--v-theme-wrong), 0.5) 70%,
    rgba(var(--v-theme-wrong), 0.5) 85%,
    rgba(var(--v-theme-wrong), 0.8) 100%
  );
}

.misplaced {
  background-image: linear-gradient(
    to bottom,
    rgba(var(--v-theme-misplaced), 1) 0%,
    rgba(var(--v-theme-misplaced), 0.5) 70%,
    rgba(var(--v-theme-misplaced), 0.5) 85%,
    rgba(var(--v-theme-misplaced), 0.8) 100%
  );
}
.default {
  background-image: linear-gradient(
    to bottom,
    rgba(var(--v-theme-default), 1) 0%,
    rgba(var(--v-theme-default), 0.5) 70%,
    rgba(var(--v-theme-default), 0.5) 85%,
    rgba(var(--v-theme-default), 0.8) 100%
  );
}

.empty {
  background-color: transparent;
}
</style>
