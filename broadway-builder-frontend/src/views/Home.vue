<template>
  <div id="home">
    <!-- <SearchBar /> -->
    <v-divider></v-divider>

    <v-card id="welcome">
      <v-container fluid grid-list-md>
        <v-parallax height="550" dark src="https://img-new.cgtrader.com/items/769294/51f124929c/theatre-stage-3d-model-obj-3ds-fbx-blend-dae.jpg">
          <v-layout align-center column justify-center>
            <h1 class="display-2 font-weight-thin mb-3">Welcome</h1>
            <h4 class="subheading">And <strong>thank you</strong> for choosing Broadway Builder</h4>
            <div v-if="!$store.state.token" style="margin: 4em 1em">
              <v-btn href="https://sso.broadwaybuilder.xyz/#/register" depressed>Register</v-btn>
              or
              <v-btn href="https://sso.broadwaybuilder.xyz/#/login" depressed>Sign In</v-btn>
            </div>
          </v-layout>
        </v-parallax>
      </v-container>
    </v-card>
  </div>
</template>

<script>
export default {
  name: "home",
  created() {
    console.log("User Token: " + this.$store.state.token);
  }
};
</script>

<style lang="sass" scoped>
#home
  margin: 1em

#welcome
  margin: 0ss

h2
  font-family: Roboto
  font-style: italic
</style>
