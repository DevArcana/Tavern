<template>
  <b-navbar :type="'is-dark'" :fixed-top="true">
    <template slot="brand">
      <b-navbar-item tag="router-link" :to="{ path: '/' }">
        <img
          src="@/assets/logo.png"
          alt="Tavern"
        >
      </b-navbar-item>
    </template>

    <template slot="end">
      <NavbarUserInfo />
      <NavbarLogin />
    </template>
  </b-navbar>
</template>

<script lang="ts">
import Vue from 'vue'
import NavbarLogin from '@/components/NavbarLogin.vue'
import NavbarUserInfo from '@/components/NavbarUserInfo.vue'

export default Vue.extend({
  components: {
    NavbarLogin,
    NavbarUserInfo
  }
})
</script>
<style>

</style>
