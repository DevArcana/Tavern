<template>
  <b-navbar class="is-dark fixed-top">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img class="logo"
          src="~/assets/logo.png"
          alt="Tavern Social Platform"
        />
      </b-navbar-item>
    </template>

    <template slot="end">
      <b-navbar-item tag="div">
        <div class="buttons" v-if="isAuthenticated">
          <nuxt-link class="button is-primary" v-if="loggedInUser" to="/">{{ loggedInUser.username }}</nuxt-link>
          <button class="button" @click="logout">Log out</button>
        </div>
        <template v-else>
          <div class="buttons">
            <nuxt-link class="button is-primary" to="/register">Sign up</nuxt-link>
            <nuxt-link class="button" to="/login">Log in</nuxt-link>
          </div>
        </template>
      </b-navbar-item>
    </template>
  </b-navbar>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters } from 'vuex'

export default Vue.extend({
  methods: {
    async logout() {
      await this.$auth.logout();
    }
  },
  computed: {
    ...mapGetters(['isAuthenticated', 'loggedInUser'])
  }
});
</script>

<style>
.navbar {
  height: 5rem;
}

.navbar-item, .navbar-brand, .navbar-burger {
  height: 100%;
}

.logo {
  height: 4rem;
  width: auto;
}
</style>
