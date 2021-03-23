<template>
    <div class="popup">
        <div class="form">
            <div class="form-title">
                Thêm khoản thu
            </div>
            <div class="form-content">
                <div class="form-left">
                    <Label :text="'Tên khoản thu *'"/>
                    <Textbox/>
                    <Label :text="'Thuộc nhóm khoản thu'"/>
                    <div class="form-left-row">
                        <select>
                            <option value="1">Học phí</option>
                        </select>
                        <div class="btn-plus"></div>
                    </div>
                    <div class="form-left-row3">
                        <div class="mount">
                            <Label :text="'Mức thu *'"/>
                            <div class="mount-row-2">
                                <select class="radius">
                                    <option value="1"></option>
                                </select>
                                <div class="unit-text">đ/</div>
                            </div>
                        </div>
                        <div class="unit">
                            <Label :text="'Đơn vị *'"/>
                            <select class="radius">
                                <option value="1"></option>
                            </select>
                        </div>
                    </div>
                    <Label :text="'Phạm vi thu *'"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius">
                            <option value="1"></option>
                        </select>
                    </div>
                </div>
                <div class="form-right">
                    
                </div>
            </div>
        </div>
        <div class="blur">

        </div>
    </div>
</template>
<script>
import Textbox from '../layout/Textbox.vue'
import Label from '../layout/Label.vue'
export default {
    components:{
        Textbox,
        Label
    }
}
</script>

<style lang="css" scoped>
    .form{
        font-family: OpenSan-Regular;
        position: absolute;
        top: 10%;
        left: 50%;
        transform: translate(-50%, 0%);
        width: 960px;
        height: 400px;
        background-color: #ffffff;
        z-index: 100;
        padding: 24px;
    }
    .blur{
        top: 0px;
        left: 0px;
        width: 100%;
        height: 100%;
        background-color: black;
        position: absolute;
        opacity: 0.4;
        z-index: 50;
    }
    .form-title{
        font-family: OpenSan-Semibold;
        font-size: 15px;
        margin-bottom: 16px;
    }
    .form-left, .form-right{
        flex-grow: 1;
        flex-shrink: 1;
        flex-basis: 0%;
    }
    .form-content{
        display: flex;
    }
    .form-left-row{
        display: flex;
        align-items: center;
    }
    .mar-r-16px{
        margin-right: 16px;
    }
    select{
        font-family: OpenSan-Regular;
        height: 32px;
        box-sizing: border-box;
        background-color: #ffffff;
        border: 1px solid #CCCCCC;
        border-radius: 4px 0px 0px 4px;
        padding: 0px 12px;
        flex-grow: 1;
        flex-shrink: 1;
        flex-basis: 0%;
    }
    .btn-plus{
        height: 30px;
        width: 30px;
        border-radius: 0px 4px 4px 0px;
        border: 1px solid #CCCCCC;
        border-left: 0px;
        margin-left: -1px;
        margin-right: 16px;
        background-image: url('../../assets/image/ic_Plus.svg');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
    }
    .radius{
        border-radius: 4px !important;
    }
    .form-left-row3{
        display: inline-flex;
        width: 100%;
    }
    .mount{
        flex-grow: 1;
        flex-basis: 0%;
        flex-shrink: 1;
    }
    .mount-row-2{
        display: flex;
    }
    .unit-text{
        font-size: 13px;
        line-height: 32px;
        padding: 0px 8px;
    }
    .unit{
        margin-right: 16px;
        
    }
</style>