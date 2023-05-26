<template>
  <v-parallax height="650" src="https://source.unsplash.com/RwHv7LgeC7s">
    <div class="d-flex flex-column fill-height justify-center align-center text-white">
      <h1
        class="text-h1 font-weight-regular mb-4"
        style="font-family: 'Rubik Wet Paint', cursive !important; letter-spacing: .2rem !important; text-shadow: -2px -2px 0 #000, 2px -2px 0 #000, -2px 2px 0 #000, 2px 2px 0 #000; !important;"
      >
        W.O.R.D.L.E
      </h1>
      <p
        class="subheading font-weight-bold"
        style="background-color: #1d1d1db0; padding: 0px 10px; border-radius: 15px"
      >
        Check out all we have to offer in this bootleg copy of the classic NYTimes fan-favorite!
      </p>
      <div>
        <v-btn to="/instruct" variant="outlined" class="midbtn" style="background-color: #1d1d1d5e"
          >How to Play</v-btn
        >
        <v-btn
          to="/wordoftheday"
          variant="outlined"
          class="midbtn"
          style="background-color: #1d1d1d5e"
          >Daily Wordle</v-btn
        >
        <v-btn to="/wordle" variant="outlined" class="midbtn" style="background-color: #1d1d1d5e"
          >Play Random</v-btn
        >
      </div>
    </div>
  </v-parallax>
</template>
<style>
@import url('https://fonts.googleapis.com/css2?family=Rubik+Wet+Paint&display=swap');

.midbtn {
  margin-top: 15px;
  margin-left: 5px;
  margin-right: 5px;
}
</style>
