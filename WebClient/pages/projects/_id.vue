<template>
  <div>
    <ProjectDetails v-if="project" :project="project" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ProjectDetails from "~/components/ProjectDetails.vue";
import Project from "../../models/Project";
import axios from "axios";

export default Vue.extend({
  data() {
    return {
      project: null
    } as {
      project: Project | null
    }
  },
  asyncData ({ params, error }) {
    return axios.get(`http://localhost:5000/api/projects/${params.id}`)
    .then((res) => {
      console.log(res.data)
      return { project: res.data as Project }
    })
    .catch((e) => {
      console.log(e);
      error({ statusCode: 404, message: 'Project not found' })
    })
  },
  components: {
    ProjectDetails
  }
});
</script>

<style>

</style>