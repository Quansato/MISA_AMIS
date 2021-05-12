<template>
  <div class="content">
    <!-- header content -->
    <div class="content__header flex items-center">
      <p class="content__header--title">Nhân viên</p>
      <button class="m-btn" id="btnAdd">
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
      <div class="content__grid--data">
        <!-- grid -->
        <table border="0" cellspacing="0" width="100%" id="tblEmployees">
          <thead>
            <th class="td-left-16"></th>
            <th class="sticky-left left-16">
              <input type="checkbox" name="" id="" />
            </th>
            <th class="sticky-left left-66">Mã nhân viên</th>
            <th>Tên nhân viên</th>
            <th>Giới tính</th>
            <th class="text-right">Ngày sinh</th>
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
              @click="highlight($event, index)"
              @dblclick="rowdblClick(item)"
            >
              <td class="td-left-16"></td>
              <td class="sticky-left left-16">
                <input type="checkbox" name="" id="" />
              </td>
              <td :title="item.EmployeeCode" class="sticky-left left-66">
                {{ item.EmployeeCode }}
              </td>
              <td>{{ item.EmployeeName }}</td>
              <td>{{ item.Gender }}</td>
              <td class="text-right">
                {{ $fn.fnFormatDate(item.DateOfBirth) }}
              </td>
              <td>{{ item.IdentityNumber }}</td>
              <td>{{ item.EmployeePosition }}</td>
              <td></td>
              <td>{{ item.BankAccountNumber }}</td>
              <td class="text-right">
                {{ item.BankName }}
              </td>
              <td>{{ item.BankProvinceName }}</td>
              <td
                class="sticky-right"
                @click="onDeleteEmployee(item.EmployeeId)"
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
            Tổng số:
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  data() {
    return {
      dataEmployee: [],
    };
  },
  methods: {
    onLoadEmployee() {
      var me = this;
      var url = this.$Const.API_HOST + "/api/v1/Employees";
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
  },
  created() {
    this.onLoadEmployee();
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
  width: 100%;
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

.content .content__grid--data .grid-filter .search .icon-search {
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

.content .content__grid--data .pagination {
  position: sticky;
  bottom: 0;
  z-index: 4;
  background-color: #fff;
  display: flex;
  min-height: 47px;
  padding-left: 16px;
}

table {
  display: grid;
  min-width: 100%;
  grid-template-columns:
    minmax(16px, 16px) minmax(50px, 1fr)
    minmax(130px, 1fr) minmax(150px, 1.67fr) minmax(100px, 0.5fr)
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
  background-color: #eceef1 !important;
  z-index: 5;
}

th.sticky-left {
  background-color: #eceef1 !important;
  z-index: 5;
}

th {
  position: sticky;
  top: 72px;
  background-color: #ffffff;
  padding: 5px 10px 3px;
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #eceef1;
}
/* tr:nth-child(even) td {
  background: #f6f6f6;
} */
td:last-child {
  display: flex;
  justify-content: center;
  cursor: pointer;
}
tr:hover > td {
  background-color: #ca99c617;
}

tr:hover > td.sticky-left {
  z-index: 5;
}
</style>
