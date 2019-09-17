<template>
  <b-dropdown position="is-bottom-left" aria-role="menu">
    <a slot="trigger" class="navbar-item" role="button">
      <span>Welcome, User</span>
      <b-icon icon="menu-down" />
    </a>

    <b-dropdown-item custom aria-role="menuitem">
      Logged as <b>Rafael Beraldo</b>
    </b-dropdown-item>

    <hr class="dropdown-divider">

    <b-dropdown-item has-link aria-role="menuitem">
      <nuxt-link to="/">
        <b-icon icon="file-document" />
        Create new project
      </nuxt-link>
    </b-dropdown-item>

    <b-dropdown-item aria-role="menuitem">
      <nuxt-link to="/">
        <b-icon icon="folder-open" />
        My projects
      </nuxt-link>
    </b-dropdown-item>

    <hr class="dropdown-divider" aria-role="menuitem">

    <b-dropdown-item has-link aria-role="menuitem">
      <nuxt-link to="/">
        <b-icon icon="settings" />
        Settings
      </nuxt-link>
    </b-dropdown-item>

    <b-dropdown-item has-link aria-role="menuitem">
      <nuxt-link to="/">
        <b-icon icon="logout" />
        Logout
      </nuxt-link>
    </b-dropdown-item>
  </b-dropdown>
</template>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({

})
</script>

<style>

</style>
