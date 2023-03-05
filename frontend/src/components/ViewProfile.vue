<template>
  <v-card class="mx-auto">
      <v-row> <v-col cols="12" md="6">
                  <v-list-item class="ml-1">
                   <v-list-item-avatar size="100">
                      <img
                        :src="user.image"
                        alt="User avatar"
                      >
                    </v-list-item-avatar>
                    <v-list-item-content>
                      <v-list-item-title class="title" style="margin-top:20px;">{{ $auth.user.name }}</v-list-item-title>
                      <v-list-item-subtitle> {{ user.title + ' ' + user.role }}</v-list-item-subtitle>
                    </v-list-item-content>
                  </v-list-item>
                  <v-card-text>
        <v-chip
          class="ma-1"
          v-for="skill, i in user.skills" v-bind:key="skill+i"
        >{{ skill }}
        </v-chip>
      </v-card-text>
      <div class="ml-2">      <v-card-text class="py-2 title"> About me </v-card-text>
      <v-card-text class="py-2"> {{ user.description }}</v-card-text></div>
      <v-btn class="ml-6 mt-4" @click="$router.push('/resume')" color="primary">CV Page</v-btn>
                  </v-col>
                    <v-col cols="12" md="6">
                      <div class="title text-center mb-2"> Past projects </div>
                      <v-timeline
            class="mx-6">
      <v-timeline-item
        v-for="(year, i) in user.projects"
        :key="i"
      >
        <template v-slot:opposite>
          <span
            :class="`headline font-weight-bold`"
            v-text="year.year"
          ></span>
        </template>
        <div class="py-4">
          <h2 :class="`headline font-weight-light mb-2`">
            {{ year.name }}
          </h2>
          <sub class="h6">{{ `from ${year.startDate} - till ${year.endDate || 'now'}` }}</sub>
          <div class="mt-2">
            {{ year.description}}
          </div>
        </div>
      </v-timeline-item>
    </v-timeline>
                  </v-col>
    </v-row>
  </v-card>
</template>
<script>
export default {
  name: 'ViewProfile',
  components: {},
  props: {
    user: Object
  },
  data: () => ({

  }),
  created () {
  },
  methods: {

  }
}
</script>
