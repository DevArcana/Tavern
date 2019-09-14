<template>
  <div>
    <ProjectCard v-for="project in projects" :key="project.id" :project="project" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ProjectCard from "~/components/ProjectCard.vue"
import Project from "~/models/Project";

export default Vue.extend({
  data () {
    return {
      projects: [
        {id: 1, title: "Test", description: `
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      Tesasdasdasdsadsadsadsadasdsadasdasdasdasdsadasdasdasdasdsadsadsaadsadsadsadasdsadsadasdsadsadsadsadasdsadsadsadsadsadsadasdsadt
      `},
      {id: 2, title: "Test", description: `
      Short description
      `}
      ]
    } as {
      projects: Project[];
    }
  },
  components: {
    ProjectCard
  }
});
</script>

<style>
</style>
