<template>
  <div class="feed">
    <div class="columns">
      <div class="column is-8 is-offset-2">
        <ProjectCard v-for="project in projects" :key="project.id" :project="project" />
      </div>
    </div>
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
      {id: 1, title: "Test", description: `
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

<style scoped>
.feed {
  padding-top: 2rem;
}
</style>
