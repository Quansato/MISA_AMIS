<template>
  <div class="dialog" id="dlgEmployee" v-if="isShow">
    <div
      class="dialog-content"
      ref="modal"
      @mousedown="$fn.startMoving($refs['modal'], 'dlgEmployee', $event)"
      @mouseup="$fn.stopMoving($refs['modal'])"
    >
      <div class="dialog-header">
        <div class="dialog-title flex items-center">
          {{ title }}
          <div class="ms-checkbox flex items-center">
            <input type="checkbox" name="" id="" />
            <span class="tooltip-content mt-2">Là khách hàng</span>
          </div>

          <div class="ms-checkbox flex item-center mt-4">
            <input type="checkbox" name="" id="" />
            <span class="tooltip-content">Là nhà cung cấp</span>
          </div>
        </div>
        <div class="btn-header flex">
          <div
            class="dialog-help-button"
            @click="onClose"
            title="Trợ giúp"
          ></div>
          <div
            class="dialog-close-button"
            @click="onClose"
            title="Đóng(Esc)"
          ></div>
        </div>
      </div>
      <div class="dialog-body flex flex-column">
        <div class="flex pd-b-12">
          <div class="p-r-26 flex-1">
            <!-- row -->
            <div class="m-row">
              <!-- Mã -->
              <div class="m-item-input w-2/5 p-r-6">
                <label for="EmployeeCode" class="m-label"
                  >Mã<span class="required"> * </span></label
                >
                <input
                  type="text"
                  class="m-input"
                  ref="EmployeeCode"
                  v-model="employee.EmployeeCode"
                  @blur="
                    checkBlankText([
                      { key: 'EmployeeCode', text: 'Mã không được để trống' },
                    ])
                  "
                />
              </div>
              <!-- Tên -->
              <div class="m-item-input w-3/5">
                <label for="" class="m-label"
                  >Tên<span class="required"> * </span></label
                >
                <input
                  type="text"
                  class="m-input"
                  ref="EmployeeName"
                  v-model="employee.EmployeeName"
                  @blur="
                    checkBlankText([
                      { key: 'EmployeeName', text: 'Tên không được để trống' },
                    ])
                  "
                />
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Đơn vị -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label"
                  >Đơn vị<span class="required"> * </span></label
                >
                <select
                  class="m-select"
                  v-model="employee.DepartmentId"
                  ref="Department"
                  @blur="
                    checkBlankText([
                      { key: 'Department', text: 'Đơn vị không được để trống' },
                    ])
                  "
                >
                  <option
                    v-for="(item, index) in department"
                    :value="item.DepartmentId"
                    :key="item.DepartmentId"
                    :selected="index == 1"
                  >
                    {{ item.DepartmentName }}
                  </option>
                </select>
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Chức danh -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label">Chức danh</label>
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.EmployeePosition"
                />
              </div>
            </div>
          </div>

          <div class="flex-1">
            <!-- row -->
            <div class="m-row">
              <!-- Ngày sinh -->
              <div class="m-item-input w-1\/2 p-r-6">
                <label for="" class="m-label">Ngày sinh</label>
                <input
                  type="date"
                  class="m-input"
                  v-model="employee.DateOfBirth"
                />
              </div>
              <!-- Giới tính -->
              <div class="p-t-5 flex items-center">
                <div class="m-item-input .w-1/2 p-r-6">
                  <label class="m-label">Giới tính</label>
                  <div class="group-gender">
                    <input
                      type="radio"
                      name="gender"
                      value="1"
                      v-model="employee.Gender"
                      class="ml-4"
                    />
                    <span class="ml-4">Nam</span>
                    <input
                      type="radio"
                      name="gender"
                      value="0"
                      v-model="employee.Gender"
                      class="ml-4"
                    />
                    <span class="ml-4">Nữ</span>
                  </div>
                </div>
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Số CMND -->
              <div class="m-item-input flex-4 p-r-6">
                <label for="" class="m-label">Số CMND</label>
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.IdentityNumber"
                />
              </div>
              <!-- Ngày cấp -->
              <div class="m-item-input">
                <label for="" class="m-label">Ngày cấp</label>
                <input
                  type="date"
                  class="m-input"
                  v-model="employee.IdentityDate"
                />
              </div>
            </div>

            <!-- row -->
            <div class="m-row">
              <!-- Nơi cấp -->
              <div class="m-item-input flex-1">
                <label for="" class="m-label">Nơi cấp</label>
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.IdentityPlace"
                />
              </div>
            </div>
          </div>
        </div>

        <div class="flex flex-column p-t-10">
          <div class="m-row">
            <!-- Địa chỉ -->
            <div class="m-item-input flex-1">
              <label for="" class="m-label">Địa chỉ</label>
              <input type="text" class="m-input" v-model="employee.Address" />
            </div>
          </div>

          <!--row-->
          <div class="m-row">
            <!-- ĐT di động -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">ĐT di động</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.PhoneNumber"
              />
            </div>
            <!-- ĐT cố định -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">ĐT cố định</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.TelephoneNumber"
              />
            </div>
            <!-- Email -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Email</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.Email"
                ref="Email"
              />
            </div>
          </div>

          <!--row-->
          <div class="m-row">
            <!-- Tài khoản ngân hàng -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Tài khoản ngân hàng</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.BankAccountNumber"
              />
            </div>
            <!-- Tên ngân hàng -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Tên ngân hàng</label>
              <input type="text" class="m-input" v-model="employee.BankName" />
            </div>
            <!-- Chi nhánh -->
            <div class="m-item-input .w-1/4 p-r-6">
              <label for="" class="m-label">Chi nhánh</label>
              <input
                type="text"
                class="m-input"
                v-model="employee.BankBranchName"
              />
            </div>
          </div>
        </div>

        <div class="dialog-footer flex flex-column">
          <div class="divide"></div>
          <div class="dialog-footer-button flex flex-1">
            <button class="m-btn-second" @click="onClose">Huỷ</button>
            <div class="flex">
              <button class="m-btn-second m-r-10" @click="onSave">Cất</button>
              <button class="m-btn" @click="onSaveAndNew">Cất và thêm</button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <!--  -->
    <Alert :isShow="isShowAlert" :message="messageAlert" :cls="iconCls">
      <div class="flex w-full justify-center">
        <button class="m-btn" @click="onCloseAlert">Đóng</button>
      </div>
    </Alert>
    <!--  -->

    <AlertConfirm
      :isShow="isShowAlertConfirm"
      :message="messageAlert"
      :cls="iconCls"
    >
      <div class="flex w-full justify-between">
        <button class="m-btn-second" @click="onClose">Đóng</button>
        <button class="m-btn">Đồng ý</button>
      </div>
    </AlertConfirm>
  </div>
