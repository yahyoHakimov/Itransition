import { defineStore } from 'pinia'
import axios from 'axios'

export const useUserStore = defineStore('user', {
  // State equivalent in Pinia
  state: () => ({
    authToken: null, // JWT token
    user: null, // Authenticated user info
    users: [], // List of all users for admin management
  }),
  
  // Getters in Pinia are similar to computed properties
  getters: {
    isAuthenticated: (state) => !!state.authToken,
    getUsers: (state) => state.users,
  },
  
  // Actions in Pinia handle asynchronous logic like Vuex actions
  actions: {
    async register(payload) {
      try {
        console.log('Register payload:', payload)
        const response = await axios.post('https://localhost:7119/api/Account/register', payload)
        return response.data
      } catch (error) {
        console.error('Registration error:', error)
        throw error
      }
    },
    
    async login(payload) {
      try {
        const response = await axios.post('https://localhost:7119/api/Account/login', payload)
        const token = response.data.token
        this.authToken = token
        
        // Store token in localStorage
        localStorage.setItem('authToken', token)
        
        return token
      } catch (error) {
        console.error('Login error:', error)
        throw error
      }
    },

    async fetchUsers() {
      try {
        const response = await axios.get('https://localhost:7119/api/User', {
          headers: {
            'Authorization': `Bearer ${this.authToken}`,
          },
        })
        this.users = response.data
      } catch (error) {
        console.error('Fetching users error:', error)
        throw error
      }
    },

    async blockUser(userId) {
      try {
        await axios.post(`https://localhost:7119/api/User/block/${userId}`, {}, {
          headers: {
            'Authorization': `Bearer ${this.authToken}`,
          },
        })
      } catch (error) {
        console.error('Block user error:', error)
        throw error
      }
    },

    async unblockUser(userId) {
      try {
        await axios.post(`https://localhost:7119/api/User/unblock/${userId}`, {}, {
          headers: {
            'Authorization': `Bearer ${this.authToken}`,
          },
        })
      } catch (error) {
        console.error('Unblock user error:', error)
        throw error
      }
    },

    async deleteUser(userId) {
      try {
        await axios.delete(`https://localhost:7119/api/User/${userId}`, {
          headers: {
            'Authorization': `Bearer ${this.authToken}`,
          },
        })
      } catch (error) {
        console.error('Delete user error:', error)
        throw error
      }
    },

    // Initialize store with persisted data (client-only)
    initialize() {
        const token = localStorage.getItem('authToken')
        if (token) {
          this.authToken = token
        }
    },
  }
})
