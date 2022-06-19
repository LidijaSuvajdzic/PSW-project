<template>
  <nav class="navbar navbar-expand-sm bg-light">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link"
          ><router-link to="/AllAppointments">Previous appointment</router-link></a
        >
      </li>
      <li class="nav-item">
        <a class="nav-link"
          ><router-link to="/FutureAppointments"
            >Future appointments</router-link
          ></a
        >
      </li>
    </ul>
  </nav>
</template>
<style scoped>
a {
  background-color: #809cc5; /* Green */
   color: black;
}
</style>