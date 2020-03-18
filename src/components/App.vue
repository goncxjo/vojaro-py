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

      <div
        v-if="showItems"
      >
        <v-btn
          v-for="item in modules"
          :key="item.route"
          :to="item.route"
          text
        >
          {{ item.title }}
        </v-btn>

        <v-btn 
          @click="logout()"
          icon
          text
        >
          <v-icon>mdi-account-circle</v-icon>
        </v-btn>
      </div>
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
  import axios from 'axios'
  import store from '@/store'
  
  export default {
    name: 'App',

    data() {
      return {
        modules: [
          {
            route: '/universidades',
            title: 'Universidades'
          },
          {
            route: '/carreras',
            title: 'Carreras'
          },
          {
            route: '/asignaturas',
            title: 'Asignaturas'
          },
        ]
      }
    },
    methods: {
      logout() {
        this.$store.dispatch('auth/logout')
        .then(() => {
          this.$router.push('/login')
        })
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
    computed: {
      showItems() {
        return store.getters['auth/isAuthenticated']
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