<template>
  <div>
    <div
      class="title grey--text"
    >
      {{ titulo }}
    </div>
    <v-card>
      <v-card-text
        class="py-0"
      >
          <slot name="form"></slot>
      </v-card-text>

      <v-card-actions
        class="pa-4 pt-0"
      >
        <v-spacer />
        <slot name="btn"></slot>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script>
  export default {
    props: ['titulo'],
    data() {
      return {}
    }
  }
</script>

<style lang="sass">
  
</style>