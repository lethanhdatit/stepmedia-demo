<template>
  <div style="height: 720px;">
    <h1>NEW ORDER</h1>
    <el-card class="box-card">
      <el-form :model="newOrderForm" status-icon :rules="rules" ref="newOrderForm" class="demo-newOrderForm"
        style="margin-left: 20px;">
        <el-form-item label="Customer:" prop="customerId" required>
          <el-select autocomplete="off" style="width: 100%;" v-loading="customerSearchLoading" v-model="newOrderForm.customerId" filterable
            remote reserve-keyword placeholder="Please enter a keyword" :remote-method="customerRemoteMethod"
            :loading="customerSearchLoading">
            <el-option v-for="item in customerOptions" :key="item.id" :label="item.fullName + ' - ' + item.email"
              :value="item.id">
            </el-option>
          </el-select>
        </el-form-item>

        <el-form-item label="Shop:" prop="shopId" required>
          <el-select autocomplete="off" @change="onShopChange" style="width: 100%;" v-loading="shopSearchLoading" v-model="newOrderForm.shopId" filterable remote
            reserve-keyword placeholder="Please enter a keyword" :remote-method="shopRemoteMethod"
            :loading="shopSearchLoading">
            <el-option v-for="item in shopOptions" :key="item.id" :label="item.name + ' - ' + item.location"
              :value="item.id">
            </el-option>
          </el-select>
        </el-form-item>

        <el-form-item label="Product:" prop="items">
          <el-select autocomplete="off" :disabled="!this.newOrderForm.shopId" style="width: 100%;" v-loading="productSearchLoading" v-model="newOrderForm.productId" filterable
            remote reserve-keyword placeholder="Please enter a keyword" :remote-method="productRemoteMethod"
            :loading="productSearchLoading">
            <el-option v-for="item in productOptions" :key="item.id" :label="item.name + ' - ' + item.unitPrice + 'đ'"
              :value="item.id">
            </el-option>
          </el-select>
        </el-form-item>
        <div v-for="(item, index) in newOrderForm.items" :key="item.productId">
          <el-form-item :label="(index + 1) + ')'" :key="item.productId" :prop="'items.' + index + '.quantity'" required
            :rules="[{ required: true, message: 'Please enter quantity', trigger: 'blur' },
            { type: 'number', message: 'Quantity must be a number' }]">
            <el-col :span="9">
              <el-tag size="medium" type="success">{{ getProductName(item.productId) }}</el-tag>
            </el-col>
            <el-col :span="1">
              <span>x</span>
            </el-col>
            <el-col class="line" :span="2">
              <el-input size="mini" v-model.number="item.quantity" autocomplete="off"></el-input>
            </el-col>
            <el-col :span="1">
              <span type="warning">items</span>
            </el-col>
            <el-col :span="1">
              <el-button size="mini" @click.prevent="removeProduct(item)" type="danger" icon="el-icon-delete"
                circle></el-button>
            </el-col>
          </el-form-item>
        </div>

        <el-form-item>
          <el-button v-show="newOrderForm.productId && !this.isExistedProduct(newOrderForm.productId)"
            @click="addProduct">Add more</el-button>
          <el-button type="primary" @click="submitForm('newOrderForm')">Submit</el-button>
          <el-button @click="resetForm('newOrderForm')">Clear All</el-button>
        </el-form-item>
      </el-form>
    </el-card>

  </div>
</template>

<script>

export default {
  data() {
    var validateCustomer = (rule, value, callback) => {
      if (value <= 0) {
        callback(new Error('Please input the customer'));
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
    var validateItems = (rule, value, callback) => {
      if (value.length <= 0) {
        callback(new Error('Please add product'));
      } else {
        callback();
      }
    };

    return {
      customerList: [],
      customerOptions: [],
      customerSearchLoading: false,

      shopList: [],
      shopOptions: [],
      shopSearchLoading: false,

      productList: [],
      productOptions: [],
      productSearchLoading: false,

      newOrderForm: {
        customerId: null,
        shopId: null,
        productId: null,
        items: [],
      },
      rules: {
        customerId: [
          { validator: validateCustomer, trigger: 'blur' }
        ],
        shopId: [
          { validator: validateShop, trigger: 'blur' }
        ],
        items: [
          { validator: validateItems, trigger: 'blur' }
        ],
      },
    };
  },
  created() {
    this.fetch();
  },
  methods: {
    async fetch() {
      this.$axios.get('/customers').then(res => {
        if (res.status == 200) {
          this.customerList = res.data.pagedData
        }
      });
      this.$axios.get('/shops').then(res => {
        if (res.status == 200) {
          this.shopList = res.data.pagedData
        }
      });
      if (this.newOrderForm.shopId) {
        this.$axios.get(`/products?shopId=${this.newOrderForm.shopId}`).then(res => {
          if (res.status == 200) {
            this.productList = res.data.pagedData
          }
        });
      }
    },
    submitForm(formName) {
      this.$refs[formName].validate((valid) => {
        if (valid) {
          this.$confirm('Create new order now?', 'Warning', {
            confirmButtonText: 'OK',
            cancelButtonText: 'Cancel',
            type: 'warning'
          }).then(async () => {
            var res = await this.$axios.post('/orders', this.newOrderForm);
            if (res.status == 200 && res.data.status === 'success') {
              this.$message({
                type: 'success',
                message: 'Created!'
              });
              this.$router.push('/orders');
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
    customerRemoteMethod(query) {
      if (query !== '') {
        this.customerSearchLoading = true;
        setTimeout(() => {
          this.customerSearchLoading = false;
          this.customerOptions = this.customerList.filter(item => {
            return item.fullName.toLowerCase().includes(query.toLowerCase())
              || item.email.toLowerCase().includes(query.toLowerCase());
          });
        }, 200);
      } else {
        this.customerOptions = [];
      }
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
    },
    productRemoteMethod(query) {
      if (query !== '') {
        this.productSearchLoading = true;
        setTimeout(() => {
          this.productSearchLoading = false;
          this.productOptions = this.productList.filter(item => {
            return item.name.toLowerCase().includes(query.toLowerCase());
          });
        }, 200);
      } else {
        this.productOptions = [];
      }
    },
    removeProduct(item) {
      var index = this.newOrderForm.items.indexOf(item);
      if (index !== -1) {
        this.newOrderForm.items.splice(index, 1);
      }
    },
    addProduct() {
      if (this.newOrderForm.productId && !this.isExistedProduct(this.newOrderForm.productId)) {
        var item = this.productList.find(f => f.id == this.newOrderForm.productId);
        this.newOrderForm.items.push({
          key: Date.now(),
          productId: this.newOrderForm.productId,
          unitPrice: item.unitPrice,
          quantity: null,
        });
        this.newOrderForm.productId = null;
      }
    },
    isExistedProduct(productId) {
      return this.newOrderForm.items?.some(s => s.productId == productId) == true
    },
    getProductName(id) {
      var item = this.productList.find(f => f.id == id);
      return item ? item.name + ' - ' + item.unitPrice + 'đ' : 'error'
    },
    onShopChange(shopId) {
      this.$axios.get(`/products?shopId=${shopId}`).then(res => {
        if (res.status == 200) {
          this.productList = res.data.pagedData
        }
      });
    }
  }
};
</script>