<script setup lang="ts">
import NavBarLateral from '@/components/NavBarLateral.vue'
import { RouterView } from 'vue-router'
</script>

<template>
  <div class="layout">
    <NavBarLateral />
    <main class="content">
      <RouterView />
    </main>
  </div>
</template>

<style>
html, body, #app {
  height: 100%;
  margin: 0;
  padding: 0;
  overflow: hidden;
}

.layout {
  display: flex;
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}

.layout > * {
  height: 100%;
}

.layout > .content {
  flex: 1 1 80%;
  overflow-y: auto;
  background-color: #f5f5f5;
  padding: 24px;
}
</style>
