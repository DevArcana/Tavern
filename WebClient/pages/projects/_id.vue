<template>
  <div>
    <ProjectDetails v-if="project" :project="project" :comments="comments" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ProjectDetails from "~/components/ProjectDetails.vue";
import Project from "../../models/Project";
import axios from "axios";
import Comment from "../../models/Comment";

export default Vue.extend({
  data() {
    return {
      project: null,
      comments: null
    } as {
      project: Project | null;
      comments: Comment | null;
    }
  },
  async asyncData ({ params }) {
    const project = await axios.get(`http://localhost:5000/api/projects/${params.id}`)
    const comments = await axios.get(`http://localhost:5000/api/comments/${params.id}`)
    
    console.log(comments)

    return { project: project.data as Project, comments: comments.data }
  },
  components: {
    ProjectDetails
  }
});
</script>

<style>

</style>