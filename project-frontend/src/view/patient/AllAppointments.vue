<template>
<div>
   
    <NavBarAppointments/>
</div>
<div>
       <table class="styled-table">
    <thead>
        <tr>
            <th>ID</th>
            <th>Date from</th>
            <th>Date to</th>
            <th>Doctor</th> 
            <th></th>         
        </tr>
    </thead>
    <tbody>
        
          <tr v-for="(appointment, index) in appointments" :key="index">
          <td>{{appointment.Id}}</td>
                  <td>{{appointment.DateFrom}}</td>
                  <td>{{appointment.DateTo}}</td>
               <td>{{appointment.Doctor}}</td>
           </tr> 
    </tbody>
</table>
 <button @click="GoBack()">Go back</button>
    </div>
</template>

<script>
import NavBarAppointments from '../../components/NavBarAppointments.vue';

export default {
    name: "AllAppointments",
      components: {
        NavBarAppointments
    },
    data() {
        return {
            appointments: "",
            appointment: { Id: 0, DateFrom: "", DateTo: "", DoctorsFirstname: "", DoctorsLastname: "" },
        };
    },
    methods: {
        async getAllDoctors() {
            const res = await fetch("http://localhost:58025/api/user/findAllDoctors");
            const data = await res.json();
            return data;
        },
        async GoBack(){
            this.$router.push({ name: "StartPagePatient" });
        }
    },
    async created() {
        //this.appointments = await this.getAllDoctors();
    },
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
.styled-table {
    border-collapse: collapse;
    margin: 25px 20px;
    font-size: 0.9em;
    font-family: sans-serif;
    min-width: 400px;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.styled-table thead tr {
    background-color: #809cc5;
    color: #ffffff;
    text-align: left;
}
button {
  background-color: #809cc5; 
}
.styled-table th,
.styled-table td {
    padding: 12px 15px;
}
</style>