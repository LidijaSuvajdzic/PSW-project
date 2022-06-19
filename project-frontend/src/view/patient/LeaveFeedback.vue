<template>
<div> 
    <form>
        <div class="form-group">
            <label for="name">Grade:</label>
                        <select class="form-control" name="template" v-model="grade">
                      <option value="1">1</option>
                      <option value="2">2</option>
                      <option value="3">3</option>
                      <option value="4">4</option>
                      <option value="5">5</option>
                  </select> 
            <label for="name">Comment:</label>
            <input type="text" class="form-control" v-model="comment"/>
            <label for="name">Do you want to be anonymously?</label>
            <select class="form-control" name="template" v-model="anonymously">
                      <option value="Yes">Yes</option>
                      <option value="No">No</option>
                  </select> 
            <button type="submit" @click="AddFeedback()">
            <span></span>Leave a feedback</button>
        </div>
   </form>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name: "LeaveFeedback",

    data() {
        return {
            grade:"",
            comment:"",
            anonymously:""
        };
    },
    methods: {
        async AddFeedback() {
            this.firstname = localStorage.getItem("firstname");
            console.log(this.grade);
            console.log(this.comment);
            console.log(this.firstname);
            console.log(this.anonymously);
      const headers ={
        "Content-type": "application/json",
      }; 
      axios.post("http://localhost:58025/api/hospitalFeedback/addHospitalFeedback",{ 
        PatientName: this.firstname,
        Grade: this.grade,
        Comment:this.comment,
        IsAnonymously: this.anonymously
        }, {headers}) 
        }
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

button {
  background-color: #809cc5; 
}

</style>