<template>
<div>
    <button @click="GoBack()">Go back</button>
    <form>
        <div class="form-group">
            <label for="name">Date from:</label>
            <input type="date" class="form-control" v-model="dateFrom" :disabled="isDoctor"/>
             <input type="time" class="form-control" v-model="timeFrom" :disabled="isDoctor"/>
            <label for="name">Date to:</label>
            <input type="date" class="form-control" v-model="dateTo" :disabled="isDoctor"/>
            <input type="time" class="form-control" v-model="timeTo" :disabled="isDoctor"/>
            <label for="name">Pick doctor:</label>
            <select class="form-control" name="template" v-model="selectedDoctor" :disabled="isDoctor==false">
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
            <button type="submit" v-if="this.isShow == 1" >
            <span></span>Schedule</button>
        </div>
   </form>

  <tr> <label>{{message}}</label></tr>
 <tr>  <label v-if="this.message == 'No appointments found'">Suggest appointments:</label></tr>
   <table v-if="this.message == 'No appointments found'" class="styled-table">
    <thead>
        <tr>
            <th>Date from</th>
            <th>Date to</th>
            <th>Doctor</th> 
            <th></th>         
        </tr>
    </thead>
    <tbody>
          <tr v-for="(appointment, index) in appointments" :key="index">
                  <td>{{appointment.DateFrom}}</td>
                  <td>{{appointment.DateTo}}</td>
                  <td>{{appointment.Doctor}}</td>
           </tr> 
    </tbody>
</table>
</div>
</template>

<script>
import axios from 'axios';
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
        appointment: {DateFrom:"", DateTo:"", DoctorsFirstname:"", DoctorsLastname:""},
        message:"",
        isShow: 0,
        priority:"",
        isDoctor:null,
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

</style>