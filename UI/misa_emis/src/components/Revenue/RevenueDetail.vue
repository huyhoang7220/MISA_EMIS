<template>
    <div class="popup">
        <div class="form">
            <div class="form-title">
                Thêm khoản thu
            </div>
            <div class="form-content">
                <div class="form-left">
                    <!-- Tên khoản thu -->
                    <Label :text="'Tên khoản thu *'"/>
                    <div class="input">
                        <input type="text" ref="feeName" class="textbox margin-r-16" v-model="NewFee.feeName">
                    </div>

                    <!-- Nhóm khoản thu -->
                    <Label :text="'Thuộc nhóm khoản thu'"/>
                    <div class="form-left-row">
                        <select v-model="NewFee.feeGroupId">
                            <option v-for="feeGroup in NewFeeGroup" 
                            :key="feeGroup.feeGroupId"
                            v-bind:value="feeGroup.feeGroupId">
                                {{feeGroup.feeGroupName}}
                            </option>
                        </select>
                        <div class="btn-plus"></div>
                    </div>

                    <!-- Mức thu -->
                    <div class="form-left-row3">
                        <div class="mount">
                            <Label :text="'Mức thu *'"/>
                            <div class="mount-row-2">
                                <!-- <input type="text" class="radius"> -->
                                 <div class="input">
                                    <input type="text" class="textbox" v-model="NewFee.amountOfFee">
                                </div>
                                <div class="unit-text">đ/</div>
                            </div>
                        </div>
                        <div class="unit">
                            <Label :text="'Đơn vị *'"/>
                            <select class="radius" >
                                <option value="1"></option>
                            </select>
                        </div>
                    </div>

                    <!-- Phạm vi thu -->
                    <Label :text="'Phạm vi thu *'"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius" v-model="NewFee.feeRangeId">
                            <option value="1">Toàn trường</option>
                        </select>
                    </div>

                    <!-- Tính chất  -->
                    <Label :text="'Tính chất'"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius">
                            <option value="1">Toàn trường</option>
                        </select>
                    </div>

                    <!-- Kỳ thu -->
                    <Label :text="'Kỳ thu *'"/>
                    <div class="radio-row">
                        <!-- <form action=""> -->
                            <div class="radio-button">
                                <input type="radio" name="term" v-model="NewFee.turnFee" value="0">
                                <label for=""></label>
                                <div class="radio-text">Tháng</div>
                            </div>
                             <div class="radio-button" >
                                <input type="radio" name="term" v-model="NewFee.turnFee" value="1">
                                <label for=""></label>
                                <div class="radio-text">Quý</div>
                            </div>

                             <div class="radio-button">
                                <input type="radio" name="term" v-model="NewFee.turnFee" value="2">
                                <label for=""></label>
                                <div class="radio-text">Học kỳ</div>
                            </div>
                            
                             <div class="radio-button">
                                <input type="radio" name="term" v-model="NewFee.turnFee"  value="3">
                                <label for=""></label>
                                <div class="radio-text">Năm học</div>
                            </div>
                        <!-- </form> -->
                    </div>
                </div>
                <div class="form-right">
                    <div class="form-r-col">
                        <div class="row-check">
                            <input type="checkbox" v-model="NewFee.discount">
                            <label></label>
                            <div class="col-row-text">
                                Áp dụng miễn giảm
                            </div>
                        </div>
                        <div class="row-check">
                            <input type="checkbox" v-model="NewFee.feeRequired">
                            <label></label>
                            <div class="col-row-text">
                                Khoản thu bắt buộc
                            </div>
                        </div>
                        <div class="row-check">
                            <input type="checkbox" v-model="NewFee.allowExportBill">
                            <label></label>
                            <div class="col-row-text">
                                Cho phép xuất hóa đơn
                            </div>
                        </div>
                        <div class="row-check">
                            <input type="checkbox" class="switch-btn" v-model="NewFee.typeRegistion">
                            <label></label>
                            <div class="col-row-text">
                                Phân loại đăng ký
                            </div>
                        </div>
                    </div>
                    <div class="form-r-col">
                         <div class="row-check">
                            <input type="checkbox" checked v-model="NewFee.allowExportLicense">
                            <label></label>
                            <div class="col-row-text">
                                Cho phép xuất chứng từ
                            </div>
                        </div>
                        <div class="row-check">
                            <input type="checkbox" v-model="NewFee.allowReturn">
                            <label></label>
                            <div class="col-row-text">
                                Cho phép hoàn trả
                            </div>
                        </div>
                        <div class="row-check">
                            <input type="checkbox" v-model="NewFee.feePrivate">
                            <label></label>
                            <div class="col-row-text">
                                Thu nội bộ
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-footer">
                <div class="f-footer-left">
                    <div class="row-check non-margin">
                        <input type="checkbox" v-model="NewFee.follow">
                        <label></label>
                        <div class="col-row-text">
                            Ngừng theo dõi
                        </div>
                    </div>
                </div>
                <div class="f-footer-right">
                    <Button
                        @click="CloseForm()"
                        :Text="'Đóng'"
                        :second="true"/>
                    <Button 
                    :Text="'Lưu'"
                    :second="false"/>
                </div>
            </div>
            <div class="btn-close-form"
                @click="CloseForm()">
            </div>
        </div>
        <div class="blur">

        </div>
    </div>
