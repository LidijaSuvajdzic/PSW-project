<template>
<div> 
    <NavBarAppointments />
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
               <td><button  data-target="#cancel" data-toggle="modal" @click="SaveId(appointment.Id)">Cancel</button></td>
           </tr> 
    </tbody>
</table>
 <button @click="GoBack()">Go back</button>
    </div>

            <div class="modal fade" id="cancel" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <h5
              class="modal-title"
              id="exampleModalLabel"
              style="color: #0b4025; padding: 5px 35px"
            >
              Are you sure about cancelling the appointment?
            </h5>
          </div>
          <div class="modal-body" style="padding: 15px 50px">
            <form role="form">
              <button
                type="submit"
                class="btn btn-success btn-block"
                @click="Cancel()"
              >
                <span></span> Cancel the appointment
              </button>
            </form>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import NavBarAppointments from '../../components/NavBarAppointments.vue';
import axios from 'axios';
import Swal from 'sweetalert2';

export default {
    name: "FutureAppointments",
      components: {
    NavBarAppointments,
},
    data() {
        return {
            appointments: "",
            appointment: { Id: 0, DateFrom: "", DateTo: "", DoctorsFirstname: "", DoctorsLastname: "" },
            firstname:"",
            id:0,
        };
    },
    methods: {
        async findFutureAppointments() {
    this.firstname = localStorage.getItem("firstname");
      const res = await fetch("http://localhost:58025/api/appointment/findFutureAppointments/"+this.firstname);
      const data = await res.json();
      return data;   
        },
        async GoBack(){
            this.$router.push({ name: "StartPagePatient" });
        },
                async SaveId(id) {
            this.id = id;
        },
        async Cancel() {
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.delete("http://localhost:58025/api/appointment/delete/"+this.id, {headers}) 
                    .catch( function (error) {
        if (error.response.status == 400) {
         return new Swal({
             title:"Warning",
             type: "warning",
             text:'You can not cancel the appointment!'
           });}
      })   
        }

    },
    async created() {
        this.appointments= await this.findFutureAppointments();
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