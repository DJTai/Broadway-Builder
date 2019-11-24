<template>
  <div class="PublishSite">
    <div>
      <div class="column">
        <label class="label">Publish Site</label>

        <div class="field">
          <label class="label">Application Title</label>
          <div class="control">
            <input class="input" v-model="appDetails.title">
          </div>
        </div>

        <div class="field">
          <label class="label">Description</label>
          <div class="control">
            <textarea v-model="appDetails.description" class="textarea"></textarea>
          </div>
        </div>

        <div class="field">
          <label class="label">App Logo URL</label>
          <div class="large-12 medium-12 small-12 cell">
            <input class="input" v-model="appDetails.logoUrl">
          </div>
        </div>

        <div class="field">
          <label class="label">API Key</label>
          <div class="large-12 medium-12 small-12 cell">
            <input class="input" v-model="appDetails.key" placeholder="Enter A New API Key...">
          </div>
        </div>

        <div class="field">
          <label class="label">Under Maintenance</label>
          <div class="control">
            <label class="radio">
              <input type="radio" value="true" v-model="appDetails.underMaintenance">
              Yes
            </label>
            <label class="radio">
              <input type="radio" value="false" v-model="appDetails.underMaintenance">
              No
            </label>
          </div>
        </div>

        <div class="field is-grouped">
          <div class="control">
            <button v-on:click="publishApp" class="button is-link">Submit</button>
          </div>
          <div class="control">
            <button v-on:click="cancelPublish" class="button is-text">Cancel</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "PublishSite",
  data() {
    return {
      appDetails: {
        key: "",
        title: "Broadway Builder",
        description:
          "A single-page web application aimed to provide stage theaters with ways to connect with the community in a technology-driven society. We believe our application will help theaters all over North America by bringing a fresh, new feel to the stage theater community.",
        logoUrl:
          "https://centurymodern.com/wp-content/themes/your_theme/images/logo-small-square.png",
        underMaintenance: false,
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json"
        }
      }
    };
  },
  methods: {
    cancelPublish() {
      this.$emit("cancel", false);
    },
    async publishApp() {
      await axios
        .post(
          "https://sso-api.broadwaybuilder.xyz/api/applications/publish",
          this.appDetails
        )
        .then(
          response => this.$emit("cancel", false),
          alert("App Published to the SSO")
        )
        .catch(err => console.log(err));
    }
  }
};
</script>

<style lang="sass" scoped>
@import '../../../node_modules/bulma/bulma.sass'


</style>