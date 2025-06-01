<template>
  <header class="navbar">
    <div class="logo">Meu Sistema</div>
    <div class="links">
      <Button label="Home" text @click="router.push('/')" />
      <Button label="Contatos" text @click="router.push('/contatos')" />
    </div>
  </header>
</template>

<script setup lang="ts">
import Button from 'primevue/button'
import { useRouter } from 'vue-router'

const router = useRouter()
</script>

<style scoped>
.navbar {
  background-color: #00204b;
  color: white;
  padding: 16px 24px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.logo {
  font-size: 20px;
  font-weight: bold;
}

.links {
  display: flex;
  gap: 12px;
}
</style>
