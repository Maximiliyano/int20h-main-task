<template>
  <div class="row main-content">
    <div
      id="resumeViewContainer"
      class="col s12 valign-wrapper"
      style="background: #7a8599"
      :style="{ 'overflow-y': resumeViewScrollable ? 'auto' : 'hidden' }"
    >
      <ResumePreview
        style="margin-top: 18px"
        scaleX="0.9"
        scaleY="0.9"
        @fullModeActivated="resumeViewScrollable = true"
        @onTemplateUpdate="onDirty()"
      />
    </div>
  </div>
</template>
<script>
import InputFormSchema from '../model/formSchema.json'
import ResumePreview from '../components/core/ResumePreview'
import STORAGE_SERVICE from '../services/persistence'
import { orderBy } from 'lodash'

export default {
  components: {
    ResumePreview
  },
  name: 'viewResume',
  data () {
    return {
      formSchema: {},
      isFormDirty: false,
      resumeViewScrollable: true
    }
  },
  computed: {
    resumeId () {
      return (this.$route.params || {}).id
    },
    sectionList: {
      get () {
        return this.formSchema.sections
      },
      set (val) {
        this.formSchema.sections = val
        const schemaOrder = []
        for (let index = 0; index < this.formSchema.sections.length; index++) {
          schemaOrder[this.formSchema.sections[index].id] = index
        }
        STORAGE_SERVICE.saveSchema(schemaOrder)
      }
    }
  },
  mounted () {
    document.body.style.overflowY = 'hidden'
    this.formSchema = InputFormSchema
    if (this.$route.params.id) {
      const formData = STORAGE_SERVICE.getResumeById(this.$route.params.id)
      if (!formData) {
        this.$router.push('/404')
        return
      }
      this.$store.commit('setStoreValues', formData)
      const schemaOrder = STORAGE_SERVICE.getSchemaOrder()
      this.formSchema.sections.forEach((s) => {
        s.seq = schemaOrder ? schemaOrder[s.id] : 0
        s.fields.forEach((f) => {
          f.value = formData[f.id]
        })
      })
      this.formSchema.sections = orderBy(this.formSchema.sections, ['seq'])
    } else {
      this.$store.commit('clearStoreValues')
      this.formSchema.sections.forEach((s) => {
        s.fields.forEach((f) => {
          f.value = ''
        })
      })
    }
  },
  beforeDestroy () {
    document.body.style.overflowY = 'auto'
  },
  methods: {
    save () {
      STORAGE_SERVICE.saveResume(this.$store.state.resume)
      this.isFormDirty = false
      if (!this.resumeId) {
        this.$store.commit('clearStoreValues')
        this.$router.push('/')
      }
    },
    deleteResume () {
      if (confirm('Are you sure?')) {
        STORAGE_SERVICE.deleteResume(this.resumeId)
        this.$router.push('/')
      }
    },
    onDirty () {
      this.isFormDirty = true
    }
  }
}
</script>
<style scoped>
.row {
  margin-bottom: 0.85rem;
}
.col {
  margin-bottom: 0.25rem;
}
.main-content > .col.m6 {
  max-height: 95vh;
  overflow-y: auto;
}
h6 {
  font-weight: 600;
  cursor: move;
}
.pullup {
  margin-top: 0.3rem;
}
.floating-button {
  position: absolute;
  top: 6rem;
  font-weight: 600;
}
.float-bottom {
  position: absolute;
  bottom: 1.5rem;
  left: 45%;
}
body {
  overflow-y: hidden;
}
.item:active {
  cursor: move;
  padding: 0.45em 0.5rem;
  border-radius: 8px;
  background: #f7f7f7;
  transition-delay: 0.1s;
  transition-duration: 0.25s;
  box-shadow: 0 8px 17px 2px rgba(0, 0, 0, 0.14),
    0 3px 14px 2px rgba(0, 0, 0, 0.12), 0 5px 5px -3px rgba(0, 0, 0, 0.2);
}
.no-drag:hover {
  cursor: default;
}
</style>
