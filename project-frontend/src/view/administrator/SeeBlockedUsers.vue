<template>
<div> 
       <table class="styled-table">
    <thead>
        <tr>
            <th>ID</th>
            <th>Ime</th>
            <th>Prezime</th>
            <th></th>         
        </tr>
    </thead>
    <tbody>
          <tr v-for="(user, index) in users" :key="index">
               <td>{{user.UserId}}</td>
               <td>{{user.Firstname}}</td>
               <td>{{user.Lastname}}</td>
               <td>
               <button @click="UnBlock(user.UserId)">Unblock</button>
               </td>
           </tr> 
    </tbody>
</table>
    </div>
</template>

<script>
import axios from 'axios';
export default {
    name: "SeeBlockedUsers",
      components: {
},
    data() {
        return {
        user: { Firstname: "", Lastname: ""},
        users:"",
        id:0,
        };
    },
    methods: {
        async findBlockedUsers() {
      const res = await fetch("http://localhost:58025/api/user/findBlockedUsers");
      const data = await res.json();
      return data;   
        },
        async UnBlock(UserId) {
            this.id=UserId;
            axios.post("http://localhost:58025/api/user/unblock/"+this.id) 
            this.$router.go(0)

        },
   },
    async created() {
        this.users= await this.findBlockedUsers();
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