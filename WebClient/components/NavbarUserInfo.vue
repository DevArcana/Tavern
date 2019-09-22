<template>
  <b-dropdown position="is-bottom-left" aria-role="menu">
    <a slot="trigger" class="navbar-item" role="button">
      <span>Welcome, {{ loggedInUser.username }}</span>
      <b-icon icon="menu-down" />
    </a>

    <b-dropdown-item custom aria-role="menuitem">
      Logged in as <b>{{ loggedInUser.username }}</b>
    </b-dropdown-item>

    <hr class="dropdown-divider">

    <b-dropdown-item has-link aria-role="menuitem">
      <nuxt-link to="/createnewproject">
        <b-icon icon="link" />
        Create new project
      </nuxt-link>
    </b-dropdown-item>

    <hr class="dropdown-divider" aria-role="menuitem">

    <b-dropdown-item has-link aria-role="menuitem">
      <nuxt-link to="/settings">
        <b-icon icon="settings" />
        Settings
      </nuxt-link>
    </b-dropdown-item>

    <b-dropdown-item aria-role="menuitem" @click="logout">
      <b-icon icon="logout" />
      Logout
    </b-dropdown-item>
  </b-dropdown>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapGetters } from 'vuex'

export default Vue.extend({
  methods: {
    async logout () {
      // @ts-ignore
      await this.$auth.logout()
    }
  },
  computed: {
    ...mapGetters(['loggedInUser'])
  }
})
</script>

<style>

</style>
