<template>
  <v-app dark>
    <v-app-bar :clipped-left="clipped" fixed app>
      <v-spacer></v-spacer>
      <v-btn text @click="$root.$emit('changeTable', 1)">Historic</v-btn>
      <v-btn text @click="$root.$emit('changeTable', 2)">Receipt</v-btn>
    </v-app-bar>
    <v-main>
      <v-container>
        <Nuxt />
      </v-container>
    </v-main>
    <v-footer :absolute="!fixed" app>
      <span>&copy; {{ new Date().getFullYear() }}</span>
    </v-footer>
  </v-app>
</template>

<script>
export default {
  name: 'DefaultLayout',
  data() {
    return {
      clipped: false,
      drawer: false,
      fixed: true,
      miniVariant: false,
      right: true,
      rightDrawer: false,
      title: 'Vuetify.js'
    }
  }
}
</script>
