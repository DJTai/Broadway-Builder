<template>
  <v-app id="theater-profile">
    <v-container fluid grid-list-md>
      <v-layout row wrap>
        <v-flex d-flex xs12 sm3 md5>
          <v-card>
            <v-container>
              <v-img src="https://picsum.photos/510/300?random"></v-img>
            </v-container>
          </v-card>
        </v-flex>

        <v-flex d-flex xs12 sm9 md7 class="theater-info">
          <v-container class="theater-info">
            <h1 class="font-weight-medium">{{ theater.TheaterName }}</h1>
            <br>
            <p class="font-weight-light body-1">{{ lorem }}</p>
            <v-divider></v-divider>
            <!-- <div id="theater-actions">
              <v-btn @click="goToPictures(theater)" depressed large>Past Productions</v-btn>
              <v-btn v-if="isTheaterAdmin" @click="goToHelpWanted(theater, true)" depressed large>Job Opportunities Admin </v-btn>
              <v-btn @click="goToHelpWanted(theater, false)" depressed large>Job Opportunities User</v-btn>
            </div> -->
          </v-container>
        </v-flex>
      </v-layout>
    </v-container>
  </v-app>

</template>


<script>
  import axios from "axios";
  import forcem from "forcem-ipsum";

  export default {
    name: "TheaterProfile",
    props: ['TheaterID'],
    data() {
      return {
        lorem: forcem(undefined, 2).join(" "),
        show: false,
        theater: {},
        permission: true,
        isTheaterAdmin: this.$store.state.isTheaterAdmin
      };
    },
    methods: {
      goToPictures(theater) {
        this.$router.push({
          name: "userproductioninfo",
          params: {
            TheaterID: this.TheaterID
          }
        });
      },
      goToHelpWanted(theater, permission) {
        this.$router.push({
          name: "helpwanted",
          params: {
            TheaterID: this.TheaterID,
            theater: theater,
            hasPermission: permission
          }
        });
      }
    },
    async mounted() {
      if (this.TheaterID) {
        await axios
        .get(`https://api.broadwaybuilder.xyz/theater/get/${this.TheaterID}`)
        .then(response => (this.theater = response.data));
      }
      else {
        console.error(`Failed to get theatre for ID: ${this.TheaterID}`)
      }
    }
  };
</script>


<style lang="css">
#theater-profile {
  margin: 2em 1em;
}

#theater-actions {
  margin-top: 2em;
  text-align: -webkit-center;
}

p.font-weight-light.body-1 {
  font-size: 16px!important;
}

.backpic {
  position: absolute;
  top: 10px;
  left: 10px;
  z-index: 1;
}

.button {
  background-image: linear-gradient(to right, #6f0000, #200122);
  box-shadow: 0px 8px 15px rgba(0, 0, 0, 0.1);
  color: #dedede;
  font-family: "Roboto";
  text-shadow: 1.5px 1.5px black;
  font-size: 1.5em;
  font-weight: bold;
  transition: all 0.3s ease 0s;
}

.button:hover {
  background-color: #6f0000;
  box-shadow: 0px 15px 20px rgba(0, 0, 0, 0.4);
  color: #fff;
  transform: translateY(-7px);
}

.card-footer-item {
  color: black;
}

.container.theater-info {
  padding: 0 16px 0 16px;
}

.profpic {
  position: absolute;
  top: 25px;
  left: 25px;
  z-index: 2;
}

.theater-info {
  height: 100px;
}
</style>
