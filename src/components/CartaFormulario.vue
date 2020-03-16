<template>
  <v-card>
    <v-toolbar
      color="primary"
      dark
      dense
      flat
    >
      <v-toolbar-title>{{ titulo }}</v-toolbar-title>
    </v-toolbar>

    <v-card-text
      class="pb-0"
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
</template>

<script>
  export default {
    props: ['titulo'],
    data() {
      return {}
    }
  }
</script>