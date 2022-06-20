<template>
    <div>
<button @click="GoBack()">Go back</button>

    <form>
        <div class="form-group">
            <label for="name">Pick doctor:</label>
            <select class="form-control" name="template" v-model="selectedSpecialist">
                      <option v-for="(user , index) in specialist" v-bind:key="index"  >
                            {{user.Firstname}} {{user.Lastname}}
                      </option>
                  </select>
            <label for="name">Pick patient:</label>
            <select class="form-control" name="template" v-model="selectedPatient">
                      <option v-for="(user , index) in patients" v-bind:key="index"  >
                            {{user.Firstname}} {{user.Lastname}}
                      </option>
                  </select>   
             <label for="name">Reason:</label>       
              <input type="text" class="form-control" v-model="reason"/>
            <button type="submit" @click.prevent="CheckAvailability()" >
            <span></span> Check availability </button>
        </div>
   </form>

   <table v-if="this.isFound==true" class="styled-table">
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
                  <td><button @click="PickThisAppointment(appointment.Id)">Pick this appointment</button></td>

           </tr> 
    </tbody>
</table>
    </div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2';
export default {
  name: "MakeAReferral",
  data() {
    return {
        specialist:"",
        user: { Firstname: "", Lastname: ""},
        isFound:false,
                appointments:"",
        appointment: {Id:0, DateFrom:"", DateTo:"", DoctorsFirstname:"", DoctorsLastname:""},
        selectedDoctor:"",
        selectedSpecialist:"",
        selectedPatient:"",
        patients:"",
        reason:"",
        id:0,
        firstname:""
    };
  },

  methods: {
    async getAllSpecialists() {
      const res = await fetch("http://localhost:58025/api/user/findAllSpecialists");
      const data = await res.json();
      return data;   
    },
        async getAllPatients() {
      const res = await fetch("http://localhost:58025/api/user/findAllPatients");
      const data = await res.json();
      return data;   
    },
    async GoBack() {
        this.$router.push({ name: "StartPagePatient" });
    },
        async CheckAvailability() {
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.get("http://localhost:58025/api/appointment/findAppointments/"+this.selectedSpecialist, {headers})    
          .then (response => { 
          this.appointments = response.data;
          this.isFound=true;
          console.log("Duzina niza je"+this.appointments.length)
        })  .catch( error => {
        if(error.response.status == 400) {
         return new Swal({
             title:"Warning",
             type: "warning",
             text:'There is no appointment!Please,try again!'
           });
        }

      })    
    },

    async PickThisAppointment(Id){
        this.firstname= localStorage.getItem("firstname");
        this.id = Id;
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/referral/addReferral",{ 
       AppointmentId: this.id,
       SelectedSpecialist: this.selectedSpecialist,
       SelecterPatient: this.selectedPatient,
       Reason: this.reason,
       DoctorName: this.firstname,
        }, {headers})    
                .then (response => { 
          this.appointments = response.data;
          console.log("Duzina niza je"+this.appointments.length)
        })  .catch( error => {
        if(error.response.status == 400) {
         return new Swal({
             title:"Warning",
             type: "warning",
             text:'There is no appointment!Please,try again!'
           });
        }

      })  

    }
  },
  async created() {
    this.specialist = await this.getAllSpecialists();
    this.patients = await this.getAllPatients();
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