<template>
  <div class="content">
    <!-- header content -->
    <div class="content__header flex items-center">
      <p class="content__header--title">Nhân viên</p>
      <button class="m-btn" id="btnAdd" @click="onAddEmployee">
        Thêm nhân viên
      </button>
    </div>

    <!-- filter -->
    <div class="grid-filter flex items-center sticky-left">
      <div class="search flex items-center">
        <input
          type="text"
          class="m-input"
          placeholder="Tìm theo mã, tên nhân viên"
        />
        <div class="icon-search mi-16"></div>
      </div>
      <button class="reload mi-24"></button>
    </div>

    <div class="content__grid">
      <!-- <div class="content__grid--data"> -->
      <!-- grid -->
      <table border="0" cellspacing="0" width="100%" id="tblEmployees">
        <thead>
          <th class="td-left-16"></th>
          <th class="sticky-left left-16">
            <input
              type="checkbox"
              name=""
              id=""
              class="right-5"
              @click="selectAll"
              ref="selectAll"
            />
          </th>
          <th class="sticky-left left-66">Mã nhân viên</th>
          <th>Tên nhân viên</th>
          <th>Giới tính</th>
          <th class="text-center">Ngày sinh</th>
          <th>Số CMND</th>
          <th>Chức danh</th>
          <th>Tên đơn vị</th>
          <th>Số tài khoản</th>
          <th class="text-right">Tên ngân hàng</th>
          <th>Chi nhánh tài khoản ngân hàng</th>
          <th class="sticky-right">Chức năng</th>
          <th class="td-white-30"></th>
          <th class="td-grey-30"></th>
        </thead>
        <tbody>
          <tr
            v-for="(item, index) in dataEmployee"
            :key="index"
            @dblclick="rowdblClick(item)"
          >
            <td class="td-left-16"></td>
            <!-- checkbox -->
            <td
              class="sticky-left left-16"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              <input
                type="checkbox"
                name=""
                id=""
                class="right-5"
                @click="highlight(item.EmployeeId, $event)"
                :checked="selectedUser.indexOf(item.EmployeeId) != -1"
              />
            </td>
            <!-- Mã NV -->
            <td
              :title="item.EmployeeCode"
              class="sticky-left left-66"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.EmployeeCode }}
            </td>
            <!-- Tên NV -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.EmployeeName }}
            </td>
            <!-- Giới tính -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.GenderName }}
            </td>
            <!-- Ngày sinh -->
            <td
              class="text-center"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ $fn.fnFormatDate(item.DateOfBirth) }}
            </td>
            <!-- Số CMND -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.IdentityNumber }}
            </td>
            <!-- Chức danh -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.EmployeePosition }}
            </td>
            <!-- Tên đơn vị -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            ></td>
            <!-- Số tài khoản -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.BankAccountNumber }}
            </td>
            <!-- Tên ngân hàng -->
            <td
              class="text-right"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.BankName }}
            </td>
            <!-- Chi nhánh tài khoản ngân hàng -->
            <td
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              {{ item.BankProvinceName }}
            </td>
            <!--Chức năng -->
            <td
              class="sticky-right"
              @click="onDeleteEmployee(item.EmployeeId)"
              :class="{
                selected: selectedUser.indexOf(item.EmployeeId) != -1,
              }"
            >
              Sửa
            </td>
            <td class="td-white-30"></td>
            <td class="td-grey-30"></td>
          </tr>
        </tbody>
      </table>

      <div class="pagination items-center">
        <div class="total-record">
          Tổng số: 20 bản ghi
        </div>
        <div class="select flex items-center">
          <select name="" id="">
            <option value="10">10 bản ghi trên 1 trang</option>
            <option value="20">20 bản ghi trên 1 trang</option>
            <option value="30">30 bản ghi trên 1 trang</option>
            <option value="40">40 bản ghi trên 1 trang</option>
            <option value="50">50 bản ghi trên 1 trang</option>
          </select>
          <button class="btn-previous mr-4">Trước</button>
          <div class="page flex">
            <div class="page-number page-active">1</div>
            <div class="page-number">2</div>
          </div>
          <button class="btn-next ml-4">Sau</button>
        </div>
      </div>
      <!-- </div> -->
    </div>
    <Detail :employee="dataRow" :department="department" :title="title"/>
  </div>
