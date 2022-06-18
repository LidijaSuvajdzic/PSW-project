<template>
<div>CAOOOOOOOOOOOOOOOOOOOO</div>
</template>

<script>

export default {
  name: "StartPagePatient",
  data() {
    return {
        user: { Firstname: "", Lastname: ""},
        doctors:""
    };
  },

  methods: {
    async getAllDoctors() {
      const res = await fetch("http://localhost:58025/api/user/findAllDoctors");
      const data = await res.json();
      return data;   
    }
  },
  async created() {
    this.doctors = await this.getAllDoctors();
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