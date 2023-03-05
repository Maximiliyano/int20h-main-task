<template>
  <v-container fluid>
    <v-row align="center" justify="space-between" class="px-4 mb-1">
      <v-col class="pb-sm-3 pb-0 px-sm-2 px-2"
        ><div class="text-h5 mt-3">Projects</div></v-col
      >
      <v-col cols="12" sm="9" class="pt-sm-3 pt-0"
        ><v-row
          justify="space-between"
          justify-sm="end"
          align="center"
          class="ma-0"
          ><v-switch
            hide-details
            class="mr-4 mt-sm-0 mt-2 pt-0"
            inset
            v-model="showOpenOnly"
            label="Show open only"
          ></v-switch
          ></v-row
      ></v-col>
    </v-row>
    <Card
      :projects="projects"
    />
  </v-container>
</template>
<script>
import { getUser, updateUser } from '../firebaseDb'
import Card from '@/components/Card'
export default {
  name: 'ProductsPage',
  components: { Card },
  data: () => ({
    showByCategories: false,
    showOpenOnly: false,
    products: [],
    userProducts: [],
    loading: false,
    cards: [],
    projects: [{
      id: '1231',
      name: 'Dmytro Romanenko',
      status: 'Closed',
      skills: ['JS', 'AWS', 'Node', 'CSS', 'JS1', 'AWS1', 'Node1', 'CSS1', 'JS2', 'AWS2', 'Node2', 'CSS2', 'JS6', 'AWS6', 'Node6', 'CSS6', 'JS16', 'AWS16', 'Node16', 'CSS16', 'JS26', 'AWS26', 'Node26', 'CSS26', 'Node656', 'CSS69', 'JS169', 'AWS169', 'Node169', 'CSS169', 'JS269', 'AWS269', 'Node269', 'CSS269'],
      members: [1, 2, 3, 4, 5],
      capacity: '8',
      rating: 4.85
    },
    {
      id: '1232',
      name: 'Dmytro Romanenko1',
      status: 'Closed',
      skills: ['JS', 'AWS', 'Node', 'CSS'],
      members: [1, 2, 3, 4, 5],
      capacity: '8',
      rating: 4.85
    },
    {
      id: '1233',
      name: 'Dmytro Romanenko2',
      status: 'Open',
      skills: ['JS', 'AWS', 'Node', 'CSS'],
      members: [1, 2, 3, 4, 5],
      capacity: '8',
      rating: 4.2
    },
    {
      id: '1234',
      name: 'Dmytro Romanenko43',
      status: 'Closed',
      skills: ['JS', 'AWS', 'Node', 'CSS', 'HTML'],
      members: [1, 2, 3, 4, 5],
      capacity: '6',
      rating: 1.6
    }]
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
    async updateUser () {
      const userEmail = this.$auth.user.email
      const userProducts = this.products
        .filter((product) => product.count !== '0')
        .map((product) => {
          return {
            name: product.name,
            countType: product.countType,
            count: product.count
          }
        })
      await updateUser({
        email: userEmail,
        products: userProducts
      })
    }
  },
  watch: {
    showOpenOnly: function (showOpenOnly) {
      if (showOpenOnly) {
        this.cards = this.projects
        this.projects = this.projects.filter(
          (project) => project.status === 'Open'
        )
      } else {
        this.projects = this.cards
      }
    }
  }
}
</script>