</template>

<script>
import axios from "axios";
import Detail from "./EmployeeDetail";

export default {
  components: {
    Detail,
  },
  computed: {
    sortedEmployees: function() {
      return [...this.dataEmployee].sort((a, b) => {
        let modifier = 1;
        if (this.currentSortDir === "desc") modifier = -1;
        if (a[this.currentSort] < b[this.currentSort]) return -1 * modifier;
        if (a[this.currentSort] > b[this.currentSort]) return 1 * modifier;
        return 0;
      });
    },
  },
  data() {
    return {
      API_HOST: this.$Const.API_HOST,
      dataEmployee: [],
      selectedUser: [],
      dataRow: {},
      department: [],
      title:""
    };
  },
  methods: {
    /**
     * Lấy dữ liệu nhân viên
     * CreatedBy:ntquan(13/05/2021)
     */
    onLoadEmployee() {
      var me = this;
      var url =
        me.API_HOST + "/api/v1/Employees/paging?pageIndex=1&pageSize=25";
      axios
        .get(url)
        .then((response) => {
          me.dataEmployee = response.data;
          console.log(me.dataEmployee);
        })
        .catch((err) => {
          console.log(err);
        });
    },

    /**
     * Lấy mã nhân viên mới
     * CreatedBy:ntquan(13/05/2021)
     */
    async genEmployeeCode() {
      let url = this.API_HOST + "/api/v1/Employees/NewEmployeeCode";
      var response = await axios.get(url);
      return response.data;
    },

    /**
     * Hiển thị thêm mới nhân viên
     * CreatedBy:ntquan(13/05/2021)
     */
    async onAddEmployee() {
      var me= this;
      me.dataRow.EmployeeCode= await me.genEmployeeCode();
      me.title = "Thêm mới nhân viên";
      this.$store.commit("toggleDialog");
    },

    /**
     * Lấy danh sách phòng ban
     *
     */
    async getDepartment() {
      var me = this;
      let url = `${me.API_HOST}/api/v1/Departments`;
      const response = await axios.get(url);
      me.department=response.data
    },
    /**
     * Hiển thị thông tin nhân viên
     * CreatedBy:ntquan(13/05/2021)
     */
    async rowdblClick(item) {
      var me = this;
      var res= await me.onGetEmployeeById(item.EmployeeId);
      if (res.DateOfBirth != null)
        res.DateOfBirth = me.$fn.fnFormatDateInput(res.DateOfBirth);
      if (res.IdentityDate != null)
        res.IdentityDate = me.$fn.fnFormatDateInput(item.IdentityDate);
      me.dataRow = res;
      me.title = "THÔNG TIN NHÂN VIÊN";
      this.$store.commit("toggleDialog");
      console.log(this.$fn.cloneObject(res));
    },

    async onGetEmployeeById(id) {
      var me= this;
      const url=`${me.API_HOST}/api/v1/Employees/${id}`;
      const response=await axios.get(url);
      return response.data
    },
    /**
     * Thay đổi background row
     * @param id Id nhân viên
     * CreatedBy:ntquan(13/05/2021)
     */
    highlight(id) {
      var me = this;
      var elIndex = me.selectedUser.indexOf(id);
      var countEmployee = me.dataEmployee.length;
      var countSelectedUser =
        me.selectedUser.indexOf("All") != -1
          ? me.selectedUser.length - 1
          : me.selectedUser.length;
      if (elIndex != -1) {
        me.selectedUser = me.selectedUser.filter(function(e) {
          return e !== id && e != "All";
        });
        this.$refs.selectAll.checked = false;
      } else {
        me.selectedUser.push(id);
        if (countSelectedUser + 1 == countEmployee) {
          me.selectedUser.push("All");
          this.$refs.selectAll.checked = true;
        }
      }
    },

    /**
     * Thay đổi background tất cả row
     * CreatedBy:ntquan(13/05/2021)
     */
    selectAll() {
      var me = this;
      if (me.selectedUser.indexOf("All") != -1) {
        me.selectedUser = [];
      } else {
        me.selectedUser = [];
        me.dataEmployee.forEach((element) => {
          me.selectedUser.push(element.EmployeeId);
        });
        me.selectedUser.push("All");
      }
    },
  },

  created() {
    this.onLoadEmployee();
    this.getDepartment()
  },
  mounted() {},
};
</script>

