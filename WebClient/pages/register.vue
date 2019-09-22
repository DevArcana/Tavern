<template>
  <div class="box">
    <form action="" method="post" @submit.prevent="validate">
      <b-field
        label="Username"
        :type="{'is-danger': errors.has('username')}"
        :message="errors.first('username')"
      >
        <b-input v-model="username" v-validate="'required|alpha'" type="text" name="username" />
      </b-field>

      <b-field
        label="Email"
        :type="{'is-danger': errors.has('email')}"
        :message="errors.first('email')"
      >
        <b-input v-model="email" v-validate="'required|email'" type="email" name="email" />
      </b-field>

      <b-field
        label="Password"
        :type="{'is-danger': errors.has('password')}"
        :message="errors.first('password')"
      >
        <b-input v-model="password" v-validate="'required|min:8'" type="password" name="password" />
      </b-field>

      <b-field
        label="Confirm password"
        :type="{'is-danger': errors.has('confirm-password')}"
        :message="[{
          'The confirm password field is required' : errors.firstByRule('confirm-password', 'required'),
          'The confirm password is not valid' : errors.firstByRule('confirm-password', 'is')
        }]"
      >
        <b-input
          v-model="confirmPassword"
          v-validate="{ required: true, is: password }"
          type="password"
          name="confirm-password"
        />
      </b-field>

      <b-field
        label=""
        :type="{'is-danger': errors.has('flag-terms')}"
        :message="{'Please check this box to proceed' : errors.firstByRule('flag-terms', 'required')}"
      >
        <b-checkbox v-model="agreedToTerms" v-validate="'required:false'" name="flag-terms">
          I agree to the terms and conditions
        </b-checkbox>
      </b-field>

      <button type="submit" class="button is-primary">
        Submit
      </button>
    </form>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'

class Data {
  username: string = '';
  email: string = '';
  password: string = '';
  confirmPassword: string = '';
  agreedToTerms: boolean = false;
}

export default Vue.extend({
  data () {
    return new Data()
  },
  methods: {
    async validate () {
      // @ts-ignore
      const result = await this.$validator.validateAll()

      if (result) {
        await this.register()
      }
    },

    async register () {
      try {
        await this.$axios.post('register', {
          username: this.username,
          email: this.email,
          password: this.password
        })

        // @ts-ignore
        await this.$auth.loginWith('local', {
          data: {
            username: this.username,
            password: this.password
          }
        })

        this.$router.push('/')
      } catch (e) {
        // Handle errors somehow
      }
    }
  }
})
</script>

<style>

</style>