</template>

<script>
import axios from "axios";
import Alert from "../../components/Alert/Alert";
import AlertConfirm from "../../components/Alert/Alert";
import Vue from "vue";

export default {
  name: "Detail",
  components: {
    Alert,
    AlertConfirm,
  },
  props: ["employee", "department", "title"],
  data() {
    return {
      // isShow:,
      isShowAlert: false,
      isShowAlertConfirm: false,
      messageAlert: "",
      iconCls: "",
      API_HOST: this.$Const.API_HOST,
      dataEmployee: [],
    };
  },
  methods: {
    onLoadEmployee() {
      this.$emit("onLoad");
    },
    onSave() {
      this.fnSave();
    },

    onSaveAndNew() {
      this.isShowAlertConfirm = true;
      this.messageAlert = "Tên nhân viên không được để trống";
      this.iconCls = "icon-warning-alert";
    },

    async fnSave() {
      var me = this;
      var countErr = 0;
      var url = "";
      countErr += me.validateToSave();
      if (!me.employee.EmployeeId)
        countErr += await me.checkEmployeeCodeExist(me.employee.EmployeeCode);
      if (countErr != 0) return;
      //

      if (me.employee.EmployeeId) {
        //cập nhật
        url = `${me.API_HOST}/api/v1/Employees?entityId=${me.employee.EmployeeId}`;
        const response = await axios.put(url, me.employee);
        //hiện thông báo
        if (response.status == me.$Const.DATA_UPDATED) {
          console.log("Cập nhật thành công");
          me.onClose();
          me.onLoadEmployee();
        } else {
          console.log("Cập nhật thất bại");
        }
      } else {
        //Thêm mới
        url = `${me.API_HOST}/api/v1/Employees`;
        const response = await axios.post(url, me.employee);
        if (response.status == me.$Const.DATA_CREATED) {
          console.log("Thêm mới thành công");
          me.onClose();
          me.onLoadEmployee();
        } else {
          console.log("Thêm mới thất bại");
        }
      }
    },

    /**
     * Validate dữ liệu để lưu vào Database
     * CreateBy:ntquan(21/04/2021)
     */
    validateToSave() {
      var me = this;
      var isError = 0;
      //kiểm tra các trường rỗng
      var obj = [
        {
          key: "EmployeeName",
          text: "Tên không được để trống",
        },
        {
          key: "EmployeeCode",
          text: "Mã NV không được để trống",
        },
        {
          key: "Department",
          text: "Đơn vị không được để trống",
        },
      ];
      me.checkBlankText(obj);
      //kiểm tra giá trị email hợp lệ
      me.checkEmailValid();
      //me.checkEmployeeCodeExist(me.employee.EmployeeCode);
      if (me.messageAlert != "") {
        me.isShowAlert = true;
        me.iconCls = "icon-error";
        isError += 1;
      }
      return isError;
    },

    /**
     * Check email validate
     */
    checkEmailValid() {
      var me = this;
      var email = me.$refs["Email"].value;
      if (!me.$fn.validateEmail(email) && email != "") {
        me.$refs["Email"].classList.add("isValid");
        me.$refs["Email"].setAttribute("title", "Email không đúng định dạng");
        me.messageAlert +=
          me.messageAlert == "" ? "Email không đúng định dạng" : "";
        me.$refs["Email"].focus();
      } else if (email != "") {
        me.$refs["Email"].classList.remove("isValid");
        me.$refs["Email"].setAttribute("title", "");
      }
    },

    /**
     * Validate Blank
     * @param obj danh sách các trường muốn kiểm tra
     * CreateBy:ntquan(11/05/2021)
     */
    checkBlankText(obj) {
      var me = this;
      obj.forEach((element) => {
        if (me.$refs[element.key].value == "") {
          this.$refs[element.key].classList.add("isValid");
          this.$refs[element.key].setAttribute("title", element.text);
          me.messageAlert += me.messageAlert == "" ? element.text : "";
        } else {
          this.$refs[element.key].classList.remove("isValid");
          this.$refs[element.key].setAttribute("title", "");
        }
      });
    },

    /**
     *
     */
    async checkEmployeeCodeExist(employeeCode) {
      var me = this;
      var isExist = 0;
      var url = `${this.API_HOST}/api/v1/Employees/CheckEmployeeCodeExist?employeeCode=${employeeCode}`;
      var res = await axios.get(url);
      if (res.data) {
        me.messageAlert +=
          me.messageAlert == ""
            ? `Mã nhân viên <${employeeCode}> đã tồn tại trong hệ thống, vui lòng kiểm tra lại`
            : "";
        me.isShowAlert = true;
        me.iconCls = "icon-error";
        isExist += 1;
      }
      return isExist;
    },

    /**
     *
     */
    onCloseAlert() {
      this.isShowAlert = false;
      this.messageAlert = "";
      this.iconCls = "";
    },

    /**
     * Đóng form
     * CreatedBy:ntquan(11/05/2021)
     */
    onClose() {
      this.$store.commit("toggleDialog");
    },
  },
  created() {
    // this.onLoadEmployee();
  },
  mounted() {
    if (this.$refs.EmployeeCode) {
      this.$refs.EmployeeCode.focus();
    }
  },
  watch: {
    show: function() {
      if (self.isShow) {
        let self = this;
        Vue.nextTick().then(function() {
          self.$refs.EmployeeCode.focus();
        });
      }
    },
  },
  computed: {
    isShow() {
      return this.$store.getters.getIsShow;
    },
  },
};
</script>

