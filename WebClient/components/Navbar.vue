<template>
  <b-navbar type="is-dark" :fixed-top="true">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img
          src="@/assets/logo.png"
          alt="Tavern"
        >
      </b-navbar-item>
    </template>

    <template slot="end">
      <client-only>
        <NavbarUserInfo v-if="isAuthenticated" />
        <template v-else>
          <nuxt-link class="navbar-item" to="/register">
            Sign up
          </nuxt-link>
          <NavbarLogin />
        </template>

        <template slot="placeholder">
          <b-navbar-item tag="div">
            <b-button loading class="is-dark">
              Loading
            </b-button>
          </b-navbar-item>
        </template>
      </client-only>
    </template>
  </b-navbar>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapGetters } from 'vuex'
import NavbarLogin from '@/components/NavbarLogin.vue'
import NavbarUserInfo from '@/components/NavbarUserInfo.vue'

export default Vue.extend({
  components: {
    NavbarLogin,
    NavbarUserInfo
  },
  computed: {
    ...mapGetters(['isAuthenticated'])
  }
})
</script>