<style>
.content {
  overflow: scroll;
  flex-direction: column;
}
.content .content__header {
  justify-content: space-between;
  left: 0;
  width: 100%;
  padding: 22px 0px 16px 0px;
  position: sticky;
  top: 0;
  z-index: 10;
  background-color: #f4f5f6;
}

.content .content__header .content__header--title {
  font-size: 24px;
  font-weight: 700;
}

.content .content__grid {
  min-width: 100%;
  /* height: 100%; */
  background-color: #ffffff;
}

.content .grid-filter {
  justify-content: flex-end;
  padding: 16px 16px 10px;
  background-color: #ffffff;
}

.content .grid-filter .search {
  position: relative;
  width: 250px;
}

.content .grid-filter .search input {
  width: 240px;
}

.content .grid-filter .search .icon-search {
  position: absolute;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -992px -360px;
  cursor: pointer;
  top: 6px;
  left: 87%;
}

.content .grid-filter .reload {
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -423px -201px;
  border: none;
  cursor: pointer;
}

.content .pagination {
  position: absolute;
  bottom: 10px;
  z-index: 6;
  background-color: #fff;
  display: flex;
  min-height: 47px;
  padding-left: 16px;
  padding-right: 30px;
  width: 93%;
  justify-content: space-between;
}

.content .pagination .select {
  justify-content: space-between;
}

.content .pagination .select select {
  margin: 0 16px;
  width: 200px;
  min-width: 200px;
}

.right-5 {
  right: 5px;
}

table {
  display: grid;
  min-width: 100%;
  width: calc(100% + 500px);
  grid-template-columns:
    minmax(16px, 16px) minmax(40px, 40px)
    minmax(130px, 1fr) minmax(200px, 1.67fr) minmax(100px, 0.5fr)
    minmax(130px, 1fr) minmax(130px, 2fr) minmax(150px, 1.67fr) minmax(
      150px,
      3.33fr
    )
    minmax(150px, 1.67fr) minmax(150px, 1.67fr) minmax(150px, 1.67fr) minmax(
      130px,
      1fr
    )
    minmax(30px, 30px) minmax(30px, 30px);
}
thead,
tbody,
tr {
  display: contents;
  width: 100%;
}
table th,
td {
  border-bottom: 1px solid #e8e8e8;
  padding: 15px 16px;
  text-align: left;
  /* overflow: hidden;
  text-overflow: ellipsis;*/
  white-space: nowrap;
}

td.sticky-right {
  border-left: 1px dotted #c7c7c7;
}

td {
  background-color: #fff;
  border-bottom: 1px solid #c7c7c7;
  border-right: 1px dotted #c7c7c7;
}

th.sticky-right {
  border-left: 1px solid #c7c7c7;
  background: #eceef1 !important;
  z-index: 5;
}

th.sticky-left {
  background: #eceef1 !important;
  z-index: 5;
}

th {
  position: sticky;
  top: 72px;
  background-color: #ffffff;
  padding: 5px 10px 3px;
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background: #eceef1;
}
/* tr:nth-child(even) td {
  background: #f6f6f6;
} */
td:last-child {
  display: flex;
  justify-content: center;
  cursor: pointer;
}
tr:hover > td:not(:first-child, :last-child, :nth-child(14), .selected) {
  background: #f3f8f8 !important;
}
</style>
