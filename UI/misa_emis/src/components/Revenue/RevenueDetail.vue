<template>
    <div class="popup">
        <div class="form">
            <!-- <button @click="ValideteForm()">Load</button> -->
            <div class="form-title">
                {{Title}}
            </div>
            <div class="form-content">
                <div class="form-left">
                    <!-- Tên khoản thu -->
                    <Label :text="'Tên khoản thu '" 
                        :required="true"/>
                    <div class="input">
                        <input type="text" 
                            ref="feeName" 
                            class="textbox 
                            margin-r-16" 
                            v-model="NewFee.feeName"
                            :class="{'required-outline':required.feeName}"
                            @keyup="required.feeName = false"
                        >
                        <div class="tooltip" 
                            v-show="required.feeName">
                                Dữ liệu không được để trống!
                        </div>
                    </div>

                    <!-- Nhóm khoản thu -->
                    <Label :text="'Thuộc nhóm khoản thu'"/>
                    <div class="form-left-row">
                        <select v-model="NewFee.feeGroupId" 
                            ref="feeGroup">
                            <option class="select-item"
                                v-for="feeGroup in feeGroups" 
                                :key="feeGroup.feeGroupId"
                                :value="feeGroup.feeGroupId">
                                    {{feeGroup.feeGroupName}}
                            </option>
                        </select>
                        <div class="btn-plus"></div>
                    </div>

                    <!-- Mức thu -->
                    <div class="form-left-row3">
                        <!-- Mức thu  -->
                        <div class="mount">
                            <Label :text="'Mức thu '" :required="true" />
                            <div class="mount-row-2">
                                <!-- <input type="text" class="radius"> -->
                                 <div class="input">
                                    <input type="text" class="textbox" 
                                        v-model="NewFee.amountOfFee"
                                        id = "amount"
                                        maxlength="16"
                                        @keyup="FormatMoney()"
                                        ref="amountOfFee"
                                        :class="{'required-outline':required.feeName}"
                                    >
                                    <div class="tooltip" 
                                        v-show="required.amountOfFee">
                                            Dữ liệu không được để trống!
                                    </div>
                                </div>
                                <div class="unit-text">đ/</div>
                            </div>
                        </div>

                        <!-- Đơn vị khoản thu -->
                        <div class="unit">
                            <Label :text="'Đơn vị '" 
                                :required="true"/>
                            <select class="radius"
                                @change="required.unitFee = false" 
                                :class="{'required-outline':required.feeName}"
                                v-model="NewFee.unitFeeId"
                                ref="unitFee">
                                <option v-for="unitFee in unitFees"
                                :key="unitFee.unitFeeId"
                                :value="unitFee.unitFeeId">
                                    {{unitFee.unitFeeName}}
                                </option>
                            </select>
                            <div class="left-tooltip" v-show="required.unitFee">Dữ liệu không được để trống!</div>
                        </div>
                    </div>

                    <!-- Phạm vi thu -->
                    <Label :text="'Phạm vi thu '" :required="true"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius"
                            @change="required.feeRange = false"
                            :class="{'required-outline':required.feeName}"
                            v-model="NewFee.feeRangeId"
                            ref="feeRange">
                            <option v-for="feeRange in feeRanges" 
                            :key="feeRange.feeRangeId"
                            :value="feeRange.feeRangeId">{{feeRange.feeRangeName}}</option>
                        </select>
                        <div class="tooltip" v-show="required.feeRange">Dữ liệu không được để trống!</div>
                    </div>

                    <!-- Tính chất  -->
                    <Label :text="'Tính chất'"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius" v-model="NewFee.quality">
                            <option value="0">Thu theo thỏa thuận</option>
                            <option value="1">Thu theo hệ thống</option>
                        </select>
                    </div>

                    <!-- Kỳ thu -->
                    <Label :text="'Kỳ thu '" :required="true"/>
                    <div class="radio-row">
                        <!-- <form action=""> -->
                            <div class="radio-button" >
                                <input type="radio" name="term" 
                                    v-model="NewFee.turnFee" 
                                    value="0"
                                    @change="required.turnFee = false"
                                    >
                                <label for=""></label>
                                <div class="radio-text">Tháng</div>
                            </div>
                             <div class="radio-button" >
                                <input type="radio" name="term" 
                                    v-model="NewFee.turnFee" 
                                    value="1"
                                    @change="required.turnFee = false"
                                    >
                                <label for=""></label>
                                <div class="radio-text">Quý</div>
                            </div>

                             <div class="radio-button">
                                <input type="radio" name="term" 
                                    v-model="NewFee.turnFee" 
                                    value="2"
                                    @change="required.turnFee = false"
                                    >
                                <label for=""></label>
                                <div class="radio-text">Học kỳ</div>
                            </div>
                            
                             <div class="radio-button" >
                                <input type="radio" name="term" 
                                    v-model="NewFee.turnFee"  
                                    value="3"
                                    @change="required.turnFee = false"
                                    >
                                <label for=""></label>
                                <div class="radio-text">Năm học</div>
                            </div>
                            <div class="tooltip" v-show="required.turnFee">Dữ liệu không được để trống!</div>
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
                            <input type="checkbox" v-model="NewFee.allowExportLicense">
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
                    <div class="row-check non-margin" v-if="update">
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
                    :Text="'Lưu và thêm'"
                    :second="false"
                    v-if="update==false"
                    @click="Save();LoadData();"
                    />
                    <Button 
                    :Text="'Lưu'"
                    :second="false"
                    @click="Save();"/>
                </div>
            </div>
            <div class="btn-close-form"
                @click="CloseForm()">
            </div>
        </div>
        <div class="blur">

        </div>
        <Popup  
            :thirdbtn="true"
            :text="notifyText"
            v-if="notifyShow"
            @ClosePopup="ClosePopup()"/>
    </div>
