<template>
    <v-footer
      inset
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