<template>
  <b-navbar class="is-dark fixed-top" role="navigation" aria-label="main navigation">
    <template slot="brand">
      <b-navbar-item class="logo-container" tag="router-link" :to="{ path: '/' }">
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

<style lang="scss">
$breakpoint: 1215px;

.logo-container  {
  padding: 0;
}

.navbar {
  @media screen and (max-width: $breakpoint) {
    height: 2rem;
  }

  @media screen and (min-width: $breakpoint) {
    height: 4rem;
  }
}

.logo {
  @media screen and (max-width: $breakpoint) {
    height: auto;
    width: 150px;
  }

  @media screen and (min-width: $breakpoint) {
    height: auto;
    width: 240px;
  }
}
</style>
