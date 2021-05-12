<template>
  <div class="dialog">
    <div
      class="dialog-content"
      ref="modal"
      @mousedown="$fn.startMoving($refs['modal'], id, $event)"
      @mouseup="$fn.stopMoving($refs['modal'])"
    >
      <div class="dialog-header">
        <div class="dialog-title flex items-center">
          Thông tin nhân viên
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
          <div class="dialog-help-button" @click="hideModal()"></div>
          <div class="dialog-close-button" @click="hideModal()"></div>
        </div>
      </div>
      <div class="dialog-body flex flex-column">
        <div class="flex pd-b-12">
          <div class="p-r-26 flex-1">
            <div class="m-row">
            <!-- Mã -->
            <div class="m-item-input flex-5 p-r-6">
              <label for="EmployeeCode" class="m-label"
                >Mã<span class="required"> * </span></label
              >
              <input type="text" class="m-input" ref="EmployeeCode" readonly />
            </div>
            <!-- Tên -->
            <div class="m-item-input flex-1">
              <label for="EmployeeCode" class="m-label"
                >Tên<span class="required"> * </span></label
              >
              <input type="text" class="m-input" ref="EmployeeCode" readonly />
            </div>
            </div>
            <!--  -->
          </div>
          <div class="flex-1"></div>
        </div>
      </div>
      <slot name="footer"></slot>
    </div>
  </div>
</template>

<script>
export default {
  name: "Detail",
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
  height: 625px;
  border-radius: 4px;
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

.dialog .dialog-close-button:hover {
  background-color: #bbb;
  cursor: pointer;
}

.dialog-hide {
  display: none;
}

.dialog .dialog-footer {
  position: absolute;
  display: flex;
  align-items: center;
  bottom: 0;
  background-color: #e5e5e5;
  height: 56px;
  border-radius: 0 0 4px 4px;
  left: 0;
  right: 0;
}

.dialog .dialog-footer button {
  position: absolute;
  right: 24px;
}

.ms-checkbox {
  padding: 0px 19.5px;
}

span.tooltip-content {
  color: #111111;
  margin-left: 10px;
}
</style>
