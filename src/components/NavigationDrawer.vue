<template>
    <v-navigation-drawer
      :value="drawer"
      v-if="showItems"
      clipped
      app
    >
      <v-list
        class="primary--text"
      >
        <v-list-item two-line>
          <v-list-item-avatar>
            <img :src="avatar">
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-title>Grey Boolean</v-list-item-title>
            <v-list-item-subtitle>Logged in</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>
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
            text
          >
            Cerrar sesión
          </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
</template>

<script>
  import axios from 'axios'
  import store from '@/store'
  import { mapGetters } from 'vuex'

  export default {
    data() {
      return {
        items: [
          {
            title: 'Universidades',
            icon: 'mdi-school',
            route: '/universidades',
          },
          {
            title: 'Carreras',
            icon: 'mdi-view-dashboard',
            route: '/carreras',
          },
          {
            title: 'Asignaturas',
            icon: 'mdi-teach',
            route: '/asignaturas',
          },
        ],
        avatar: localStorage.getItem('avatar')
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
    computed: {
      showItems() {
        return store.getters['auth/isAuthenticated']
      },
      ...mapGetters('shared', {
        drawer: 'drawer'
      }),
    }
  }
</script>