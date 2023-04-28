<script lang="ts">
export default{
    data(){
        return {
            color: 'grey'
        }
    },
    methods: {
        updateColor(s:number){
            if(s == 1){
                this.color = 'green'
            } else if(s == 2){
                this.color = 'gold'
            } else if(s == 3){
                this.color = 'red'
            }
        }
    },
    props: ['letter', 'status'],
    watch: {
        status(){
            this.updateColor(this.status)
        }
    }
}
</script>
<template>
    <v-btn elevation="14" variant="tonal" @click="$emit('letterClick', letter)" :color="color" rounded="xl">{{ letter }}</v-btn>
</template>