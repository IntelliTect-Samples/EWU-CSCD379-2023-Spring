<template>
    <nav>
        <v-toolbar flat app>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            <v-toolbar-title @click="$router.push('/')"><v-icon>mdi-diamond-stone</v-icon> Wordle Redux</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items class="red--text">
                <v-btn  to="/">Home</v-btn>
                <v-btn  to="/wordle">Wordle</v-btn>
                <v-btn  to="/about">About</v-btn>
            </v-toolbar-items>
        </v-toolbar>



        <v-navigation-drawer @click.stop="drawer = !drawer" v-model="drawer" temporary>
            <v-list-item>
                <v-list-item-content>
                    <v-list-item-title class="title" >Wordle Redux</v-list-item-title>
                    <v-list-item-subtitle>Wordle Redux</v-list-item-subtitle>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-home" to="/"> Home </v-list-item>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-star" to="/wordle"> Wordle </v-list-item>
                    <v-list-item @click.stop="drawer = !drawer" prepend-icon="mdi-information" to="/about"> About</v-list-item> 
                </v-list-item-content>
            </v-list-item>
        </v-navigation-drawer>

    </nav>
</template>

<script>
export default{
    name: 'NavBar',
    data: () => ({
        drawer: false
    })

}

</script>