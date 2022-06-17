<template>
  <nav
    class="navbar navbar-expand-sm bg-light navbar-dark justify-content-center"
  >
    <ul class="navbar-nav">
      <li class="nav-item">
        <button
          type="button"
          style="margin-left: 20px; width: 120px"
          data-target="#login" data-toggle="modal"
          
        >
         Login
        </button>
      </li>

      <li class="nav-item">
        <button
          type="button"
          style="margin-left: 20px; width: 120px"
          data-target="#signup" data-toggle="modal"
        >
          Sign up
        </button>
      </li>
    </ul>
  </nav>
<img src="https://www.securitymagazine.com/ext/resources/secenews/2018/hosp-900.jpg?1515062945" alt="Trulli" />

      <!--Modal prijava-->
    <div class="modal fade" id="login" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content -->
        <div class="modal-content">
          <div class="modal-header">
            <h5
              class="modal-title"
              id="exampleModalLabel"
              style="color: #0b4025; padding: 5px 35px"
            >
              Login
            </h5>
          </div>
          <div class="modal-body" style="padding: 15px 50px">
            <form role="form" @submit.prevent="Login">
              <div class="form-group">
                <label for="name">E-mail:</label>
                <input
                  type="text"
                  class="form-control"
                  placeholder="Enter your email"
                />
              </div>
              <div class="form-group">
                <label for="psw"
                  ><span class="glyphicon glyphicon-eye-open"></span>
                  Password:</label
                >
                <input
                  type="password"
                  class="form-control"
                  id="psw"
                  placeholder="Enter your password"
                />
              </div>
              <button
                type="submit"
              >
                <span></span> Submit
              </button>
            </form>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              data-dismiss="modal"
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Modal registracija-->
    <div class="modal fade" id="signup" role="dialog">
      <div class="modal-dialog">
        <!-- Modal content -->
         <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel" style="color: #0b4025; padding: 5px 35px" > Sign up </h5>
          </div>
          <div class="modal-body" style="padding: 15px 50px">

            <form role="form">

              <div class="form-group">
                <label for="name">Firstname</label>
                <input  type="text" class="form-control" placeholder="Enter your firstname" v-model="firstname"/>
                <label for="name">Lastname</label>
                <input type="text" class="form-control" placeholder="Enter your lastname" v-model="lastname"/>
                <label for="name">Email </label>
                <input type="text"  class="form-control" placeholder="Enter your email" v-model="email"/>
                <label for="name">Health card number</label>
                <input type="text" class="form-control" placeholder="Enter your health card number" v-model="healthCardNumber"/>
              </div>

               <div class="form-group">
                <label for="psw" ><span class="glyphicon glyphicon-eye-open" ></span> Password</label>
                <input type="password"  class="form-control"   id="psw"  placeholder="Enter your password"  v-model="password"/>
              </div>
              <div class="form-group"><label for="psw" ><span class="glyphicon glyphicon-eye-open" ></span> Password again</label >
               <input type="password" class="form-control" id="psw" placeholder="Enter your password again" v-model="passwordAgain"/>
              </div>
              <button type="submit" @click="Register()"> <span></span> Submit </button>
            </form>
          </div>
          <div class="modal-footer">
            <button
              type="button"
              data-dismiss="modal"
            >
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>

</template>

<script>
import Swal from 'sweetalert2';
import axios from 'axios';

export default {
  name: "StartPage",
  data() {
    return {
      firstname:"",
      lastname:"",
      email:"",
      password:"",
      passwordAgain:"",
      healthCardNumber:"",
      role:"PATIENT"

    };
  },

  methods: {
async Register() {
      const headers ={
              'Content-Type': 'application/json;charset=UTF-8',
              Accept: 'application/json',
            }
    axios.post("http://localhost:58025/api/user",{       
        Firstname : this.firstname, 
        Lastname : this.lastname,
        Email : this.email,
        Passwordd : this.password,
        HealthCardNumber : this.healthCardNumber,
        Role : this.role}, {
        headers}
      ).then((res) => {
            console.log(res);
            new Swal({
              title:"Uspesno",
              type: "warning",
              text:'Registracija je uspela!',
            });
          })
          .catch((error) => {
            console.log(error.response.status);
            if(error.response.status == 417) {
            new Swal({
              title:"Nije uspesno",
              type: "warning",
              text:'Postoji vec korisnik sa tim email-om!',
            });
            }else if (error.response.status == 409) {
            new Swal({
              title:"Nije uspesno",
              type: "warning",
              text:'Postoji vec korisnik sa tim username-om!',
            });
            }
          });
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

</style>