<template>
<div>
    <button @click="GoBack()">Go back</button>
    <form>
        <div class="form-group">
            <label for="name">Date from:</label>
            <input type="date" class="form-control" v-model="dateFrom" :disabled="isDoctor==false"/>
             <input type="time" class="form-control" v-model="timeFrom" :disabled="isDoctor==false"/>
            <label for="name">Date to:</label>
            <input type="date" class="form-control" v-model="dateTo" :disabled="isDoctor==false"/>
            <input type="time" class="form-control" v-model="timeTo" :disabled="isDoctor==false"/>
            <label for="name">Pick doctor:</label>
            <select class="form-control" name="template" v-model="selectedDoctor" :disabled="isDoctor==true">
                      <option v-for="(user , index) in doctors" v-bind:key="index"  >
                            {{user.Firstname}} {{user.Lastname}}
                      </option>
                  </select>
            <label for="name">Pick priority:</label>
            <select class="form-control" name="template" v-model="priority">
                      <option value="Doctor">Doctor</option>
                      <option value="Time">Time</option>
                  </select>      
            <button type="submit" @click.prevent="Check()" >
            <span></span> Check availability </button>
            <button type="submit" v-if="this.isShow == 1" @click="Schedule()">
            <span></span>Schedule</button>
        </div>
   </form>

  <tr> <label>{{message}}</label></tr>
 <tr>  <label v-if="this.message == 'No appointments found'">Suggest appointments:</label></tr>
   <table v-if="this.message == 'No appointments found'" class="styled-table">
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
                  <td><button @click="Pick(appointment.Id)">Pick this appointment</button></td>

           </tr> 
    </tbody>
</table>
</div>
</template>

<script>
import axios from 'axios';
import Swal from 'sweetalert2'
export default {
  name: "MakeAnAppointment",
  data() {
    return {
        dateFrom:"",
        dateTo:"",
        timeFrom:"",
        timeTo:"",
        selectedDoctor:"",
        user: { Firstname: "", Lastname: ""},
        doctors:"",
        appointments:"",
        appointment: {Id:0, DateFrom:"", DateTo:"", DoctorsFirstname:"", DoctorsLastname:""},
        message:"",
        isShow: 0,
        priority:"",
        isDoctor:null,
        patient: "",
        id:0
    };
  },

  methods: {
    async getAllDoctors() {
      const res = await fetch("http://localhost:58025/api/user/findAllDoctors");
      const data = await res.json();
      return data;   
    },
    async Check() {
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/appointment/",{ 
       DateFrom: this.dateFrom,
       DateTo: this.dateTo,
       TimeFrom: this.timeFrom,
       TimeTo: this.timeTo,
      SelectedDoctor: this.selectedDoctor
        }, {headers})      
        .then (response => { 
        this.message = response.data;
        if (response.data === "We found an appointment for you") {
          this.isShow = 1;
        }else if (response.data === "No appointments found") {
          if(this.priority == "Doctor") {
            this.isDoctor = true;
          }else{
            this.isDoctor = false;
          }
        this.SuggestAppointments();
         
        }
      }) 
    },
        async SuggestAppointments() {
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/appointment/suggestAppointments",{ 
       DateFrom: this.dateFrom,
       DateTo: this.dateTo,
       TimeFrom: this.timeFrom,
       TimeTo: this.timeTo,
       SelectedDoctor: this.selectedDoctor,
       Priority: this.priority
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
    },
            async Schedule() {
      this.patient = localStorage.getItem("firstname");
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/appointment/addAppointment",{ 
       DateFrom: this.dateFrom,
       DateTo: this.dateTo,
       TimeFrom: this.timeFrom,
       TimeTo: this.timeTo,
       Doctor: this.selectedDoctor,
       Patient : this.patient
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
    },
      async Pick(Id) {
      this.id = Id;;
      console.log("id je"+ this.id)
      this.patient = localStorage.getItem("firstname");
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/appointment/addAppointmentFromTable/"+this.id+"/"+this.patient, {headers})    
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
    },
    async GoBack() {
        this.$router.push({ name: "StartPagePatient" });
    }
  },
  async created() {
    this.doctors = await this.getAllDoctors();
    console.log(this.doctors.length)
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