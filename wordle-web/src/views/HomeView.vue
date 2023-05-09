<template>
  <main>
    <div class="home-content">
      <h1>This is a cat</h1>
      <img
        class="cat"
        src="https://www.sfspca.org/wp-content/uploads/2023/05/e7f90e38-2b38-48b6-b82a-96943138708c.jpg"
        alt="Description of the image"
      />
      <h1>Assignment 3 was challenging. May this picture provide you some relief.</h1>
    </div>
  </main>
</template>

<script setup lang="ts"></script>

<style scoped>
.home-content {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100vw;
}

.cat {
  border-radius: 8px;
}
</style>
```
