<template>
    <v-row v-show="!loggedIn" class="justify-center">
        <h1>Login To See Stats!</h1>
    </v-row>

    <v-container v-show="loggedIn">
        <v-row  class="justify-center"><h1>{{ name }}</h1></v-row>
        <v-row >
            <v-col></v-col>
            <v-col class="align-end"><h2>Wins: {{ wins }}</h2></v-col>
            <v-col></v-col>
            <v-col class="align-end"><h2>Loses: {{ loses }}</h2></v-col>
        </v-row>
    </v-container>
</template>

<script setup lang="ts">
    import  Axios  from 'axios'
    import { ref } from 'vue' 
    const username = localStorage.getItem('username')
    const password = localStorage.getItem('password')

    const loggedIn = ref(username !== null)
    const name = ref(username)
    const wins = ref('0')
    const loses = ref('0')
    Axios.get("/User?username=" + username + "&password="+ password)
    .then((response) => {
      console.log(response.data)
      if(response.data !== "Invalid Username or Password"){
        getWinLose(response.data)
      }
    })
    .catch((error) => {
      console.log(error)
    })

    function getWinLose(info: string){
        let infoArr = info.split(',')

        wins.value = infoArr[1]
        loses.value = infoArr[2]
    }
</script>
