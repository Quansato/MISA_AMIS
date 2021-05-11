<template>
  <div class="header">
    <div class="header__select">
      <div class="three-stripes"></div>
      <div class="branch-name">Công ty cổ phần MISA</div>
      <div class="flex items-center">
        <a href="" class="icon-chevron"></a>
      </div>
    </div>

    <div class="header__user">
      <div class="header__user--avt"></div>
      <div class="header__user--name">Messi</div>
      <div class="header__user--action"></div>
    </div>
  </div>
</template>

<script>
export default {};
</script>

<style>
.body-right .header {
  background-color: rgb(255, 255, 255);
  display: flex;
  width: 100%;
  height: 50px;
  justify-content: space-between;
  align-items: center;
}

.body-right .header .header__user {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.body-right .header .header__select select {
  padding: 5px;
  border: none;
}

.body-right .header .header__select .three-stripes {
  width: 24px;
  height: 24px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -843px -30px;
  margin: 0px 10px;
}

.body-right .header .header__select .branch-name {
  width: 180px;
  height: 20px;
  font-size: 14px;
  padding-left: 10px;
  font-weight: 600;
}

.body-right .header .header__select .icon-chevron {
  width: 14px;
  height: 14px;
  background: url("../assets/img/Sprites.64af8f61.svg") no-repeat -80px -360px;
  transform: rotate(90deg);
  margin-left: 10px;
}

.body-right .header .header__select select:focus {
  outline: none;
  box-shadow: none !important;
}

.body-right .header .header__user .header__user--avt {
  /* background-image: url('../assets/icon/avatar-default.png'); */
  width: 50px;
  height: 45px;
  background-repeat: no-repeat;
  background-size: 22px;
  background-position: 18px center;
}

.body-right .header .header__user .header__user--action {
  /* background-image: url('../assets/icon/option.png'); */
  width: 50px;
  height: 45px;
  background-repeat: no-repeat;
  background-size: 22px;
  background-position: 18px center;
}
</style>
