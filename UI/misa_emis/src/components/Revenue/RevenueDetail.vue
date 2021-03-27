<template>
    <div class="popup">
        <div class="form">
            <div class="form-title">
                {{Title}}
            </div>
            <div class="form-content">
                <div class="form-left">
                    <!-- Tên khoản thu -->
                    <Label :text="'Tên khoản thu '" :required="true"/>
                    <div class="input">
                        <input type="text" ref="feeName" class="textbox margin-r-16" v-model="NewFee.feeName">
                    </div>

                    <!-- Nhóm khoản thu -->
                    <Label :text="'Thuộc nhóm khoản thu'"/>
                    <div class="form-left-row">
                        <select v-model="NewFee.feeGroupId">
                            <option v-for="feeGroup in feeGroups" 
                            :key="feeGroup.feeGroupId"
                            :value="feeGroup.feeGroupId">
                                {{feeGroup.feeGroupName}}
                            </option>
                        </select>
                        <div class="btn-plus"></div>
                    </div>

                    <!-- Mức thu -->
                    <div class="form-left-row3">
                        <div class="mount">
                            <Label :text="'Mức thu '" :required="true"/>
                            <div class="mount-row-2">
                                <!-- <input type="text" class="radius"> -->
                                 <div class="input">
                                    <input type="text" class="textbox" v-model="NewFee.amountOfFee">
                                </div>
                                <div class="unit-text">đ/</div>
                            </div>
                        </div>
                        <div class="unit">
                            <Label :text="'Đơn vị '" :required="true"/>
                            <select class="radius" v-model="NewFee.unitFeeId">
                                <option v-for="unitFee in unitFees"
                                :key="unitFee.unitFeeId"
                                :value="unitFee.unitFeeId">
                                    {{unitFee.unitFeeName}}
                                </option>
                            </select>
                        </div>
                    </div>

                    <!-- Phạm vi thu -->
                    <Label :text="'Phạm vi thu '" :required="true"/>
                    <div class="form-left-row ">
                        <select class="mar-r-16px radius" v-model="NewFee.feeRangeId">
                            <option v-for="feeRange in feeRanges" 
                            :key="feeRange.feeRangeId"
                            :value="feeRange.feeRangeId">{{feeRange.feeRangeName}}</option>
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
                    <Label :text="'Kỳ thu '" :required="true"/>
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
    </div>
</template>
<script>
// import Textbox from '../layout/Textbox.vue'
import Label from '../layout/Label.vue'
import Button from '../layout/Button.vue'
import axios from 'axios'
// import axios from 'axios'
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
            NewFee: {
            },
            NewFeeGroup:{},
            UnitFee: {},
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
        Button
    },
    methods:{
        CloseForm: function(){
            this.$emit('CloseForm');
        },
        LoadData(){
            this.$emit('LoadData');
        },
        Save: function(){
            if(this.update){
                console.log(this.NewFee);
                axios.put('https://localhost:44341/api/v1/Fee',this.NewFee).then((result)=> {console.log(result)})
            }
            else{
                axios.post('https://localhost:44341/api/v1/Fee',this.NewFee).then((result)=> {console.log(result)})
            }
            this.CloseForm();
        }

    },
    created() {
    },
}
</script>

<style lang="css" scoped>
    @import'../../css/dictionary/revenue/revenueDetail.css'
</style>