<template>
    <v-navigation-drawer
      v-model="drawer"
      permanent
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
    >
      <v-list>
        <v-list-item
          v-for="item in items"
          :key="item.title"
          :to="item.route"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>

      <template v-slot:append>
        <div class="pa-2">
          <v-btn
            @click="logout()"
            block
          >
            Logout
          </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
</template>

<script>
  import axios from 'axios'
  import store from '@/store'
  
  export default {
    props: ['drawer'],
    data() {
      return {
        items: [
          {
            title: 'Universidades',
            icon: 'mdi-view-dashboard',
            route: '/universidades',
          },
          {
            title: 'Carreras',
            icon: 'mdi-view-dashboard',
            route: '/carreras',
          },
          {
            title: 'Asignaturas',
            icon: 'mdi-view-dashboard',
            route: '/asignaturas',
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
        .catch(err => {
          console.log(err)
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