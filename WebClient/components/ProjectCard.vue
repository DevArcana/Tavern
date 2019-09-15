<template>
  <div class="card">
    <header class="card-header is-block">
      <div>
        <p class="card-header-title project-title">
          {{ project.title }}
        </p>
      </div>
      <div>
      <b-taglist class="card-header-title roles-list">
        <b-tag v-for="role in project.functions" :key="role.id" type="is-info">{{role.name}}</b-tag>
      </b-taglist>
      </div>
    </header>
    <div class="card-content">
      <div class="content">
        <div>
          {{ project.description }}
        </div>
        <div :class="{veil: project.description.length > 140}"></div>
      </div>
    </div>
    <footer class="card-footer">
      <nuxt-link class="card-footer-item" :to="'/projects/' + project.id">Details</nuxt-link>
    </footer>
  </div>
</template>

<script lang="ts">
import Vue, { PropOptions } from "vue";
import Project from "~/models/Project";

export default Vue.extend({
  props: {
    project: {
      type: Object,
      required: true
    } as PropOptions<Project>
  },
})
</script>

<style scoped>
.card {
  margin-top: 0.75rem;
  margin-bottom: 0.75rem;
  margin-left: 1.5rem;
  margin-right: 1.5rem;
  border-radius: 4px;
}
.card-header-title {
  padding-bottom: 0;
}
.project-title {
  font-size: 1.25rem;
}
.roles-list {
  padding-top: 0.5rem;
  font-weight: 500;
}
.content {
  max-height: 120px;
  position: relative;
  overflow: hidden;
}
.content .veil { 
  position: absolute; 
  bottom: 0; 
  left: 0;
  width: 100%; 
  text-align: center; 
  margin: 0; padding: 30px 0; 
	
  /* "transparent" only works here because == rgba(0,0,0,0) */
  background-image: linear-gradient(to bottom, transparent, white);
}

.card-content {
  padding-bottom: 0;
}
</style>