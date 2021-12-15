<template>
 <div>
  <img src="../../img/istockphoto-1138365810-170667a.jpg" alt="kids reading" /> 

  <img src="../../img/istockphoto-1294218659-170667a.jpg" alt="parent reading to kids" />
  <div class="circle">
   <p class="text">
      The concept of the Breakfast Book Club began as a study hall in 1984, it quickly grew into a fun-filled reading competition amongst friends.
      The Breakfast Club, once an inclusive book club amongst aspiring tech elevator classmastes, has grown to much more.
      The tradtition has now been passed down to their kids, and expanded to a website 
      where familites can track daily readings, 
      compete with friends and family to get prizes and continue the tradtition of the club.
    </p>
  </div>  
 </div>
</template>

<script>
export default {

}
</script>

<style scoped>

p {
  margin: 20px;
  padding: 50px;
  font-size: 30px;
  align-items: center;
}

#nav {
  margin: 20px;
}

img {
  align-items: center;
  padding: 40px;
  margin: 10px;
  size: 50%;
  
}

.circle {
    background: #92D5F2;
    width: 500px;
    height: 500px;
    border-radius: 50%;
    display: inline-block;
    text-align: center;
    margin:5px;
    overflow:hidden;
    padding:25px;
    position:relative;
}

.text{
  transform:translate(-55%,-53%);
  position:relative;
  top:50%;
  left:50%;
  font-size: 60%;
}

</style>