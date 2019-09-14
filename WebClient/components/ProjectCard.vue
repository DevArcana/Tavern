<template>
  <div class="card">
    <header class="card-header is-block">
      <div>
        <p class="card-header-title">
          Project title
        </p>
      </div>
      <div>
        <b-taglist class="card-header-title">
          <b-tag type="is-info">Role1</b-tag>
          <b-tag type="is-info">Role2</b-tag>
          <b-tag type="is-info">Role3</b-tag>
          <b-tag type="is-info">Role4</b-tag>
        </b-taglist>
      </div>
    </header>
    <div class="card-content">
      <div class="content">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris.
        <br>
        <time datetime="2016-1-1">11:09 PM - 1 Jan 2016</time>
      </div>
    </div>
    <footer class="card-footer">
      <a href="#" class="card-footer-item">Save</a>
    </footer>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
.card-header-title {
  padding-bottom: 0;
}
</style>