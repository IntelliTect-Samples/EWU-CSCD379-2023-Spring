<script setup lang="ts">
import WelcomeItem from './WelcomeItem.vue'
import DocumentationIcon from './icons/IconDocumentation.vue'
import ToolingIcon from './icons/IconTooling.vue'
import EcosystemIcon from './icons/IconEcosystem.vue'
import CommunityIcon from './icons/IconCommunity.vue'
import SupportIcon from './icons/IconSupport.vue'
</script>

<template>
  <WelcomeItem>
    <template #heading>Documentation</template>
    Hello and welcome to our bootleg Wordle game!! Unlike the much more successful counterpart, here you can easily 
    play as many games as you want! No more being limited to one a day.
  </WelcomeItem>
</template>
