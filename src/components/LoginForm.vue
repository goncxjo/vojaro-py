<template>
  <v-container>
    <v-row
      class="justify-center"
    >
      <v-form
        v-model="isValid"
        class="to-center"
      >
        <v-text-field
          v-model="username"
          label="Nombre de usuario"
          prepend-icon="mdi-account"
          type="text"
          :rules="reglasUsuario"
          required
        />

        <v-text-field
          v-model="password"
          label="Contraseña"
          prepend-icon="mdi-lock"
          type="password"
          :rules="reglasPassword"
          v-on:keyup.enter="login()"
          required
        />
      
        <v-btn
          class="mt-5"
          color="primary"
          :disabled="!isValid"
          @click="login()"
        >
          Loguearse
        </v-btn>

        <p>{{ error }}</p>

      </v-form>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    data() {
      return {
        username: '',
        password: '',
        isValid: true,
        reglasUsuario: [ v => !!v || 'El nombre de usuario es requerido' ],
        reglasPassword: [ v => !!v || 'La contraseña es requerida' ],
        error: null
      }
    },
    methods: {
      login() {
        const { username, password } = this
        this.$store.dispatch('login', { username, password })
        .then(() => {
          this.$router.push('/')
        })
        .catch(err => {
          this.error = err.response.data.error
        })
      }
    }
  }
</script>

<style lang="sass">
  .to-center
    display: flex
    justify-content: center
    flex-direction: column
</style>