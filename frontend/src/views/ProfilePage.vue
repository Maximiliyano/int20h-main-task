<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class=" mb-2">
      <v-col
        ><div class="text-h5">User profile</div></v-col
      >
      <v-col cols="12" sm="6"
        v-if="user.id === user.id"><v-row
          justify-sm="end"
          align="center"
          class="ma-0"
          ><v-btn color="primary" @click="$router.push(`/user/${user.id}/edit`)">Edit<v-icon>mdi-pencil</v-icon></v-btn></v-row
      ></v-col>
    </v-row>
    <ViewProfile
    :user="user"
    />
  </v-container>
</template>
<script>
import { getUser, updateUser } from '../firebaseDb'
import ViewProfile from '@/components/ViewProfile'
export default {
  name: 'PeoplePage',
  components: { ViewProfile },
  data: () => ({
    user: {
      id: '1232',
      image: 'https://c.disquscdn.com/uploads/users/15337/507/avatar128.jpg?1514741256',
      name: 'Dmytro Romanenko1',
      status: 'Closed',
      description: 'I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats I like dogs and cats',
      skills: ['JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest', 'JS', 'AWS', 'Node', 'CSS', 'TypeScript', 'Jest'],
      title: 'Junior',
      role: 'Backend dev',
      email: 'Dima.romanenko@fkkf',
      projects: [{ name: '1231', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1232', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1234', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1231', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1232', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }, { name: '1234', startDate: '21/11/2015', endDate: '22/11/2020', role: 'Junior backend dev', description: 'A small project about something' }]
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
    let user
    const userEmail = this.$auth.user.email
    this.loading = true
    await getUser(userEmail)
      .then((doc) => {
        user = doc
      })
      .catch(() => {
        user = { email: userEmail, products: [] }
        updateUser(user)
      })
    this.loading = false
  },
  methods: {
  }
}
</script>
