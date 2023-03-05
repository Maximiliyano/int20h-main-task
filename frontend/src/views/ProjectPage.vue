<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class=" mb-2">
      <v-col
        ><div class="text-h5">Project profile</div></v-col
      >
      <v-col cols="12" sm="6"
        v-if="project.id === project.id"><v-row
          justify-sm="end"
          align="center"
          class="ma-0"
          ><v-btn color="primary" @click="$router.push(`/project/${project.id}/edit`)">Edit</v-btn></v-row
      ></v-col>
    </v-row>
    <ViewProject
    :project="project"
    />
  </v-container>
</template>
<script>
import { getUser, updateUser } from '../firebaseDb'
import ViewProject from '@/components/ViewProject'
export default {
  name: 'PeoplePage',
  components: { ViewProject },
  data: () => ({
    project: {
      id: '1232',
      name: 'Dmytro Romanenko1',
      status: 'Closed',
      skills: ['JS', 'AWS', 'Node', 'CSS'],
      members: [1, 2, 3, 4, 5],
      capacity: '8',
      rating: 4.85
    },
    admin: {
      id: '1232',
      image: 'https://c.disquscdn.com/uploads/users/15337/507/avatar128.jpg?1514741256',
      name: 'Dmytro Romanenko1',
      status: 'Closed',
      description: 'I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats',
      skills: ['JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest'],
      title: 'Junior',
      role: 'Backend dev',
      email: 'Dima.romanenko@fkkf',
      projects: [{ id: '131', name: '1231', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1232', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { id: '131', name: '1234', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { id: '131', name: '1231', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { id: '131', name: '1232', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { id: '131', name: '1234', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }]
    }
  }),
  async created () {
    let project
    const projectEmail = this.$auth.project.email
    this.loading = true
    await getUser(projectEmail)
      .then((doc) => {
        project = doc
      })
      .catch(() => {
        project = { email: projectEmail, products: [] }
        updateUser(project)
      })
    this.loading = false
  },
  methods: {
  }
}
</script>
