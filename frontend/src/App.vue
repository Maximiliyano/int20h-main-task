<template>
  <v-app>
    <v-app-bar app clipped-left color="primary" dark>
      <v-app-bar-nav-icon
        v-if="$auth.isAuthenticated"
        @click="drawer = !drawer"
      />
      <v-img
        alt="Levelup"
        class="shrink mr-2"
        contain
        src=".././public/logo.svg"
        transition="scale-transition"
        width="40"
      />
      <h3 class="ml-100 my-0">Levelup</h3>
      <v-spacer />
      <template v-if="$auth.isAuthenticated">
        <v-menu right bottom>
          <template v-slot:activator="{ on }">
            <v-btn icon v-on="on" class="mx-auto">
              <v-avatar>
                <img :src="$auth.user.picture" alt="User Picture" />
              </v-avatar>
            </v-btn>
          </template>
          <v-list class="text-center">
            <v-list-item>
              <v-avatar class="mx-auto">
                <img :src="$auth.user.picture" alt="User Picture" />
              </v-avatar>
            </v-list-item>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title>
                  {{ $auth.user.name }}
                </v-list-item-title>
                <v-list-item-subtitle>{{
                  $auth.user.email
                }}</v-list-item-subtitle>
              </v-list-item-content>
            </v-list-item>
            <v-list-item>
              <v-btn block color="primary" @click="$auth.logout">
                Log Out
                <v-icon class="ml-1">mdi-logout</v-icon>
              </v-btn>
            </v-list-item>
          </v-list>
        </v-menu>
      </template>
    </v-app-bar>

    <v-navigation-drawer
      v-if="$auth.isAuthenticated"
      v-model="drawer"
      app
      clipped
      color="grey lighten-4"
      width="auto"
    >
      <v-list dense nav>
        <v-list-item :to="`/user`">
          <v-list-item-action>
            <v-icon>mdi-account</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title> My profile </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/people">
          <v-list-item-action>
            <v-icon>mdi-account-group</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title> People </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/project">
          <v-list-item-action>
            <v-icon>mdi-folder-multiple</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Projects</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-main>
      <router-view />
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'App',

  components: {},
  data: () => ({
    drawer: true
  })
}
</script>
