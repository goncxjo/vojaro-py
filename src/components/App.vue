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
