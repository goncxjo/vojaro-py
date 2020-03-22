<template>
  <v-app>
    <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="primary"
      dark
    >
      <v-app-bar-nav-icon
        @click.stop="toggleDrawer()"
      />
      <v-toolbar-title>
        <router-link 
          to="/"
          tag="span"
        >
          <span class="toolbar-title--app">V O J A R O</span>
        </router-link>
      </v-toolbar-title>

      <v-spacer></v-spacer>
    </v-app-bar>
    <VojaroNavigationDrawer :drawer="drawer" />
    <v-content
      class="navbar-top-padding"
    >
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
  import axios from 'axios'
  import store from '@/store'
  import VojaroNavigationDrawer from '@/components/VojaroNavigationDrawer'
  
  export default {
    name: 'App',
    components: {
      VojaroNavigationDrawer
    },
    data() {
      return {
        drawer: null,
      }
    },
    created() {
      axios.interceptors.response.use(undefined, function (err) {
        return new Promise(function (resolve, reject) {
          console.log(err)
          if (err.status === 401 && err.config && !err.config.__isRetryRequest) {
            this.$store.dispatch('auth/logout')
            .then(() => {
              this.$router.push('/login')
            })
            .catch(err => {
              console.log(err)
            })
          }

          throw err
        })
      })
    },
    methods: {
      toggleDrawer() {
        this.drawer = !this.drawer
      }
    }
  }
</script>

<style lang="sass">
  .navbar-top-padding
    padding-top: 60px !important

  .toolbar-title--app
    font-weight: bold
    cursor: pointer
</style>