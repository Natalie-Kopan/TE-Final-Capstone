<template>
  <div class="container">
    <div class="row">
      <!-- <img
        class="col-sm"
        src="../../img/istockphoto-1138365810-170667a.jpg"
        alt="kids reading"
      />

      <img
        class="col-sm"
        src="../../img/istockphoto-1294218659-170667a.jpg"
        alt="parent reading to kids"
      /> -->
      <div class="col-sm">>
        <img class="about-img" src="../../img/reading-astro.jpeg" />
      </div>
      <div class="circle col-sm">
        <p class="col-12 text">
        <i class="fas fa-mug-hot"></i><br><br>
          The concept of the Breakfast Book Club began as a study hall in 1984, it quickly grew into a fun-filled reading competition amongst friends.
          The Breakfast Club, once an inclusive book club amongst aspiring tech elevator classmastes, has grown to much more.
          The tradtition has now been passed down to their kids, and expanded to a website 
          where familites can track daily readings, 
          compete with friends and family to get prizes and continue the tradtition of the club.
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
p {
  margin: 20px;
  padding: 50px;
  font-size: 30px;
  align-items: center;
}

/* img {
  align-items: center;
  padding: 40px;
  margin: 10px;
  size: 50%;
} */

.circle {
  background: #92d5f2;
  color: black;
  width: 500px;
  height: 500px;
  border-radius: 50%;
  display: inline-block;
  text-align: center;
  margin: 5px;
  overflow: hidden;
  padding: 25px;
  position: relative;
  border: 10px solid #ffca3a;
}

.text {
  transform: translate(-55%, -58%);
  position: relative;
  top: 50%;
  left: 50%;
  font-size: 60%;
  border-radius: 4rem;
}

.fa-mug-hot {
  font-size: 4rem;
}

img.about-img {
  align-items: center;
  border-radius: 50%;
  margin: 20px;
  border: 10px solid #ffca3a;
}
</style>