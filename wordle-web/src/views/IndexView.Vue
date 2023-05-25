<template>
    <v-card>
        <v-row><v-card-title>Welcome to a Play on wordle!</v-card-title></v-row>
        <v-row><v-btn><RouterLink to="/game">Play Game</RouterLink></v-btn></v-row>
        <v-row><v-btn><RouterLink to="/dailywordle">Daily Game</RouterLink></v-btn></v-row>
        <v-row><v-btn><RouterLink to="/instructions">How to Play</RouterLink></v-btn></v-row>
        <v-row><v-btn><RouterLink to="/leaderboard">Leaderboard</RouterLink></v-btn></v-row>
    </v-card>
</template>