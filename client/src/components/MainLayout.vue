<template>
  <div>
    <el-header>
      <el-row>
        <el-col :span="12"
          style="text-align: left;font-size: 28px;font-weight: bold;color: #eee;text-decoration-line:underline;text-decoration-style:wavy">
          <span>Stepmedia</span>
        </el-col>
        <el-col :span="12" style="text-align: right; font-size: 18px;color: #eee;font-style: oblique;">
          <span>Small demonstration</span>
        </el-col>
      </el-row>
    </el-header>
    <el-container style="border: 0px solid #eee">
      <el-aside width="63px">
        <el-menu :router="true" default-active="/orders" :collapse="true" background-color="#545c64" text-color="#fff"
          active-text-color="#ffd04b">
          <el-submenu index="1">
            <template slot="title">
              <i class="el-icon-s-order"></i>
              <span slot="title">Orders</span>
            </template>
            <el-menu-item-group>
              <span slot="title">Manage orders:</span>
              <el-menu-item index="/orders"><i class="el-icon-notebook-2"></i>List</el-menu-item>
              <el-menu-item index="/new-order"><i class="el-icon-circle-plus-outline"></i>New</el-menu-item>
            </el-menu-item-group>
          </el-submenu>
          <el-submenu index="2">
            <template slot="title">
              <i class="el-icon-s-cooperation"></i>
              <span slot="title">Products</span>
            </template>
            <el-menu-item-group>
              <span slot="title">Manage products:</span>
              <el-menu-item index="/products"><i class="el-icon-notebook-2"></i>List</el-menu-item>
              <el-menu-item index="/new-product"><i class="el-icon-circle-plus-outline"></i>New</el-menu-item>
            </el-menu-item-group>
          </el-submenu>
          <el-submenu index="3">
            <template slot="title">
              <i class="el-icon-s-custom"></i>
              <span slot="title">Customers</span>
            </template>
            <el-menu-item-group>
              <span slot="title">Manage customers:</span>
              <el-menu-item index="/customers"><i class="el-icon-notebook-2"></i>List</el-menu-item>
              <el-menu-item index="/new-customer"><i class="el-icon-circle-plus-outline"></i>New</el-menu-item>
            </el-menu-item-group>
          </el-submenu>
          <el-submenu index="4">
            <template slot="title">
              <i class="el-icon-s-shop"></i>
              <span slot="title">Shops</span>
            </template>
            <el-menu-item-group>
              <span slot="title">Manage shops:</span>
              <el-menu-item index="/shops"><i class="el-icon-notebook-2"></i>List</el-menu-item>
              <el-menu-item index="/new-shop"><i class="el-icon-circle-plus-outline"></i>New</el-menu-item>
            </el-menu-item-group>
          </el-submenu>
        </el-menu>
      </el-aside>

      <el-container>
        <el-main style="background-color: #ffff;">
          <router-view />
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>

export default {
  computed: {},
  mounted() { },
};
</script>

<style scoped>
.el-header {
  background-color: rgba(0, 0, 0, .77);
  color: #333;
  line-height: 60px;
}

.el-aside {
  color: #333;
  background-color: rgba(0, 0, 0, .77);
  overflow-x: hidden;
}
</style>
