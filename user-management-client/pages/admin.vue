<template>
  <div class="container mx-auto p-4">
    <h2 class="text-2xl">User Management</h2>
    <table class="min-w-full bg-white mt-4">
      <thead>
        <tr>
          <th class="py-2">ID</th>
          <th class="py-2">Name</th>
          <th class="py-2">Email</th>
          <th class="py-2">Status</th>
          <th class="py-2">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="user in users" :key="user.id">
          <td>{{ user.id }}</td>
          <td>{{ user.name }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.status }}</td>
          <td>
            <button @click="blockUser(user.id)" class="bg-red-500 text-white p-2 rounded">Block</button>
            <button @click="unblockUser(user.id)" class="bg-green-500 text-white p-2 rounded ml-2">Unblock</button>
            <button @click="deleteUser(user.id)" class="bg-gray-500 text-white p-2 rounded ml-2">Delete</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup>
import { onMounted } from 'vue'
import { useUserStore } from '/store/userStore'

const store = useUserStore()
const users = computed(() => store.getUsers)

const blockUser = async (userId) => {
  await store.blockUser(userId)
  await store.fetchUsers();
}

const unblockUser = async (userId) => {
  await store.unblockUser(userId)
  await store.fetchUsers();
}

const deleteUser = async (userId) => {
  await store.deleteUser(userId)
  await store.fetchUsers();
}

onMounted(() => {
  store.initialize()
  store.fetchUsers()
})

</script>
