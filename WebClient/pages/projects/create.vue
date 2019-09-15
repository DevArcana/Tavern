<template>
  <div class="box">
    <Notification :message="error" v-if="error" />
    <form action="" method="post" @submit.prevent="submit">
      <b-field label="Title">
        <b-input required validation-message="This field is required" v-model="title"></b-input>
      </b-field>

      <b-field label="Category">
        <b-autocomplete
          rounded
          :data="availableCategories"
          placeholder="Select the category"
          required
          :keep-first="true"
          :open-on-focus="true"
          field="name"
          @typing="getFilteredCategories"
          @select="option => selectedCategory = option"
          icon="magnify">
          <template slot="empty">No results found</template>
        </b-autocomplete>
      </b-field>
      
      <b-field label="Open positions">
        <b-taginput
          v-model="selectedFunctions"
          :data="availableFunctions"
          autocomplete
          :allow-new="false"
          field="name"
          icon="label"
          placeholder="Search for role types"
          @typing="getFilteredFunctions"
          >
        </b-taginput>
      </b-field>

      <b-field label="Description">
        <b-input type="textarea"
          minlength="1"
          maxlength="2048"
          required
          placeholder="Project description"
          v-model="description">
        </b-input>
      </b-field>

      <b-field>
        <button type="submit" class="button is-primary is-fullwidth">Create</button>
      </b-field>
    </form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Notification from "~/components/Notification.vue"
import Role from "../../models/Role";
import Category from "../../models/Category";

export default Vue.extend({
  data() {
    return {
      error: null,
      availableFunctions: [],
      selectedFunctions: [],
      functions: [{id: 1, name: "Programmer"}, {id: 2, name: "Graphics Designer"}, {id: 3, name: "Garbage Collector"}, {id: 4, name: "Angry Person"}],
      categories: [{id: 1, name: "Gamedev"}, {id: 2, name: "Other"}, {id: 3, name: "Mechanical"}],
      availableCategories: [{id: 1, name: "Gamedev"}, {id: 2, name: "Other"}, {id: 3, name: "Mechanical"}],
      selectedCategoryName: "",
      selectedCategory: null,
      title: "",
      description: ""
    } as {
      error: string | null;
      availableFunctions: Role[];
      selectedFunctions: Role[];
      functions: Role[];
      categories: Category[];
      availableCategories: Category[];
      selectedCategoryName: string;
      selectedCategory: Category | null;
      title: string;
      description: string;
    }
  },
  methods: {
    async submit() {
      console.log(this)
      this.error = "Hello";
    },

    getFilteredFunctions(text: string) {
        this.availableFunctions = this.functions.filter((option) => {
        return option.name
        .toString()
        .toLowerCase()
        .indexOf(text.toLowerCase()) >= 0
      })
    },

    getFilteredCategories(text: string) {
        this.availableCategories = this.categories.filter((option) => {
        return option.name
        .toString()
        .toLowerCase()
        .indexOf(text.toLowerCase()) >= 0
      })
    }
  },
  components: {
    Notification
  }
});
</script>

<style>
</style>