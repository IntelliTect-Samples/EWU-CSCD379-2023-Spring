<template>
    <v-menu
      v-model="menu"
      :close-on-content-click="false"
      location="end"
    >
      <template v-slot:activator="{ props }">
        <v-btn
          color="indigo"
          v-bind="props"
        >
          Themes
        </v-btn>
      </template>
        <v-list>
            <v-list-item>
                <v-list-item-title>Current Theme: {{ current }}</v-list-item-title>
            </v-list-item>
            <v-list-item
            v-for="theme in themes"
            :key="theme.name"
            @click="current=theme.name;"
            >
                <v-list-item-title>{{ theme.name }}</v-list-item-title>
            </v-list-item>
        </v-list>
    </v-menu>
</template>

<script lang="ts">
    import { Theme } from '@/scripts/theme'
    export default {
        data: () => ({
        current: 'Default',
        menu: false,
            themes: [new Theme(),
            new Theme('Unicorn', ['#D7B8F3', '#8A4F7D', '#64B6AC', '#065A82']),
            new Theme('Pumpkin', ['#515A47', '#B4CEB3', '#ED9B40', '#7A4419'])],
        }),
    }
</script>