</template>
<script>
// import Textbox from '../layout/Textbox.vue'
import Label from '../layout/Label.vue'
import Button from '../layout/Button.vue'
// import axios from 'axios'
export default {
    props:{
        focusOn: Boolean,
        Fee:{},
        FeeGroups:{}
    },
    data() {
        return {
            NewFee: {
                feeId: null,
                feeName: '',
                feeGroupId: null,
                feeRangeId: null,
                unitFeeId: null,
                turnFee: '',
                amountOfFee: null,
                discount: false,
                allowExportBill: false,
                allowExportLicense: false,
                feeRequired: false,
                allowReturn: false,
                feePrivate: false,
                typeRegistion: false,
                follow: false,
                feeGroupName: '',
                quality:'',
                createdBy: null,
                createdDate: null,
                modifiedDate: null
            },
            NewFeeGroup: {
                
            },
            UnitFee: {},
        }
    },
    beforeUpdate(){
         this.$nextTick(()=>{
            this.NewFee = this.Fee
            this.NewFeeGroup = this.FeeGroups
            console.log(this.FeeGroups)
        })
    },
    components:{
        // Textbox,
        Label,
        Button
    },
    methods:{
        CloseForm: function(){
            this.$emit('CloseForm');
    },
    created() {

    },
},
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
        height: auto;
        background-color: #ffffff;
        z-index: 100;
        padding: 24px;
        padding-bottom: 16px;
        border-radius: 4px;
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
    .form-left{
        border-right:1px solid #CCCCCC;
        padding-bottom: 60px;
        padding-right: 8px;
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
    select:focus{
         border: 1px solid #00d469;
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
        min-width: 72px;
    }
    .unit select{
        width: 100%;
    }
    .radio-row{
        margin-top: 8px;
        margin-right: 16px;
        display: flex;
        flex-grow: 1;
        align-items: center;
        justify-content: space-between;
    }
    .radio-button{
        display: flex;
        align-items: center;
    }
    .radio-button input{
        margin: 0px;
    }
    .radio-text{
        font-size: 13px;
        color:  #757575;
        margin-left: 8px;
    }
    .radio-button input[type="radio"]:not(:checked),
    .radio-button input[type="radio"]:checked
    {
        position: absolute;
        opacity: 0;
    }
    .radio-button input[type="radio"] + label{
        background-image: url('../../assets/image/ic_Ratio_Inactive.svg');
        background-size: contain;
        background-position: center;
        background-repeat: no-repeat;
        width: 16px;
        height: 16px;
        background-color: #f5f5f5;
        border-radius: 16px;
    }
    .radio-button input[type="radio"]:checked + label{
        background-image: url('../../assets/image/ic_Ratio_Active.svg');
    }
    .radio-button input[type="radio"]:hover .radio-button input[type="radio"] + label{
        background-image: url('../../assets/image/ic_Ratio_Hover.svg');
    }

    /* form right */
    .form-right{
        display: flex;
        padding-right: 60px;
    }
    .form-r-col{
        flex-grow: 1;
        flex-shrink: 1;
        flex-basis: 0%;
        padding-left: 24px;
        padding-top: 24px;
    }
    .row-check{
        display: flex;
        align-items: center;
         margin-bottom: 24px;
    }

    .row-check input[type="checkbox"]:checked,
    .row-check input[type="checkbox"]:not(:checked){
        position: absolute;
        opacity: 0;
        padding: 0px;
        margin: 0px;
    }
    
    .row-check input[type="checkbox"]:checked + label{
        
        background-image: url('../../assets/image/ic_Checkbox_Active.svg');
        
    }
    .row-check input[type="checkbox"] + label{
        background-image: url('../../assets/image/ic_Checkbox_Inactive.svg');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
        width: 16px;
        height: 16px;
    }
    .row-check input.switch-btn[type="checkbox"]{
        width: 16px;
        height: 16px;
    }
    .row-check input.switch-btn[type="checkbox"]:checked + label{
        
        background-image: url('../../assets/image/Toggle On_.svg');

    }
    .row-check input.switch-btn[type="checkbox"] + label{
        background-image: url('../../assets/image/ic_Switch_Inactive.svg');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
        width: 20px;
        height: 24px;
    }

    .col-row-text{
        font-family: OpenSan-Regular;
        font-size: 13px;
        color: #757575;
        margin-left: 8px;
    }
    .switch-check{
        width: 20px;
        height: 18px;
         background-image: url('../../assets/image/ic_Switch_Inactive.svg');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
    }
    .switch-checked{
        background-image: url('../../assets/image/ic_Switch_Inactive.svg');
    }
    .non-margin{

        margin: 0px;
    }
    .form-footer{
        display: flex;
        margin-top: 16px;
        height: 40px;
        justify-content: space-between;
    }
    .f-footer-left{
        display: flex;
        align-items: center;
    }
    .f-footer-right{
        display: flex;
        align-items: center;
    }
    .btn-close-form{
        position: absolute;
        top: 16px;
        right: 16px;
        width: 20px;
        height: 20px;
        background-image: url('../../assets/image//ic_close_16.png');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
        cursor: pointer;
    }
    .input{
        width: 100%;
        display: flex;
    }
    .textbox{
        font-family: OpenSan-Regular;
        height: 32px;
        box-sizing: border-box;
        background-color: #ffffff;
        border: 1px solid #CCCCCC;
        border-radius: 4px;
        padding: 0px 12px;
        flex-grow: 1;
        flex-shrink: 1;
        flex-basis: 0%;
    }
    .textbox:focus{
        outline: none;
        border: 1px solid #00d469;
    }
    .margin-r-16{
        margin-right: 16px;
    }
</style>