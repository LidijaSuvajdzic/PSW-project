<template>
<div>
    <button @click="GoBack()">Go back</button>
    <form>
        <div class="form-group">
            <label for="name">Date from:</label>
            <input type="date" class="form-control" v-model="DateFrom"/>
             <input type="time" class="form-control" v-model="TimeFrom"/>
            <label for="name">Date to:</label>
            <input type="date" class="form-control" v-model="DateTo"/>
            <input type="time" class="form-control" v-model="TimeTo"/>
            <label for="name">Pick doctor:</label>
            <select class="form-control" name="template" v-model="SelectedDoctor">
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

   <label>{{message}}</label>
</div>
</template>

<script>
import axios from 'axios';
export default {
  name: "MakeAnAppointment",
  data() {
    return {
        DateFrom:"",
        DateTo:"",
        TimeFrom:"",
        TimeTo:"",
        SelectedDoctor:"",
        user: { Firstname: "", Lastname: ""},
        doctors:"",
        message:"",
        isShow: 0,
        priority:""
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
              'Content-Type': 'application/json;charset=UTF-8',
              Accept: 'application/json',
            }
      console.log(this.DateFrom.toString())
      console.log(this.DateTo.toString())
      console.log(this.TimeFrom.toString())
      console.log(this.TimeTo.toString())
      console.log(this.SelectedDoctor)
      axios.get("http://localhost:58025/api/appointment/",{    
        Email: "caoo", Passwordd: "caca"},{headers})
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