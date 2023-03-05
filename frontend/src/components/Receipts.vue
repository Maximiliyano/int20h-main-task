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
            label="Filter by skills"
            :items="searchBySkill.length ? peoples.flatMap(v => v.skills).concat(searchBySkill) :peoples.flatMap(v => v.skills)"
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
          :items="filteredPeoples"
          item-key="id"
          class="elevation-1 row-pointer"
          loading-text="Loading... Please wait"
          :search="search"
          @pagination="paginationInfo"
          :custom-filter="searchAnyCase"
        >
          <template #[`item.name`]="{ item }">
            <router-link :to="`/people/${item.id}`">{{ item.name }}</router-link>
          </template>
          <template #[`item.title`]="{ item }">
            <router-link :to="`/people/${item.id}`">{{ item.title }}</router-link>
          </template>
          <template #[`item.role`]="{ item }">
            <router-link :to="`/people/${item.id}`">{{ item.role }}</router-link>
          </template>
          <template #[`item.status`]="{ item }">
            <router-link :to="`/people/${item.id}`">{{  item.status }}</router-link>
          </template>
          <template #[`item.skills`]="{ item }">
            <router-link :to="`/people/${item.id}`">{{ item.skills.length > 7 ? item.skills.slice(0,7).join(', ')+` and ${item.skills.length - 10} more` : item.skills.join(', ')}}</router-link>
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
    peoples: Array
  },
  data: () => ({
    filteredPeoples: null,
    search: '',
    searchBySkill: ''
  }),
  created () {
    this.filteredPeoples = this.peoples
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
      this.filteredPeoples = this.peoples.filter(v => this.searchBySkill.every(skill => v.skills.includes(skill)))
    }
  },
  computed: {
    headers () {
      return [
        { text: 'Name', value: 'name', sortable: true },
        { text: 'Title', value: 'title', sortable: false },
        { text: 'Role', value: 'role', sortable: true },
        { text: 'Status', value: 'status', sortable: true },
        { text: 'Skills', value: 'skills', sortable: false }
      ]
    }
  },
  watch: {
    peoples: function (peoples) {
      this.filteredPeoples = peoples
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
</style>
