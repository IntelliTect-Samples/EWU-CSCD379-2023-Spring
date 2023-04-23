<template>
<v-dialog :model-value="modelValue" :width="300" @update:model-value="close">
    <v-card>

      <div class="bg-primary px-4 py-1 mb-4 d-flex align-center text-h6 justify-space-between">
        Settings
        <v-switch :label="isDarkMode ? 'Dark' : 'Light'" v-model="isDarkMode" hide-details density="compact" class="flex-grow-0" />
    </div>
        <v-radio-group v-model="style" class="align-self-center">
          <v-radio v-for="(s,i) in styles" :label="s" :value="s" :key="i"/>
        </v-radio-group>
    </v-card>
  </v-dialog>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue';
import { useTheme } from 'vuetify/lib/framework.mjs'

defineProps<{
    modelValue: boolean
}>();

const theme = useTheme()
const styles = ['Calm', 'Energizing', 'Easter'];

const isDarkMode = ref(theme.global.name.value.includes("dark"));

const style = ref<string>(getCurrentStyle());

function getCurrentStyle(){
    for(const s of styles){
        if(theme.global.name.value.includes(s)){
            return s;
        }
    }
    return styles[0];
}

watch([isDarkMode, style], ([isDark,style])=>{
    const d = isDark ? 'dark' : 'light';
    theme.global.name.value = `${d}${style}`;
    localStorage.setItem('v-theme', theme.global.name.value);
});

const emit = defineEmits<{
    (e: "update:model-value", value:boolean) : void
}>();

function close(){
    emit("update:model-value", false);
}
</script>
