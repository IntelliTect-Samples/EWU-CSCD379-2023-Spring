<template>
    <v-row justify="center" align="center">
        <v-col cols="12" sm="8" md="6">
            <v-card-title class="headline justify-center">
                <h1>Wordle</h1>
            </v-card-title>
            <v-card class="logo py-4 d-flex justify-center">
                <DTCannon />
            </v-card>
            <v-card>
                <v-card-title class="headline">
                    Welcome to the game page.
                </v-card-title>
                <v-card-text>
                    <p>
                        This game page uses a progressive Material Design component framework for
                        Vue.js.
                    </p>
                    <hr class="my-3" />
                </v-card-text>
                <v-card-actions>
                    <v-spacer />
                    <v-btn color="secondary" nuxt to="/"> home </v-btn>
                    <v-btn color="primary" nuxt to="/game"> restart </v-btn>
                </v-card-actions>
            </v-card>
        </v-col>
    </v-row>
</template>

<script>
export default {
    name: "game"
}
</script>

<style scoped>

</style>