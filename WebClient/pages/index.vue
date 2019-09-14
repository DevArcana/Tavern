<template>
  <div>
    <ProjectCard />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ProjectCard from "~/components/ProjectCard"

export default Vue.extend({
  data () {
    return {
      projects: null
    }
  },
  components: {
    ProjectCard
  }
});
</script>

<style>
</style>
