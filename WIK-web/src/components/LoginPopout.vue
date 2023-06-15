<template>
  <v-btn icon>
    <v-icon>mdi-login</v-icon>
    <v-dialog
      width="75%"
      height="75%"
      v-model="open"
      activator="parent"
      transition="dialog-top-transition"
    >
      <v-card width="100%" height="75%">
        <v-card-item class="justify-end">
          <v-btn icon dark @click="open = false">
            <v-icon>mdi-close</v-icon>
          </v-btn>
        </v-card-item>
        <v-card-title class="text-center">{{loginText}}</v-card-title>

        <v-chip-group v-show="login" outlined class="justify-center ma-10 pa-10">
          <v-card-title class="text-center">Please enter your information:</v-card-title>
          <v-text-field
            :disabled="logout"
            label="User"
            v-model="username"
            variant="outlined"
          ></v-text-field>
          <v-text-field
            :disabled="logout"
            label="Password"
            v-model="password"
            variant="outlined"
          ></v-text-field>
          <v-card-title>{{ errorText }}</v-card-title>
        </v-chip-group>
        <v-chip-group v-show="login" outlined class="justify-center ma-10 pa-10">
          <v-card-title class="text-center">Create an Account</v-card-title>
          <v-text-field
            :disabled="logout"
            label="User"
            v-model="usernameNew"
            variant="outlined"
          ></v-text-field>
          <v-text-field
            :disabled="logout"
            label="Password"
            v-model="passwordNew"
            variant="outlined"
          ></v-text-field>
          <v-card-title>{{ errorText2 }}</v-card-title>
        </v-chip-group>
        <v-chip-group class="justify-center ma-10 pa-10">
          <v-chip v-model="login" size="small" @click="wordleLogin">Login</v-chip>
          <v-chip v-model="logout" size="small" @click="logoutUser">Logout</v-chip>
          <v-chip v-show="login" size="small" @click="signUp">Sign Up</v-chip>
          <v-card-title class="text-center">{{ result }}</v-card-title>
        </v-chip-group>
      </v-card>
    </v-dialog>
  </v-btn>
</template>

<script setup lang="ts">
import Axios from 'axios'
import { ref } from 'vue'

const username = ref('')
const password = ref('')
const usernameNew = ref('')
const passwordNew = ref('')
const result = ref('')
const errorText = ref('')
const errorText2 = ref('')
const open = ref(false)
const login = ref(localStorage.getItem('username') === null)
const logout = ref(localStorage.getItem('username') !== null)
const loginText = ref(login.value ? 'Login' : localStorage.getItem('username'))

function wordleLogin() {
  Axios.get('/User?username=' + username.value + '&password=' + password.value)
    .then((response) => {
      console.log(response.data)
      if (response.data !== 'Invalid Username or Password') {
        setLoginInfo()
        open.value = false
        login.value = false
        logout.value = true
        errorText.value = ''
        window.location.reload()
      } else {
        errorText.value = 'Invalid Username or Password'
      }
    })
    .catch((error) => {
      console.log(error)
    })
}

function setLoginInfo() {
  localStorage.setItem('username', username.value)
  localStorage.setItem('password', password.value)
  username.value = ''
  password.value = ''
}

function logoutUser() {
  localStorage.removeItem('username')
  localStorage.removeItem('password')
  login.value = true
  logout.value = false
  window.location.reload()
}

function signUp(){
  Axios.get('/User/CheckUsername?username=' + usernameNew.value)
  .then((response) => {
    console.log(response.data)
    if(!response.data){
      Axios.post('/User?username='+usernameNew.value+'&password='+passwordNew.value)
      .then((response) => {
        console.log(response)
        username.value = usernameNew.value
        password.value = passwordNew.value
        setLoginInfo()
        open.value = false
        login.value = false
        logout.value = true
        errorText.value = ''
        window.location.reload()
      })
    }
    else{
      errorText2.value = "Username taken."
    }
  })
}


// if (username.value == 'Realuser') {
//   result.value = 'Wrong password. Try "im20dude".'
//   if (password.value == 'im20dude') {
//     localStorage.setItem('user', username.value)
//     localStorage.setItem('age', 'under')
//     result.value = 'Success. use "im21dude" if you are normal and can be trusted.'
//   } else if (password.value == 'im21dude') {
//     localStorage.setItem('user', username.value)
//     localStorage.setItem('age', 'above')
//     result.value = 'Success. You can update common words.'
//   }
// } else {
//   result.value = 'Wrong user. Try "Realuser".'
// }

// console.log(localStorage.getItem('user'))
// console.log(localStorage.getItem('age'))

let dialog = ref(false)
</script>
