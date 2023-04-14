<!-- PLAYGROUND -->

<!-- main color: #318F6B Secondary color: #B5441C-->

<template>
 <h1> PLAYGROUND </h1>

    <v-sheet height="500px" class="pt-10 my-5">
        <v-card class="ma-10" elevation="5">
            <v-card-title> Hello World </v-card-title>
        </v-card>
    </v-sheet>

    <v-row no-gutters>
        <v-col v-for="i in 10" :key="i" cols="12" sm="6" md="4" lg="3">
            <v-card class="ma-1">
                <v-card-title> {{ i }}</v-card-title>
            </v-card>
        </v-col>
    </v-row>

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