<template>
  <div>
    <ProjectCard v-for="project in projects" :key="project.id" :project="project" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ProjectCard from "~/components/ProjectCard.vue"
import Project from "~/models/Project";
import axios from "axios";

export default Vue.extend({
  data () {
    return {
      projects: []
    } as {
      projects: Project[];
    }
  },
  asyncData ({ params, error }) {
    return axios.get(`http://localhost:5000/api/projects?pageSize=100`)
    .then((res) => {
      return { projects: res.data as Project[] }
    })
    .catch((e) => {
      console.log(e);
      error({ statusCode: 404, message: 'Failed to fetch projects' })
    })
  },
  components: {
    ProjectCard
  }
});
</script>

<style>
</style>
