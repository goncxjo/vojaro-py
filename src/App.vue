<template>
  <v-app>
    <v-app-bar
      app
      color="primary"
      dark
    >
      <v-toolbar-title>V O J A R O</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn
        href="#"
        target="_blank"
        text
      >
        <span class="mr-2">Iniciar sesión</span>
        <v-icon>mdi-open-in-new</v-icon>
      </v-btn>
    </v-app-bar>
    <v-content class="navbar-top-padding">
      <router-view/>
    </v-content>
  </v-app>
</template>

<script>

export default {
  name: 'App',

  data: () => ({
    //
  })
}
</script>

<style lang="sass">
  .navbar-top-padding
    padding-top: 100px !important
</style>