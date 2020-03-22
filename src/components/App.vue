<template>
  <v-app>
    <NavBar />
    <NavigationDrawer />
    <v-content
      class="background--gray"
    >
      <v-container>
        <router-view/>
      </v-container>
    </v-content>
    <Footer />
  </v-app>
</template>

<script>
  import axios from 'axios'
  import store from '@/store'
  import NavBar from '@/components/NavBar'
  import NavigationDrawer from '@/components/NavigationDrawer'
  import Footer from '@/components/Footer'

  export default {
    name: 'App',
    components: {
      NavBar,
      NavigationDrawer,
      Footer,
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
  .background--gray
    background-color: #F9F9F9
    height: 100%
</style>
