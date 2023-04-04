<template>
    <div class="about">
        <v-card>
            <v-card-title> This is a vue/vuetify class! </v-card-title>
            <v-card-subtitle> (College Class) </v-card-subtitle>

            <v-card-text> 
             Lorem ipsum solte dolor sit amet blah blah 
             <v-icon icon="mdi:mdi-abacus" />
            </v-card-text>

            <v-card-actions>
                <v-spacer />
                <v-btn text color="warning">Cancel</v-btn>
                <v-btn text color="primary">OK</v-btn>
            </v-card-actions>
        </v-card>
    </div>
</template>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
    display: flex;
    align-items: center;
  }
}
</style>
