<template>
  <div>
    <Navbar />
    <div class="columns">
      <div class="column is-8 is-offset-2">
        <div class="content-container">
          <nuxt />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Navbar from "~/components/Navbar";

export default {
  components: {
    Navbar
  }
};
</script>

<style>
.content-container {
  margin-top: 1rem;
}
</style>
