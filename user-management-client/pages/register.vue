<template>
  <div class="container mx-auto p-4">
    <h2 class="text-2xl">Register</h2>
    <form @submit.prevent="register" class="mt-4">
      <div>
        <label>Email:</label>
        <input v-model="email" type="email" class="border p-2 rounded w-full" required />
      </div>
      <div class="mt-4">
        <label>Password:</label>
        <input v-model="password" type="password" class="border p-2 rounded w-full" required />
      </div>
      <div class="mt-4">
        <label>Confirm Password:</label>
        <input v-model="confirmPassword" type="password" class="border p-2 rounded w-full" required />
      </div>
      <button type="submit" class="mt-4 bg-green-500 text-white p-2 rounded">Register</button>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue'
import { useUserStore } from '/store/userStore'
import { useRouter } from 'vue-router'

const email = ref('')
const password = ref('')
const confirmPassword = ref('')
const userStore = useUserStore()
const router = useRouter()

onMounted(() => {
  userStore.initialize() // Initialize store state from localStorage if needed
})

const register = async () => {
  try {
    if (password.value !== confirmPassword.value) {
      alert('Passwords do not match!')
      return
    }

    await userStore.register({ email: email.value, password: password.value })
    alert('Registration successful! Please log in.')
    router.push('/login')
  } catch (error) {
    console.error('Registration failed:', error)
    alert('Registration failed. Please try again.')
  }
}
</script>
