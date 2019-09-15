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
        <b-dropdown v-if="isAuthenticated"
          v-model="navigation"
          :change="navigate()"
          position="is-bottom-left"
          aria-role="menu">
          <button class="button is-light" slot="trigger">
            <span>Menu</span>
            <b-icon icon="menu-down"></b-icon>
          </button>

          <b-dropdown-item custom aria-role="menuitem">
              Logged as <b>{{ loggedInUser.username }}</b>
          </b-dropdown-item>
          <hr class="dropdown-divider">
          <b-dropdown-item value="createProject">
              Create new project
          </b-dropdown-item>
          <hr class="dropdown-divider">
          <b-dropdown-item value="settings">
              <b-icon icon="settings"></b-icon>
              Settings
          </b-dropdown-item>
          <b-dropdown-item value="logout" aria-role="menuitem">
              <b-icon icon="logout"></b-icon>
              Logout
          </b-dropdown-item>
        </b-dropdown>
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
  data () {
    return {
      navigation: ""
    } as {
      navigation: string
    }
  },
  methods: {
    navigate() {
      if (!this.navigation || this.navigation === "") {
        return;
      } else if (this.navigation === "logout") {
        this.$auth.logout();
        this.$router.push("/");
      } else if(this.navigation === "createProject") {
        this.$router.push("/projects/create");
      }
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
