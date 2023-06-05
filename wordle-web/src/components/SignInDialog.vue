<template>
  <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="300">
    <v-card>
      <div class="d-flex justify-center pa-2 bg-primary text-h6" v-if="!signup">Sign In</div>
      <div class="d-flex justify-center pa-2 bg-primary text-h6" v-if="signup">Sign Up</div>
      <v-card-text>
        <v-row>
          <v-col cols="12">
            <v-text-field v-model="username" label="User Name"> </v-text-field>
          </v-col>
          <v-col cols="12">
            <v-text-field v-model="password" label="Password" type="password"> </v-text-field>
          </v-col>
          <v-col cols="12" v-if="signup">
            <v-text-field v-model="name" label="Name"> </v-text-field>
          </v-col>
          <v-col cols="12" v-if="signup">
            <v-text-field v-model="bday" label="Birthday (DD/MM/YYYY)"> </v-text-field>
          </v-col>
        </v-row>
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn v-if="!signup" @click="signUpMode" variant="elevated" color="success">
          Sign Up
        </v-btn>
        <v-btn v-if="signup" @click="signUpAsync" variant="elevated" color="success">
          Confirm
        </v-btn>
        <v-btn v-if="!signup" @click="signInAsync" variant="elevated" color="success">
          Sign In
        </v-btn>
        <v-btn v-if="!signup" @click="close" variant="elevated" color="primary"> Cancel </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import { Services } from '@/scripts/services'
import type { SignInService } from '@/scripts/signInService'
import { watch } from 'vue'
import { inject, ref } from 'vue'

const signInService = inject(Services.SignInService) as SignInService

const props = defineProps<{
  modelValue: boolean
}>()

watch(
  () => props.modelValue,
  (value) => {
    if (value) {
      username.value = ''
      password.value = ''
      name.value = ''
      bday.value = ''
    }
  }
)

const username = ref('')
const password = ref('')
const name = ref('')
const age = ref()
const year = ref()
const month = ref()
const day = ref()
const signup = ref(false)
const bday = ref('')

const emit = defineEmits<{
  (e: 'update:model-value', value: boolean): void
}>()

function close() {
  emit('update:model-value', false)
}

function signUpMode() {
  if (signup.value == true) {
    signup.value = false
  } else {
    signup.value = true
  }
}

function calculateAge(birthday: string) {
  let bday = new Date(Date.parse(birthday))
  let currentDate = new Date()

  age.value = currentDate.getFullYear() - bday.getFullYear()
  year.value = bday.getFullYear().toString()
  console.log(year.value)
  month.value = (bday.getMonth() + 1).toString()
  console.log(month.value)
  day.value = bday.getDate().toString()
  console.log(day.value)

  if (
    currentDate.getMonth() < bday.getMonth() ||
    (currentDate.getMonth() === bday.getMonth() && currentDate.getDate() < bday.getDate())
  ) {
    age.value--
  }
}

async function signInAsync() {
  if (await signInService.signInAsync(username.value, password.value)) {
    close()
  } else {
    alert('Invalid user name or password')
  }
}

async function signUpAsync() {
  calculateAge(bday.value)
  if (
    await signInService.signUpAsync(
      username.value,
      password.value,
      name.value,
      year.value,
      month.value,
      day.value
    )
  ) {
    close()
  } else {
    alert('Invalid user name or password')
  }
  signup.value = false
}
</script>