<style>
.dialog {
  position: fixed;
  top: 0;
  left: 0;
  /* right: 0; */
  /* bottom: 0; */
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  max-height: 100%;
  overflow: auto;
  z-index: 10;
  display: flex;
  justify-content: center;
  align-items: center;
}

.dialog .dialog-content {
  padding: 24px;
  position: absolute;
  min-width: 900px;
  max-width: 900px;
  width: 900px;
  height: 600px;
  background-color: #ffffff;
  padding: 20px 32px;
}

@media screen and (max-height: 860px) {
  /* .dialog .dialog-content {
    top: 0;
  } */
}

.dialog .dialog-header {
  display: flex;
  justify-content: space-between;
  padding-bottom: 20px;
}

.dialog .dialog-title {
  font-size: 24px;
  font-weight: 700;
}

.dialog .dialog-header .btn-header {
  position: absolute;
  top: 0;
  right: 0;
  padding: 12px;
}

.dialog .dialog-close-button {
  background-size: 24px;
  width: 24px;
  height: 24px;
  border-radius: 0 4px 0 4px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -144px -144px;
  cursor: pointer;
}

.dialog .dialog-help-button {
  background-size: 24px;
  width: 24px;
  height: 24px;
  border-radius: 0 4px 0 4px;
  margin-right: 6px;
  background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -89px -144px;
  cursor: pointer;
}

.dialog .dialog-gender {
  height: 32px;
  display: flex;
  align-items: center;
}

.dialog-hide {
  display: none;
}

.dialog .dialog-footer {
  justify-content: space-between;
  width: 100%;
  /* position: absolute;
  display: flex;
  align-items: center;
  bottom: 0;
  background-color: #e5e5e5;
  height: 56px;
  border-radius: 0 0 4px 4px;
  left: 0;
  right: 0; */
}

.dialog .dialog-footer .dialog-footer-button {
  justify-content: space-between;
}

.ms-checkbox {
  padding: 0px 19.5px;
}

span.tooltip-content {
  color: #111111;
  margin-left: 10px;
  font-weight: 100;
}
</style>
