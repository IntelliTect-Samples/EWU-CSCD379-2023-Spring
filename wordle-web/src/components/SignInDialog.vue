<template>
    <v-dialog :model-value="modelValue" @update:model-value="close" :max-width="300">
      <v-card>
        <div class="d-flex justify-center pa-2 bg-primary text-h6">Sign In</div>
        <v-card-text>
          <v-row>
            <v-col cols="12">
              <v-text-field v-model="username" label="User Name"> </v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field v-model="password" label="Password" type="password"> </v-text-field>
            </v-col>
          </v-row>
        </v-card-text>
        <v-card-actions>
          <v-spacer />
          <v-btn @click="signInAsync" variant="elevated" color="success"> Sign In </v-btn>
          <v-btn @click="close" variant="elevated" color="primary"> Cancel </v-btn>
        </v-card-actions>
        <p>-------------------------------------</p>
        <p><strong>Admin@intellitect.com</strong></p>
        <p><strong>P@ssw0rd123</strong></p>
        <p>Has admin and all permission.</p>
        <p>-------------------------------------</p>
        <p><strong>meg@intellitect.com</strong></p>
        <p><strong>P@ssw0rd123</strong></p>
        <p>Has MasterOfTheUniverse and over 21.</p>
        <p>-------------------------------------</p>
        <p><strong>matt@intellitect.com</strong></p>
        <p><strong>P@ssw0rd123</strong></p>
        <p>Has MasterOfTheUniverse and over 21.</p>
        <p>-------------------------------------</p>
        <p><strong>FrostyTheSnowman@intellitect.com</strong></p>
        <p><strong>P@ssw0rd123</strong></p>
        <p>Has MasterOfTheUniverse but is not over 21</p>
        <p>-------------------------------------</p>
      </v-card>
    </v-dialog>
  </template>
  
  <script lang="ts" setup>
  import { Services } from '@/scripts/services'
  import type { SignInService } from '@/scripts/signInService'
  import { inject, ref, watch } from 'vue'
  
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
      }
    }
  )
  
  const username = ref('')
  const password = ref('')
  
  const emit = defineEmits<{
    (e: 'update:model-value', value: boolean): void
  }>()
  
  function close() {
    emit('update:model-value', false)
  }
  
  async function signInAsync() {
    if (await signInService.signInAsync(username.value, password.value)) {
      close()
    } else {
      alert('Invalid user name or password')
    }
  }
  </script>