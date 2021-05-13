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
  </div>
</template>

<script>
export default {
  name: "Detail",
  props: ["employee", "department", "title"],
  data() {
    return {
      // isShow:,
      API_HOST: this.$Const.API_HOST,
      dataEmployee: [],
    };
  },
  methods: {
    onSave() {
      this.fnSave();
    },

    onSaveAndNew() {},

    fnSave() {
      var me = this;
      me.validateToSave();
    },

    /**
     * Validate dữ liệu để lưu vào Database
     * CreateBy:ntquan(21/04/2021)
     */
    validateToSave() {
      let err = 0;
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
      err += this.checkBlankText(obj);
      if (err != 0) {
        //this.$toastr.w("Cập nhật đầy đủ thông tin yêu cầu");
      }
      //kiểm tra giá trị email hợp lệ
      const errEmail = this.checkEmailValid();
      if (errEmail != 0) this.$toastr.w("Email sai định dạng");

      err += errEmail;
      return err;
    },

    /**
     * Check email validate
     */
    checkEmailValid() {
      let isValid = 0;
      var email = this.$refs["Email"].value;
      if (!this.$fn.validateEmail(email) && email != "") {
        this.$refs["Email"].classList.add("isValid");
        this.$refs["Email"].setAttribute("title", "Email sai định dạng");
        this.$refs["Email"].focus();
        isValid = 1;
      } else if (email != "") {
        this.$refs["Email"].classList.remove("isValid");
        this.$refs["Email"].setAttribute("title", "");
      }
      return isValid;
    },

    /**
     * Validate Blank
     * @param obj danh sách các trường muốn kiểm tra
     * CreateBy:ntquan(11/05/2021)
     */
    checkBlankText(obj) {
      var me = this;
      var msg = "";
      obj.forEach((element) => {
        if (me.$refs[element.key].value == "") {
          this.$refs[element.key].classList.add("isValid");
          this.$refs[element.key].setAttribute("title", element.text);
          msg += msg == "" ? element.text : "";
        } else {
          this.$refs[element.key].classList.remove("isValid");
          this.$refs[element.key].setAttribute("title", "");
        }
      });
      console.log(msg);
    },

    onClose() {
      this.$store.commit("toggleDialog");
    },
  },
  created() {
    // this.onLoadEmployee();
  },
  mounted() {},
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
