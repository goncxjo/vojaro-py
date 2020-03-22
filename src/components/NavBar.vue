<template>
  <v-app-bar
    color="white"
    elevate-on-scroll
    flat
    app
  >
    <v-toolbar-title>
        <router-link to="/" tag="span">
            <span class="toolbar-title--app">{{ this.title }}</span>
        </router-link>
    </v-toolbar-title>
    <v-spacer></v-spacer>
    <v-app-bar-nav-icon
      v-if="showNavIcon"
      @click="toggleDrawer()"
      ></v-app-bar-nav-icon>
  </v-app-bar>
</template>


<script>
  import store from '@/store'
  
  export default {
    data() {
      return {
          title: 'V O J A R O'
      }
    },
    methods: {
      toggleDrawer() {
        this.$store.commit(`shared/toggleDrawer`)
      }
    },
    computed: {
      showNavIcon() {
        return store.getters['auth/isAuthenticated']
      }
    }
  }
</script>

<style lang="sass">
  .toolbar-title--app
    cursor: pointer
    font-weight: 500
    color: grey
    -webkit-user-select: none
    -moz-user-select: none
    -ms-user-select: none
    user-select: none
</style>