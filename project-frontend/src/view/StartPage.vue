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
                <input  type="text" class="form-control" placeholder="Enter your firstname" v-model="this.firstname"/>
                <label for="name">Lastname</label>
                <input type="text" class="form-control" placeholder="Enter your lastname" v-model="this.lastname"/>
                <label for="name">Email </label>
                <input type="text"  class="form-control" placeholder="Enter your email" v-model="this.email"/>
                <label for="name">Health card number</label>
                <input type="text" class="form-control" placeholder="Enter your health card number" v-model="this.healthCardNumber"/>
              </div>

               <div class="form-group">
                <label for="psw" ><span class="glyphicon glyphicon-eye-open" ></span> Password</label>
                <input type="password"  class="form-control"   id="psw"  placeholder="Enter your password"  v-model="this.password"/>
              </div>
              <div class="form-group"><label for="psw" ><span class="glyphicon glyphicon-eye-open" ></span> Password again</label >
               <input type="password" class="form-control" id="psw" placeholder="Enter your password again" v-model="this.passwordAgain"/>
              </div>
              <button type="submit" @click.prevent="Register()"> <span></span> Submit </button>
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
      if (!this.validFirstname()) {
            new Swal({
              title:"Warning",
              type: "warning",
              text:'Firstname should be longer!',
            });
    }else if(!this.validLastname()) {
            new Swal({
              title:"Warning",
              type: "warning",
              text:'Lastname should be longer!',
            });
    }else if (!this.validPassword()) {
             new Swal({
              title:"Warning",
              type: "warning",
              text:'The code is not in good shape! The code must contain at least one lowercase, one uppercase letter, a special character and one number!',
            });     
    } else if (this.password != this.passwordAgain ) {
            new Swal({
             title:"Warning",
             type: "warning",
             text:'Passwords do not match!',
           }); 
   }else if(!this.validEmail()) {
           new Swal({
             title:"Warning",
             type: "warning",
             text:'The email is not in good shape!',
           });
    }
    else {
      console.log(this.firstname);
       console.log(this.lastname);
        console.log(this.email);
         console.log(this.password);
          console.log(this.healthCardNumber);
           console.log( this.role);
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
              title:"Success",
              type: "warning",
              text:'You are registered!',
            });
          })  .catch( error => {
        if(error.response.status == 400) {
         return new Swal({
             title:"Warning",
             type: "warning",
             text:'User with this email already exists in system!'
           });
        }

      }) 
        }
    },
            validFirstname() {
      if (this.firstname.length < 1) {
        return false;
      }
      return true;
    },
            validLastname() {
      if (this.lastname.length < 1) {
        return false;
      }
      return true;
    },
            validPassword() {
      if (this.password.length < 8) {
        return false;
      } else if (this.password.length > 30) {
        return false;
      } else if (!this.password.match(/[a-z]/g)) {
        return false;
      } else if (!this.password.match(/[A-Z]/g)) {
        return false;
      } else if (!this.password.match(/[0-9]/g)) {
        return false;
      } else if (!this.password.match(/[!@#$%^&*.,:'+-/\\"]/g)) {
        return false;
      }
      return true;
    }, 
        validEmail() {
      if (
        !/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(
          this.email
        )
      ) {
        return false;
      } else if (this.email.length > 35) {
        return false;
      }
      return true;
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