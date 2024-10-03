<template>
  <div class="container mx-auto p-4">
    <h2 class="text-2xl">Login</h2>
    <form @submit.prevent="login" class="mt-4">
      <div>
        <label>Email:</label>
        <input v-model="email" type="email" class="border p-2 rounded w-full" required />
      </div>
      <div class="mt-4">
        <label>Password:</label>
        <input v-model="password" type="password" class="border p-2 rounded w-full" required />
      </div>
      <button type="submit" class="mt-4 bg-blue-500 text-white p-2 rounded">Login</button>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { useUserStore } from '/store/userStore'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')
const userStore = useUserStore()
const router = useRouter()

onMounted(() => {
  userStore.initialize() // Initialize store state from localStorage if needed
})

const login = async () => {
  try {
    await userStore.login({ email: email.value, password: password.value })
    // Redirect to admin page after login
    router.push('/admin')
  } catch (error) {
    console.error('Login failed:', error)
    // Handle login error
  }
}
</script>
