<template>
<div><button @click="MakeAnAppointment()">Make an appointment</button></div>
<div><button @click="SeeAllAppointments()">See your appointments</button></div>
<div><button @click="LeaveFeedback()">Leave feedback</button></div>
</template>

<script>

export default {
  name: "StartPagePatient",
  data() {
    return {
        user: { Firstname: "", Lastname: ""},
        doctors:""
    };
  },

  methods: {
    async getAllDoctors() {
      const res = await fetch("http://localhost:58025/api/user/findAllDoctors");
      const data = await res.json();
      return data;   
    },
    async MakeAnAppointment() {
 this.$router.push({ name: "MakeAnAppointment" });

    },
        async SeeAllAppointments() {
 this.$router.push({ name: "AllAppointments" });

    },
    async LeaveFeedback(){
       this.$router.push({ name: "LeaveFeedback" });
    }
  },
  async created() {
    this.doctors = await this.getAllDoctors();
  }
};
</script>

<style scoped>
.li {
  margin-left: 15px;
}

button {
  background-color: #809cc5;
}

img {
  width: 100%;
}

</style>