<template>
    <v-card>
        <v-layout>
            <v-app-bar>
                <template v-slot:prepend>
                    <router-link to="/"><v-app-bar-nav-icon icon="mdi-domain"></v-app-bar-nav-icon></router-link>
                    <router-link to="/"><v-app-bar-title> wordle</v-app-bar-title></router-link>

                </template>
                <template v-slot:append>
                    <v-app-bar-nav-icon>
                        <v-menu>
                            <template v-slot:activator="{props}">
                                <v-btn v-bind="props" icon="mdi-hamburger">
                                    
                                </v-btn>
                            </template>

                            <v-list>
                                <v-list-item v-for="(item, index) in items" :key="index">
                                    <v-list-item-title>{{ item.title }}</v-list-item-title>
                                </v-list-item>
                            </v-list>

                        </v-menu>

                    </v-app-bar-nav-icon>

                </template>

            </v-app-bar>

        </v-layout>
    </v-card>

</template>


<script>
import { RouterLink, RouterView } from 'vue-router'

</script>