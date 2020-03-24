<template>
    <v-footer
      color="primary"
      dark
      app
    >
      <span>&copy; 2020</span>
    </v-footer>
</template>

<script>
export default {
    computed: {
      year() {
          return Date.now().year
      }
    } 
}
</script>