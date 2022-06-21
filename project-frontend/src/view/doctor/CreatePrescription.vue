<template>
    <div>
<button @click="GoBack()">Go back</button>

    <form>
        <div class="form-group">
            <label for="name">Enter the name of the drug:</label>
            <input type="text" class="form-control" v-model="drug"/>
            <label for="name">Pick patient:</label>
            <select class="form-control" name="template" v-model="selectedPatient">
                      <option v-for="(user , index) in patients" v-bind:key="index"  >
                            {{user.Firstname}} {{user.Lastname}}
                      </option>
                  </select>   
             <label for="name">Usage:</label>       
              <input type="text" class="form-control" v-model="usage"/>
            <button type="submit" @click="Create()" >
            <span></span> Create prescription</button>
        </div>
   </form>
    </div>
</template>

<script>
import axios from 'axios';
export default {
  name: "MakeAReferral",
  data() {
    return {
        user: { Firstname: "", Lastname: ""},
        patients:"",
        selectedPatient:"",
        firstname:"",
        drug:"",
        usage:"",
        doctor:""

    };
  },

  methods: {
        async getAllPatients() {
      const res = await fetch("http://localhost:58025/api/user/findAllPatients");
      const data = await res.json();
      return data;   
    },
        async GoBack() {
        this.$router.push({ name: "StartPagePatient" });
    },
    async Create() {
        this.doctor = localStorage.getItem("firstname")+" "+localStorage.getItem("lastname");
      axios.post("http://localhost:58025/api/prescription/addPrescription",{ 
       Patient:this.selectedPatient,
       Doctor:this.doctor,
       Drug:this.drug,
       Usage:this.usage
        })  
    }
  },
  async created() {
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