</template>
<script>
// import Textbox from '../layout/Textbox.vue'
import Label from '../layout/Label.vue'
import Button from '../layout/Button.vue'
import axios from 'axios'
import Popup from '../popup/DeletePopup.vue'
export default {
    props:{
        Title:String,
        focusOn: Boolean,
        Fee:{},
        feeGroups: Object,
        unitFees: Object,
        feeRanges: Object,
        update: Object
    },
    data() {
        return {
            /**Đối tượng khoản thu mới*/
            NewFee: {},
            /**Đối tượng nhóm khách hàng */
            NewFeeGroup:{},
            /**Đối tượng đơn vị khoản thu */
            UnitFee: {},
            /**Biến truyền vào câu muốn thông báo */
            notifyText: '',
            /**Biến dùng để bật tắt, hiển thị thông báo */
            notifyShow: false,
            /**Đối tượng dùng để kiểm tra bắt buộc nhập*/
            required:{
                feeName: false,
                unitFee: false,
                amountOfFee: false,
                feeRange: false,
                turnFee: false
            },
            isValid: false
        }
    },
    beforeUpdate(){
         this.$nextTick(()=>{
            this.NewFee = this.Fee
        })
        // this.$nextTick(()=>{
        //     this.NewFeeGroup = {...this.FeeGroups}
        // })
    },
    components:{
        // Textbox,
        Label,
        Button,
        Popup
    },
    methods:{
        /**
         * Dóng popup thông báo 
         */
        ClosePopup:function(){
            this.notifyShow = false;
            this.CloseForm()
        },
        /**
         * Đóng form đang mở
         */
        CloseForm: function(){
            this.$emit('CloseForm');
            this.required.feeRange = false;
            this.required.unitFee = false;
            this.required.amountOfFee = false;
            this.required.feeName = false;
            this.required.turnFee = false;
        },
        LoadData(){
            this.$emit('LoadData');
        },
        /**
         * Hàm thực hiện gửi request thêm hoặc sửa
         */
        Save:async function(){
            this.ValidateForm();
            if(this.isValid == true){
                this.GetValue();
                var rowaffect
                if(this.update){
                    rowaffect = await axios.put('https://localhost:44341/api/v1/Fee',this.NewFee).then((result)=> { return result.data.data})
                }
                else{
                    rowaffect = await axios.post('https://localhost:44341/api/v1/Fee',this.NewFee).then((result)=> {return result.data.data})
                }
                console.log(rowaffect)
                if(rowaffect == 1){
                    if(this.update){
                        this.notifyText = 'Đã cập nhật dữ liệu.'
                    }
                    else{
                        this.notifyText = 'Dữ liệu đã được thêm thành công.'
                    }    
                }else{
                    if(this.update){
                        this.notifyText = 'Dữ liệu chưa được cập nhật!'
                    }
                    else{
                        this.notifyText = 'Dữ liệu chưa được thêm mới!'
                    }   
                }
                this.notifyShow = true
            }
        },
        /**
         * Hàm dùng để format tiền
         */
        // FormatMoney:function(amount){
        //     var money = amount.toFixed(0);
        //     money = money.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1.');
        //     return money;
        // }
        FormatMoney(){
            //Xóa tooltip vì dữ liệu đã có
            this.required.amountOfFee = false
            var NewValue = document.getElementById("amount").value
            //Khử dấu . để tạo thành chuỗi liên 
            NewValue = NewValue.toString().split(".").join("")
            // console.log(NewValue)
            //Tách chuỗi liền nhau thành chuôi có dạng 00.000.000
            this.NewFee.amountOfFee = NewValue.replace(/(\d)(?=(?:\d{3})+$)/g, '$1.')
            console.log(this.NewFee.amountOfFee)
        },

        /**
         * Trả về giá trị của mức khoản thu để gửi lên serve
         */
        GetValue(){
            this.NewFee.amountOfFee = this.NewFee.amountOfFee.split(".").join("")
            this.NewFee.amountOfFee = parseFloat(this.NewFee.amountOfFee);
            console.log(this.NewFee.amountOfFee)
        },
        /**Hàm validate dữ liệu cho các ô bắt buộc nhập */
        ValidateForm(){
            // var name = this.$refs.feeName.value
            // var unit = this.$refs.unitFee.value
            // var amount = this.$refs.amountOfFee.value
            // var range = this.$refs.feeRange.value
            // var turn = this.NewFee.turnFee
            var name = this.NewFee.feeName
            var unit = this.NewFee.unitFeeId
            var amount = this.NewFee.amountOfFee
            var range = this.NewFee.feeRangeId
            var turn = this.NewFee.turnFee

            /**Kiểm tra tên khoản thu */
            if(name == "" || name == null || name == undefined){
                this.required.feeName = true;
                this.isValid = false
            }   
            else{
                this.required.feeName = false;
                this.isValid = true
            }
            /**Kiểm tra đơn vị thu */
            if(unit == "" || unit == null || unit == undefined){
                this.required.unitFee = true
                this.isValid = false
            }
            else{
                this.required.unitFee = false
                this.isValid = true
            }
            /**Kiểm tra mức thu */
            if(amount == "" || amount == null || amount == undefined){
                this.required.amountOfFee = true
                this.isValid = false
            }
            else{
                 this.required.amountOfFee = false
                 this.isValid = true
            }
            /**Kiểm tra phạm vi thu */
            if(range == "" || range == null || range == undefined){
                this.required.feeRange = true
                this.isValid = false
            }
            else{
                this.required.feeRange = false
                this.isValid = true
            }
            /**Kiểm tra kỳ thu */
            if(turn == "" || turn == null || turn == undefined){
                this.required.turnFee = true
                this.isValid = false
            }
            else{
                this.required.turnFee = false
                this.isValid = true
            }
            console.log(this.isValid)
        }
    },
    // watch(){
    //     this.NewFee.turnFee(){
    //         this.required.turnFee = false
    //     }
    // },
    created() {
    },
}
</script>

<style lang="css" scoped>
    @import'../../css/dictionary/revenue/revenueDetail.css'
</style>