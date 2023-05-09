<template>
  <div style="height: 720px;">
    <h1>NEW PRODUCT</h1>
    <el-card class="box-card">
      <el-form :model="newProductForm" status-icon :rules="rules" ref="newProductForm" class="demo-newProductForm"
        style="margin-left: 20px;">

        <el-form-item label="Shop:" prop="shopId" required>
          <el-select @change="onShopChange" style="width: 100%;" v-loading="shopSearchLoading"
            v-model="newProductForm.shopId" filterable remote reserve-keyword placeholder="Please enter a keyword"
            :remote-method="shopRemoteMethod" :loading="shopSearchLoading">
            <el-option v-for="item in shopOptions" :key="item.id" :label="item.name + ' - ' + item.location"
              :value="item.id">
            </el-option>
          </el-select>
        </el-form-item>

        <el-form-item label="Product name:" prop="name" required>
          <el-input v-model="newProductForm.name"></el-input>
        </el-form-item>


        <el-form-item label="Unit price (đ):" prop="unitPrice" required :rules="[{ required: true, message: 'Please enter unit price', trigger: 'blur' },
        { type: 'number', message: 'Unit price must be a number' }]">
          <el-input v-model.number="newProductForm.unitPrice" autocomplete="off"></el-input>
        </el-form-item>

        <el-form-item>
          <el-button type="primary" @click="submitForm('newProductForm')">Submit</el-button>
          <el-button @click="resetForm('newProductForm')">Clear All</el-button>
        </el-form-item>
      </el-form>
    </el-card>

  </div>
</template>

<script>

export default {
  data() {
    var validateProductName = (rule, value, callback) => {
      if (!value || value.length == 0) {
        callback(new Error('Please input the product name'));
      } else {
        callback();
      }
    };
    var validateShop = (rule, value, callback) => {
      if (value <= 0) {
        callback(new Error('Please input the shop'));
      } else {
        callback();
      }
    };
    return {
      shopList: [],
      shopOptions: [],
      shopSearchLoading: false,

      newProductForm: {
        shopId: null,
        name: null,
        unitPrice: null,
      },
      rules: {
        name: [
          { validator: validateProductName, trigger: 'blur' }
        ],
        shopId: [
          { validator: validateShop, trigger: 'blur' }
        ],
      },
    };
  },
  created() {
    this.fetch();
  },
  methods: {
    async fetch() {
      this.$axios.get('/shops').then(res => {
        if (res.status == 200) {
          this.shopList = res.data.pagedData
        }
      });
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$confirm('Create new product now?', 'Warning', {
            confirmButtonText: 'OK',
            cancelButtonText: 'Cancel',
            type: 'warning'
          }).then(async () => {
            var res = await this.$axios.post('/products', this.newProductForm);
            if (res.status == 200 && res.data.status === 'success') {
              this.$message({
                type: 'success',
                message: 'Created!'
              });
              this.$router.push('/products');
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
    shopRemoteMethod(query) {
      if (query !== '') {
        this.shopSearchLoading = true;
        setTimeout(() => {
          this.shopSearchLoading = false;
          this.shopOptions = this.shopList.filter(item => {
            return item.name.toLowerCase().includes(query.toLowerCase())
              || item.location.toLowerCase().includes(query.toLowerCase());
          });
        }, 200);
      } else {
        this.shopOptions = [];
      }
    }
  }
};
</script>