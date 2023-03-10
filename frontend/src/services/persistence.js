import { v4 as uuidv4 } from 'uuid'

const STORAGE_SERVICE = {
  getResumeList () {
    return JSON.parse(localStorage.getItem('resumeList'))
  },
  getResumeById (id) {
    const resumeList = this.getResumeList()
    return resumeList.find((x) => x.id === id)
  },
  duplicateResume (resume) {
    const resumeList = this.getResumeList() || []
    resume.id = uuidv4()
    resume.created_at = new Date()
    delete resume.updated_at
    resumeList.push(resume)
    localStorage.setItem('resumeList', JSON.stringify(resumeList))
  },
  saveResume (resume) {
    const resumeList = this.getResumeList() || []
    if (resume.id && resumeList.length > 0) {
      resume.updated_at = new Date()
      const index = resumeList.findIndex((x) => x.id === resume.id)
      resumeList[index] = resume
    } else {
      resume.id = uuidv4()
      resume.resume_title = resume.job_title // Name resume by title
      resume.created_at = new Date()
      resumeList.push(resume)
    }
    localStorage.setItem('resumeList', JSON.stringify(resumeList))
  },
  deleteResume (resumeId) {
    let resumeList = this.getResumeList()
    resumeList = resumeList.filter((x) => x.id !== resumeId)
    localStorage.setItem('resumeList', JSON.stringify(resumeList))
  },
  // Theme
  getTheme () {
    return JSON.parse(localStorage.getItem('theme'))
  },
  saveTheme (theme) {
    localStorage.setItem('theme', JSON.stringify(theme))
  },
  // Form schema
  getSchemaOrder () {
    return JSON.parse(localStorage.getItem('schemaOrder'))
  },
  saveSchema (schema) {
    localStorage.setItem('schemaOrder', JSON.stringify(schema))
  }
}
export default STORAGE_SERVICE
