<template>
  <v-container fluid>
    <v-card>
      <v-row>
      <v-col cols="12" sm="7" md="8" lg="9" class="pb-sm-3 pb-1">
        <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Search"
        outlined
        clearable
        hide-details
        class="px-2"
      />
      </v-col>
        <v-col cols="12" sm="5" md="4" lg="3" class="pt-sm-3 pt-1">
          <v-combobox
            v-model="searchBySkill"
            label="Filter by technologies"
            :items="searchBySkill.length ? projects.flatMap(v => v.skills).concat(searchBySkill) :projects.flatMap(v => v.skills)"
            outlined
            multiple
            hide-details
            class="px-2"
            @change="filterBySkill()"
          />
        </v-col>
      </v-row>
    </v-card>
    <v-row>
      <v-col cols="12" fluid>
        <v-data-table
          :headers="headers"
          :items="filteredProjects"
          item-key="id"
          class="elevation-1 row-pointer"
          loading-text="Loading... Please wait"
          :search="search"
          @pagination="paginationInfo"
          :custom-filter="searchAnyCase"
        >
          <template #[`item.name`]="{ item }">
            <router-link :to="`/project/${item.id}`">{{ item.name }}</router-link>
          </template>
          <template #[`item.status`]="{ item }">
            <router-link :to="`/project/${item.id}`">{{ item.status }}</router-link>
          </template>
          <template #[`item.team`]="{ item }">
            <router-link :to="`/project/${item.id}`">{{ item.members.length + '/' + item.capacity }}</router-link>
          </template>
          <template #[`item.skills`]="{ item }">
            <router-link :to="`/project/${item.id}`">{{ item.skills.length > 7 ? item.skills.slice(0,7).join(', ')+` and ${item.skills.length - 10} more` : item.skills.join(', ')}}</router-link>
          </template>
          <template #[`item.rating`]="{ item }">
            <router-link :to="`/project/${item.id}`">      <v-rating
              class="pa-0 ml-n1"
        v-model="item.rating"
        density="compact"
        color="blue"
        background-color="blue"
        readonly
        half-increments
      ></v-rating></router-link>
          </template>
        </v-data-table>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  name: 'Card',
  components: {},
  props: {
    projects: Array
  },
  data: () => ({
    filteredProjects: null,
    search: '',
    searchBySkill: ''
  }),
  created () {
    this.filteredProjects = this.projects
  },
  methods: {
    paginationInfo (pagination) {
      this.itemsCount = pagination.itemsLength
    },
    searchAnyCase (value, search) {
      return value != null &&
        search != null &&
        typeof value === 'string' &&
        value.toString().toLocaleLowerCase().indexOf(search.toLocaleLowerCase()) !== -1
    },
    filterBySkill () {
      this.filteredProjects = this.projects.filter(v => this.searchBySkill.every(skill => v.skills.includes(skill)))
    }
  },
  computed: {
    headers () {
      return [
        { text: 'Name', value: 'name', sortable: true },
        { text: 'Status', value: 'status', sortable: false },
        { text: 'Members', value: 'team', sortable: true },
        { text: 'Technologies', value: 'skills', sortable: false },
        { text: 'Rating', value: 'rating', sortable: true }
      ]
    }
  },
  watch: {
    projects: function (projects) {
      this.filteredProjects = projects
    }
  }
}
</script>
<style lang="css" scoped>
.row-pointer >>> tbody tr :hover {
  cursor: pointer;
}

.v-input >>> .v-select__selections {
  flex-wrap: nowrap;
}

.row-pointer >>> table tbody tr td {
  padding: 0;
}

.row-pointer >>> table tbody tr td *{
  padding: 0 16px;
}

.row-pointer >>> a {
  display: grid;
  width: 100%;
  height: 100%;
  align-items: center;
  text-decoration: none;
  color: #000;
  padding: 0 16px;
}

.v-rating >>> .v-icon {
  padding: 0;
}
</style>
