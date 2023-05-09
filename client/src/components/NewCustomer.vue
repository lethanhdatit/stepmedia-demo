<template>
  <div style="height: 720px;">
    <h1>NEW CUSTOMER</h1>
    <el-card class="box-card">
      <el-form :model="newCustomerForm" status-icon :rules="rules" ref="newCustomerForm" class="demo-newCustomerForm"
        style="margin-left: 20px;">

        <el-form-item label="Customer full name:" prop="fullName" required>
          <el-input v-model="newCustomerForm.fullName"></el-input>
        </el-form-item>

        <el-form-item label="Email:" prop="email" required>
          <el-input v-model="newCustomerForm.email"></el-input>
        </el-form-item>

        <el-form-item label="Birthday:" prop="dob" required>
          <el-date-picker :picker-options="{
            disabledDate(time) {
              return time.getTime() > Date.now();
            }
          }" style="width: 100%;" v-model="newCustomerForm.dob" type="date" placeholder="Pick a day">
          </el-date-picker>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="submitForm('newCustomerForm')">Submit</el-button>
          <el-button @click="resetForm('newCustomerForm')">Clear All</el-button>
        </el-form-item>
      </el-form>
    </el-card>

  </div>
</template>

<script>

export default {
  data() {
    var validateName = (rule, value, callback) => {
      if (!value || value.length == 0) {
        callback(new Error('Please input the customer name'));
      } else {
        callback();
      }
    };
    var validateEmail = (rule, value, callback) => {
      var regex = new RegExp('[a-z0-9]+@[a-z]+.[a-z]{2,3}');
      if (!value || value.length == 0) {
        callback(new Error('Please input the email'));
      } else if (!regex.test(value)) {
        callback(new Error('Invalid email format'));
      } else {
        callback();
      }
    };
    var validateDob = (rule, value, callback) => {
      if (!value || value.length == 0) {
        callback(new Error('Please input the birthday'));
      } else {
        callback();
      }
    };
    return {
      newCustomerForm: {
        email: null,
        fullName: null,
        dob: null,
      },
      rules: {
        fullName: [
          { validator: validateName, trigger: 'blur' }
        ],
        email: [
          { validator: validateEmail, trigger: 'blur' }
        ],
        dob: [
          { validator: validateDob, trigger: 'blur' }
        ],
      },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$confirm('Create new customer now?', 'Warning', {
            confirmButtonText: 'OK',
            cancelButtonText: 'Cancel',
            type: 'warning'
          }).then(async () => {
            console.log(this.newCustomerForm)
            var res = await this.$axios.post('/customers', this.newCustomerForm);
            if (res.status == 200 && res.data.status === 'success') {
              this.$message({
                type: 'success',
                message: 'Created!'
              });
              this.$router.push('/customers');
            }
          }).catch(() => {
            this.$message({
              type: 'info',
              message: 'Something went wrong!'
            });
          });
        } else {
          return false;
        }
      });
    },
    resetForm(formName) {
      this.$refs[formName].resetFields();
    },
  }
};
</script>