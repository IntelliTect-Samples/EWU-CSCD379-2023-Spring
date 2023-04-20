<template>
  <div class = 'about'>
    <h1>About Page</h1>
    <p>
      Our project is going pretty well so far. This framework is pretty cool -- it sure
      beats coding everything from scratch!
    </p>
    <p>
      And yes, Meg is a great teacher.
    </p>
    <v-btn @click = 'goBack'>Go Back</v-btn>
  </div>
</template>

<script lang = 'ts'>
function goBack() {
  this.$router.go(-1)
}

export default {
  methods: {
    goBack
  }
}
</script>

<style>
@media (min-width: 1024px) {
  .about {
    min-height: 100vh;
  }
}
</style>
