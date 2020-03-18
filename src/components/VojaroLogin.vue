<template>
  <v-container fluid>
    <v-row
      class="justify-center"
    >
      <v-form>
        <v-text-field
          v-model="username"
          label="Nombre de usuario"
          prepend-icon="mdi-account"
          type="text"
          required
        />

        <v-text-field
          v-model="password"
          label="Contraseña"
          prepend-icon="mdi-lock"
          type="password"
          required
        />
        
        <v-btn
          color="primary"
          @click="login()"
        >
          Loguearse
        </v-btn>

      </v-form>
    </v-row>
  </v-container>
</template>

<script>
  import store from '@/store'
  import router from '@/router'

  export default {
    data() {
      return {
        username: '',
        password: '',
      }
    },
    methods: {
      login() {
        const { username, password } = this
        this.$store.dispatch('auth/login', { username, password })
        .then(() => {
          this.$router.push('/')
        })
      }
    }
  }
</script>
