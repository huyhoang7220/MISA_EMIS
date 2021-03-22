<template>
    <div class="content">
        <div class="category">
            <div class="category-item">
                <hr>
                Quy trình
            </div>
            <div class="category-item category-item-active">
                <hr class="active-hr">
                Danh sách khoản thu
            </div>
            <div class="category-item">
                <hr>
                Đăng ký khoản thu
            </div>
            <div class="category-item">
                <hr>
                Danh sách miễn giảm
            </div>
        </div>
        <div class="grid">
            <div class="filter-line">
                <div class="filter-left">
                    <input type="checkbox" name="" id="">
                    <label for="">Hiển thị khoản thu ngừng theo dõi</label>
                </div>
                <div class="filter-right">
                    <Button 
                        :text="text"
                        :second="second"/>
                    <Button 
                        :text="'Sắp lại thứ tự'" 
                        :second="true"/>
                    <div class="delete"></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

import Button from './Button.vue'
export default {
    data() {
        return {
            text: 'Thêm mới',
            second: false
        }
    },
    comments:{
        Button
    }
}
</script>

<style lang="css">
    .content{
        background: #EAECEF;
        width: 100%;
        height: calc(100vh - 46px);
    }
    .category{
        height: 40px;
        display: flex;
        background-color: #E0E0E0;
    }
    .category-item{
        padding: 0px 24px;
        line-height: 40px;
        font-size: 13px;
        color: #A6A6A6;
        position: relative;
        text-align: center;
        font-family: OpenSan-Semibold;
    }
    .category-item-active{
        background-color: #FFFFFF !important;
        color: #000000;
    }
    .category hr{
        position: absolute;
        width: 100%;
        height: 2px;
        background-color: #009253;
        top: 0px;
        left: 0px;
        margin: 0px;
        padding: 0px;
        border: 0px;
        display: none;
    }
    .active-hr{
        display: block !important;
    }
    .grid{
        height: calc(100% - 40px);
        width: 100%;
        background-color: #FFFFFF;
    }
    label{
        font-size: 13px;
    }
    .filter-line{
        height: 46px;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
   
</style>