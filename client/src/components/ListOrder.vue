<template>
  <div style="height: 720px;">
    <h1>ORDER LIST</h1>
    <div v-if="data && data.length > 0">
      <el-table :data="data" v-loading="loading" stripe @sort-change="sortChange" :default-sort="{
        prop: 'id',
        order: 'descending' }">
        <el-table-column type="expand">
          <template slot-scope="props">
            <div v-if="props.row.items && props.row.items.length > 0" style="margin-left: 50px;">
              <el-table size="mini" :data="props.row.items">
                <el-table-column label="Product">
                  <template slot-scope="scope">
                    <span style="margin-left: 10px;font-style: italic;">{{ scope.row.productName }}</span>
                  </template>
                </el-table-column>
                <el-table-column label="Quantity">
                  <template slot-scope="scope">
                    <el-tag size="small">{{ scope.row.quantity
                    }} items</el-tag>
                  </template>
                </el-table-column>
                <el-table-column label="Unit price">
                  <template slot-scope="scope">
                    <el-tag size="small">{{ scope.row.unitPrice
                    }} đ</el-tag>
                  </template>
                </el-table-column>
              </el-table>
            </div>
            <el-empty v-else description="Empty product"></el-empty>
          </template>
        </el-table-column>
        <el-table-column prop="id" label="ID" width="60" sortable>
        </el-table-column>
        <el-table-column prop="customerName" label="Customer">
          <template slot-scope="scope">
            <el-tag type="default" size="small">{{ scope.row.customerName
            }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="shopName" label="Shop">
          <template slot-scope="scope">
            <el-tag type="warning" size="small">{{ scope.row.shopName
            }}</el-tag>
          </template>
        </el-table-column>
        <el-table-column prop="total" label="Total">
          <template slot-scope="scope">
            <el-tag type="success" size="small">{{ scope.row.total
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
      sortBy: 'id',
      sortOrder: 'descending'
    }
  },
  created() {
    this.fetch(this.pageNumber, this.pageSize, this.sortBy, this.sortOrder);
  },
  methods: {
    async fetch(newPage, newSize, sortColumn, sortOrder) {
      this.loading = true;
      var path = `/orders?page=${newPage}&pageSize=${newSize}`;

      if(sortColumn)
        path = `${path}&orderBy=${sortColumn}`
      if(sortOrder)
        path = `${path}&orderDirection=${sortOrder}`

      var res = await this.$axios.get(path);
      if (res.status == 200) {
        this.data = res.data.pagedData;
        this.total = res.data.filteredCount;
        this.pageNumber = newPage;
        this.pageSize = newSize;
        this.loading = false;
        this.sortBy = sortColumn;
        this.sortOrder = sortOrder;
      }
    },
    changePage(newPage) {
      this.fetch(newPage, this.pageSize, this.sortBy, this.sortOrder)
    },
    sizeChange(newSize) {
      this.fetch(this.pageNumber, newSize, this.sortBy, this.sortOrder)
    },
    sortChange({ prop, order }){
      this.fetch(this.pageNumber, this.pageSize, prop, order);
    }
  }
};
</script>