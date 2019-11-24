<template>
<div>
  <v-container>
    <h1 class="hidden-sm-and-up text-xs-center font-weight-bold display-1">About Us</h1>
    <h1 class="hidden-xs-only hidden-md-and-up text-xs-center font-weight-bold display-2">About Us</h1>
    <h1 class="hidden-sm-and-down hidden-lg-and-up text-xs-center font-weight-bold display-2">About Us</h1>
    <h1 class="hidden-md-and-down text-xs-center font-weight-bold display-3">About us</h1>

      <h2 class="header-size hidden-sm-and-up text-xs-left font-weight-bold ">Who we are</h2>
      <h2 class="header-size hidden-xs-only hidden-md-and-up text-xs-left font-weight-bold ">Who we are</h2>
      <h2 class="header-size hidden-sm-and-down hidden-lg-and-up text-xs-left font-weight-bold ">Who we are</h2>
      <h2 class="header-size hidden-md-and-down text-xs-left font-weight-bold ">Who we are</h2>
    <v-flex d-flex xs12>
      <v-container>
        <p class="font-weight-light body-1">
          Broadway Builder is a theatre social web application that will help theatres all over North America bring a fresh new feel to staged theatre.
          Broadway Builder allows users to browse theater profiles without the need of making an account. Users who decide to create an account will soon have
          access to viewing theater past productions and program shows. Another great benefit of being a memebr of broadway builder is that the user will be able to
          view theaters who are currently hiring. They can upload their resume and a hiring manager will be able to view it. This leads to expalning how broadway builder 
          is also not only for theater viewers but also theater companies.
        </p>

        <p class="font-weight-light body-1">
          In addition to viewing theater profiles and purchasing tickets,theatre companies will have the opportunity to create pages for their own companies for regular users to buy tickets for their shows.
          Theater companies will be able to manage theaters, like their description, and the productions they put on. They will also be able to post job oppurtunies and recieve resume's through our software.
          Broadway Builder aims to make theater management, easier and more effecient.
        </p>
      </v-container>
    </v-flex>
  </v-container>
</div>


</template>

<style scoped>

.header-size {
    font-size: 2rem;
    padding-left: 2rem;
}

</style>

<script>
import Vue from "vue";
import ReadMore from "vue-read-more";
Vue.use(ReadMore);

export default {
  name: "AboutUs",
  components: {

},
};
</script>