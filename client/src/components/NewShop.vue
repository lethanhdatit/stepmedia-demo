<template>
  <div style="height: 720px;">
    <h1>NEW SHOP</h1>
    <el-card class="box-card">
      <el-form :model="newShopForm" status-icon :rules="rules" ref="newShopForm" class="demo-newShopForm"
        style="margin-left: 20px;">

        <el-form-item label="Shop name:" prop="name" required>
          <el-input v-model="newShopForm.name"></el-input>
        </el-form-item>

        <el-form-item label="Location:" prop="location" required>
          <el-input v-model="newShopForm.location"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="submitForm('newShopForm')">Submit</el-button>
          <el-button @click="resetForm('newShopForm')">Clear All</el-button>
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
        callback(new Error('Please input the shop name'));
      } else {
        callback();
      }
    };
    var validateLocation = (rule, value, callback) => {
      if (!value || value.length == 0) {
        callback(new Error('Please input the shop location'));
      } else {
        callback();
      }
    };
    return {
      newShopForm: {
        location: null,
        name: null,
      },
      rules: {
        name: [
          { validator: validateName, trigger: 'blur' }
        ],
        location: [
          { validator: validateLocation, trigger: 'blur' }
        ],
      },
    };
  },
  methods: {
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$confirm('Create new shop now?', 'Warning', {
            confirmButtonText: 'OK',
            cancelButtonText: 'Cancel',
            type: 'warning'
          }).then(async () => {
            var res = await this.$axios.post('/shops', this.newShopForm);
            if (res.status == 200 && res.data.status === 'success') {
              this.$message({
                type: 'success',
                message: 'Created!'
              });
              this.$router.push('/shops');
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