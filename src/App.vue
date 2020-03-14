<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <v-toolbar-title>
        <router-link 
          to="/"
          tag="span"
        >
          <span class="toolbar-title--app">V O J A R O</span>
        </router-link>
      </v-toolbar-title>

      <v-spacer></v-spacer>

      <v-btn
        v-for="modulo in modulos"
        :key="modulo.ruta"
        :to="modulo.ruta"
        text
      >
        {{ modulo.titulo }}
      </v-btn>

      <v-btn icon
        to="/login"
        text
      >
        <v-icon>mdi-account-circle</v-icon>
      </v-btn>
    </v-app-bar>
    
    <v-content class="navbar-top-padding">
      <v-container>
        <router-view/>
      </v-container>
    </v-content>

    <v-footer app>
      <span>&copy; 2020</span>
    </v-footer>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  data() {
    return {
      modulos: [
        {
          ruta: '/universidades',
          titulo: 'Universidades'
        },
        {
          ruta: '/carreras',
          titulo: 'Carreras'
        },
        {
          ruta: '/asignaturas',
          titulo: 'Asignaturas'
        },
      ]
    }
  }
}
</script>

<style lang="sass">
  .navbar-top-padding
    padding-top: 100px !important

  .toolbar-title--app
    font-weight: bold
    cursor: pointer
</style>