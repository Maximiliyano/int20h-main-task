<template>
  <v-card class="mx-auto">
      <v-row> <v-col cols="12" md="6">
                  <v-list-item class="ml-1">
                   <v-list-item-avatar size="100">
                      <img
                        src=''
                        alt="Project avatar"
                      >
                    </v-list-item-avatar>
                    <v-list-item-content>
                      <v-list-item-title class="title" style="margin-top:20px;">{{ $auth.project.id }}</v-list-item-title>
                      <v-list-item-subtitle> {{ project.capacity + '/' + project.members.length }}</v-list-item-subtitle>
                    </v-list-item-content>
                  </v-list-item>
                  <v-card-text>
        <v-chip
          class="ma-1"
          v-for="skill, i in project.skills" v-bind:key="skill+i"
        >{{ skill }}
        </v-chip>
      </v-card-text>
      <div class="ml-2">      <v-card-text class="py-2 title"> About me </v-card-text>
      <v-card-text class="py-2"> {{ project.description }}</v-card-text></div>
      <v-btn class="ml-6 mt-4" @click="$router.push('/resume')" color="primary">CV Page</v-btn>
                  </v-col>
                    <v-col cols="12" md="6">
                      <div class="title text-center mb-2"> Past projects </div>
                  </v-col>
    </v-row>
  </v-card>
</template>
<script>
export default {
  name: 'ViewProject',
  components: {},
  props: {
    project: Object
  },
  data: () => ({
  }),
  created () {
  },
  methods: {

  }
}
</script>
