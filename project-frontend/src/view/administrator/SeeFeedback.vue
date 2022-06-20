<template>
<div> 
       <table class="styled-table">
    <thead>
        <tr>
            <th>ID</th>
            <th>Pacijent</th>
            <th>Ocena</th>
            <th>Komentar</th> 
            <th>Does user is anonymously?</th>
            <th></th>         
        </tr>
    </thead>
    <tbody>
          <tr v-for="(fb, index) in feedback" :key="index">
               <td>{{fb.Id}}</td>
               <td>{{fb.PatientName}} {{fb.PatientLastname}}</td>
               <td>{{fb.Grade}}</td>
               <td>{{fb.Comment}}</td>
               <td>{{fb.IsAnonymously}}</td>
               <td>
                <button v-if="fb.IsPosted == false" @click="SetAction(fb.Id)">Set to start page</button>
               <button v-if="fb.IsPosted == true" @click="Remove(fb.Id)">Remove from start page</button>
               </td>
           </tr> 
    </tbody>
</table>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name: "SeeFedback",
      components: {
},
    data() {
        return {
            feedback: "",
            fb: {Id:0, PatientName:"", PatientLastname:"", Grade:0, Comment:"", IsAnonymously:false, IsPosted:false  },
            ID:"",
        };
    },
    methods: {
        async getFeedback() {
      const res = await fetch("http://localhost:58025/api/hospitalFeedback/getAll");
      const data = await res.json();
      return data;   
        },
        async SetAction(id) {
            this.ID = id;
            axios.post("http://localhost:58025/api/hospitalFeedback/setPublic/"+this.ID) 
            this.$router.go(0)
        },
        async Remove(id){
            this.ID = id;
            axios.post("http://localhost:58025/api/hospitalFeedback/removePublic/"+this.ID) 
            this.$router.go(0)
        }
   },
    async created() {
        this.feedback= await this.getFeedback();
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