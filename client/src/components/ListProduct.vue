<template>
  <div style="height: 720px;">
    <h1>PRODUCT LIST</h1>
    <el-input @input="onSearch" placeholder="Type to search server side" v-model="search" clearable>
    </el-input>
    <div v-if="data && data.length > 0">
      <el-table :data="data" v-loading="loading" stripe @sort-change="sortChange" :default-sort="{
        prop: 'unitPrice',
        order: 'descending' }">
        <el-table-column prop="id" label="ID" width="60" sortable>
        </el-table-column>
        <el-table-column prop="name" label="Product Name">
          <template slot-scope="scope">
            <el-tag type="default" size="small">{{ scope.row.name
            }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="shopName" label="Shop Name">
          <template slot-scope="scope">
            <el-tag type="warning" size="small">{{ scope.row.shopName
            }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="unitPrice" label="Unit Price" sortable>
          <template slot-scope="scope">
            <el-tag type="success" size="small">{{ scope.row.unitPrice
            }} đ</el-tag>
          </template>
        </el-table-column>
      </el-table>
      <el-pagination style="margin-top: 10px;" background layout="sizes, prev, pager, next, total" :total="total"
        :page-size="pageSize" :page-sizes="[10, 15, 20, 25, 30]" @current-change="changePage" @size-change="sizeChange">
      </el-pagination>
    </div>
    <el-empty v-else description="No records found!"></el-empty>
  </div>
</template>

<script>

export default {
  data() {
    return {
      data: [],
      total: 0,
      pageNumber: 1,
      pageSize: 10,
      loading: false,
      search: '',
      sortBy: 'unitPrice',
      sortOrder: 'descending'
    }
  },
  created() {
    this.fetch(this.pageNumber, this.pageSize, this.sortBy, this.sortOrder, this.search);
  },
  methods: {
    async fetch(newPage, newSize, sortColumn, sortOrder, search) {
      this.loading = true;
      var path = `/products?page=${newPage}&pageSize=${newSize}`;

      if (sortColumn)
        path = `${path}&orderBy=${sortColumn}`
      if (sortOrder)
        path = `${path}&orderDirection=${sortOrder}`
      if (search)
        path = `${path}&search=${search}`

      var res = await this.$axios.get(path);
      if (res.status == 200) {
        this.data = res.data.pagedData;
        this.total = res.data.filteredCount;
        this.pageNumber = newPage;
        this.pageSize = newSize;
        this.loading = false;
        this.sortBy = sortColumn;
        this.sortOrder = sortOrder;
        if (res.data.totalCount < 30) {
          this.$alert('Not enough data, 30 products as minimum', 'Warning', {
            confirmButtonText: 'OK',
            type: 'warning',
          });
        }
      }
    },
    changePage(newPage) {
      this.fetch(newPage, this.pageSize, this.sortBy, this.sortOrder, this.search)
    },
    sizeChange(newSize) {
      this.fetch(this.pageNumber, newSize, this.sortBy, this.sortOrder, this.search)
    },
    sortChange({ prop, order }) {
      this.fetch(this.pageNumber, this.pageSize, prop, order, this.search);
    },
    onSearch(value) {
      this.fetch(this.pageNumber, this.pageSize, this.sortBy, this.sortOrder, value);
    }
  }
};
</script>