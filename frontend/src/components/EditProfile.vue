<template>
  <v-form ref="createLocationForm" class="fixed__form">
    <v-card flat>
          <v-row dense>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="userFields.name"
                label="Name"
                outlined
                dense
              />
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="userFields.email"
                label="Email"
                outlined
                dense
              />
            </v-col>
          </v-row>
          <v-row dense>
            <v-col cols="12" sm="6">
              <v-combobox
                v-model="userFields.title"
                label="Title"
                :items="['Trainee', 'Junior', 'Middle', 'Senior', 'Lead']"
                outlined
                dense
              />
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="userFields.role"
                label="Role"
                outlined
                dense
              />
            </v-col>
          </v-row>
          <v-row dense>
            <v-col cols="12" sm="6">
              <v-select
                v-model="userFields.status"
                :items="['Available','Not Available','In job search', 'In project search']"
                label="Status"
                outlined
                dense
              />
            </v-col>
            <v-col cols="12" sm="6">
              <v-text-field
                v-model="userFields.image"
                label="Image URL"
                outlined
                dense
              />
            </v-col>
          </v-row>
          <v-row dense>
            <v-col cols="12">
              <v-combobox
                v-model="userFields.skills"
                multiple
                :items="userFields.skills"
                label="Skills"
                outlined
                dense
              />
            </v-col>
          </v-row>
          <v-row dense>
            <v-col cols="12">
              <v-textarea
                v-model="userFields.description"
                rows="5"
                label="About me"
                outlined
                dense
              />
            </v-col>
          </v-row>
          <div class="headline mb-4 text-center"> Past projects</div>
          <v-row dense v-for="proj, i in user.projects"  v-bind:key="proj+i">
              <v-text-field
                v-model="userFields.projects[i].name"
                label="Project name"
                outlined
                dense
              />
              <v-text-field
                v-model="userFields.projects[i].startDate"
                label="Start date"
                outlined
                dense
              />
              <v-text-field
                v-model="userFields.projects[i].endDate"
                label="End date"
                outlined
                dense
              />
              <v-text-field
                v-model="userFields.projects[i].role"
                label="Role"
                outlined
                dense
              />
              <v-text-field
                v-model="userFields.projects[i].description"
                label="Description"
                outlined
                dense
              />
          </v-row>
          <v-btn @click="addPastProject" color="primary">Add project</v-btn>
        </v-card>
  </v-form>
</template>
<script>

export default {
  name: 'ViewProfile',
  components: {},
  props: {
    user: Object
  },
  data: () => ({
    userFields: this.user
  }),
  async created () {
    this.userFields = this.user
  },
  methods: {
    addPastProject () {
      this.userFields.projects.push({})
    }
  }
}
</script>

<style lang="css" scoped>
.fixed__button {
  position: sticky;
  min-width: 100%;
  bottom: 16px;
  left: 0;
}
.fixed__form {
  position: relative;
}
.v-tabs-slider {
  margin: auto;
  width: 68.322%;
}

.red__asterisk::after {
  content: '*';
  position: absolute;
  top: -10px;
  right: -6px;
  color: red;
}

.address_combobox >>> label {
  color: #0277bd;
}
</style>
