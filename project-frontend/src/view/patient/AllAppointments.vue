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
            <td><button v-if="appointment.IsRated == false" data-target="#rate" data-toggle="modal" @click="Save(appointment.Id)">Rate</button></td>

           </tr> 
    </tbody>
</table>
 <button @click="GoBack()">Go back</button>
    </div>


        <div class="modal fade" id="rate" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <h5
              class="modal-title"
              id="exampleModalLabel"
              style="color: #0b4025; padding: 5px 35px"
            >
              Leave a feedback
            </h5>
          </div>
          <div class="modal-body" style="padding: 15px 50px">
            <form role="form">

              <div class="form-group">
                <label for="name">Grade:</label>
            <select class="form-control" name="template" v-model="grade">
                      <option value="1">1</option>
                      <option value="2">2</option>
                      <option value="3">3</option>
                      <option value="4">4</option>
                      <option value="5">5</option>
                  </select> 
              </div>
              
              <div class="form-group">
                <label for="name">Comment:</label>
                <input
                  type="text"
                  class="form-control"
                  v-model="comment"
                />
              </div>

              <button
                type="submit"
                class="btn btn-success btn-block"
                @click="AddFeedback(grade,comment)"
              >
                <span></span> Add
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
export default {
    name: "AllAppointments",
      components: {
        NavBarAppointments
    },
    data() {
        return {
            appointments: "",
            appointment: { Id: 0, DateFrom: "", DateTo: "", DoctorsFirstname: "", DoctorsLastname: "", isRated:null },
             firstname:"",
             grade:"",
             comment:"",
             id:0
        };
    },
    methods: {
        async findPreviousAppointments() {
              this.firstname = localStorage.getItem("firstname");
      const res = await fetch("http://localhost:58025/api/appointment/findPreviousAppointments/"+this.firstname);
      const data = await res.json();
      return data; 
        },
        async GoBack(){
            this.$router.push({ name: "StartPagePatient" });
        },
        async Save(id) {
            this.id = id;
        },
        async AddFeedback(grade,comment) {
            this.grade=grade;
            this.comment=comment;
            this.firstname = localStorage.getItem("firstname");
            console.log(this.grade);
            console.log(this.comment);
            console.log(this.firstname);
            console.log(this.id);
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/appointmentFeedback/addAppointmentFeedback",{ 
        PatientName: this.firstname,
        AppointmentId: this.id,
        Grade:this.grade,
        Comment:this.comment
        }, {headers})    
        }
    },
    async created() {
        this.appointments= await this.findPreviousAppointments();
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