<template>
    <div class="revenue">
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
                    <div class="select-line" 
                    @click="check()"
                    :class="{'selected-line':selectedCheck}"></div>
                    <label for="">Hiển thị khoản thu ngừng theo dõi</label>
                </div>
                <div class="filter-right">
                    <NewButton 
                        :Text="'Thêm mới'"
                        :second="false"
                        @click="OpenForm()"
                        />
                    <NewButton 
                    :Text="'Sắp lại thứ tự'"
                        :second="true"/>
                    <div class="trash-btn">

                    </div>
                </div>
            </div>

            <div class="grid-list">
                <div class="outline-table">
                <table cellspacing="0" cellpadding="0">
                    <tr>
                        <th colspan="1"> </th>
                        <th colspan="1" class="col-name-revenue">
                            <div class="th-text">Tên khoản thu</div>
                            <div class="btn-filter"><input type="text" id=""></div>
                        </th>
                        <th colspan="1" class="col-group-revenue">
                            <div class="th-text">Nhóm khoản thu</div>
                            <div class="btn-filter"><input type="text" id=""></div>
                        </th>
                        <th colspan="1" class="col-mount-revenue">
                            <div class="th-text">Mức thu</div>
                            <div class="btn-filter"><input type="text" id=""></div>
                        </th>
                        <th colspan="1">
                            <div class="th-text">Kỳ thu</div>
                            <div class="btn-filter">
                                <select >
                                    <option value=""> </option>
                                    <option value=""> </option>
                                </select>
                            </div>
                        </th>
                        <th colspan="1" class="td-to-check">Áp dụng miễn giảm</th>
                        <th colspan="1" class="td-to-check">Cho xuất hóa đơn</th>
                        <th colspan="1" class="td-to-check">Cho xuất chứng từ</th>
                        <th colspan="1" class="td-to-check">Cho phép hoàn trả</th>
                        <th colspan="1" class="td-to-check">Khoản thu bắt buộc</th>
                        <th colspan="1" class="td-to-check">Đang theo dõi</th>
                        <th colspan="1"></th>

                    </tr>
                    <tr v-for="fee in Fees" :key="fee.feeId">
                        <td colspan="1"><div class="select-line" 
                            @click="checkLine()" 
                            :class="{'selected-line':false}"></div>
                        </td>
                        <td colspan="1">{{fee.feeName}}</td>
                        <td colspan="1">{{fee.feeGroupName}}</td>
                        <td colspan="1" class="align-right-text">{{fee.amountOfFee}}đ</td>
                        <td colspan="1" class="td-to-check">{{fee.turnFee}}</td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.discount}"></div></td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.allowExportBill}"></div></td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.allowExportLicense}"></div></td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.allowReturn}"></div></td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.feeRequired}"></div></td>
                        <td colspan="1" class="td-to-check"><div :class="{'cell-checking':fee.follow}"></div></td>
                        <td colspan="1">
                            <div class="last-cell">
                                <div class="btn-edit" @click="RowEdit(fee)"></div>
                                <div class="btn-copy"></div>
                                <div class="btn-delete"></div>
                            </div>
                        </td>
                    </tr>
                </table>
                </div>
            </div>
            <div class="footer">
                <div class="result">
                    Tổng số: <span class="count">7</span> kết quả.
                </div>
            </div>
        </div>
        <Detail v-show="show" @CloseForm="CloseForm()" 
        :focusOn="focusOn" 
        :Fee="Fee" ref="detail"
        :FeeGroup="FeeGroup"
        />
    </div>
</template>

<script>
import axios from 'axios'
import NewButton from '../layout/Button.vue'
import Detail from './RevenueDetail.vue'
export default {
    data() {
        return {
            text: 'Thêm mới',
            second: false,
            selectedCheck: false,
            show: false,
            focusOn: false,
            Fees:{},
            Fee:{
                feeId: '',
                feeName: '',
                feeGroupId: '',
                feeRangeId: '',
                unitFeeId: '',
                turnFee: '',
                amountOfFee: 220000,
                discount: false,
                allowExportBill: false,
                allowExportLicense: false,
                feeRequired: false,
                allowReturn: false,
                feePrivate: false,
                typeRegistion: false,
                follow: false,
                feeGroupName: '',
                createdBy: null,
                createdDate: '',
                modifiedDate: ''
            },
            FeeGroup: {},
        }
    },
    components:{
        NewButton,
        Detail,
    },
    watch:{
        focusOn:function(){
            this.$nextTick(()=>{
                this.$refs.detail.$refs.feeName.focus();
            })
        }
    },
    methods:{
        check: function(){
            this.selectedCheck =! this.selectedCheck;
        }
        ,OpenForm: function(){
            this.show = true;
            this.Fee = {}
            this.focusOn = true
        },
        CloseForm:function(){
            this.show = false;
            this.focusOn=false;
            this.Fee = {}
        },
        RowEdit: function(Fee){
            this.show = true;
            this.focusOn = true
            this.Fee = {...Fee}
        },
        LoadData:function(){
            var newres = axios.get('https://localhost:44341/api/v1/fee');
            this.Fees = newres.data
        }
    },
    async created() {
        const res = await axios.get('https://localhost:44341/api/v1/fee');
        this.Fees = res.data
        var responsive = await axios.get('https://localhost:44341/api/v1/FeeGroup');
        this.FeeGroup = responsive.data;
    },
}
</script>

<style lang="css">
    .revenue{
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
    .filter-left{
        margin-left: 16px;
        display: flex;

    }
    .filter-left label{
        margin-left: 10px;
    }
    .filter-right{
        display: flex;
    }
    .trash-btn{
        width: 32px;
        height: 32px;
        border-radius: 4px;
        border: 1px solid #0FA655;
        background-image: url('../../assets/image/ic_Remove2.svg');
        margin-left: 8px;
        margin-right: 16px;
    }
    .grid-list{
        padding-left: 16px;
        padding-right: 16px;
        width: calc(100% - 32px);
        height: calc(100% - 106px);
    }
    .th-text{
        line-height: 24px;
        margin-bottom: 12px;
        white-space: nowrap;
    }

    .outline-table{
        border-collapse: collapse;
        overflow: auto;
        width: 100%;
        height: 100%;
        border: 1px solid #D5D8E6;
        padding-right: -1px;
        z-index: 20;
    }
    .grid-list table{
        border: 0px;
        width: 100%;
        border-collapse: collapse;
        margin: 0px;
    }
    .grid-list table tr{
        width: fit-content;
    }
    .grid-list table tr:nth-child(odd){
        background-color:#e5f3ff;
    }
    .grid-list table tr th{
        padding: 8px 8px;
        font-size: 13px;
        font-family: OpenSan-Semibold;
        border: 1px solid#D5D8E6;
        text-align: center;
        background-color:#f5f6fa;
    }
    .td-to-check{
        min-width: 60px;
    }
    .btn-filter{
        width: 100%;
        display: flex;
    }
    .btn-filter input{
        width: 100%;
        background-image: url('../../assets/image/ic_Filter.svg');
        background-position: 0px;
        background-repeat: no-repeat;
        padding-left: 24px;
        border: 1px solid  #D5D8E6;
        height: 20px;
    }
    .btn-filter select{
        width: 100%;
        height: 20px;
        border: 1px solid  #D5D8E6;
    }
    .btn-filter input,select:focus{
        outline: none;
    }
    .grid-list table tr td{
        height: 32px;
        line-height: 32px;
        border: 1px solid  #D5D8E6;
        font-size: 13px;
        font-family: OpenSan-Regular;
        padding-left: 12px;
        padding-right: 12px;
    }
    .grid-list table tr td:first-child{
        max-width: 36px !important;
    }
    .line-forcus{
        background-color: #cce8ff;
    }
    .select-line{
        width: 16px;
        height: 16px;
        margin: auto;
        background-image: url('../../assets/image/ic_Checkbox_Inactive.svg');
        background-size: contain;
        background-position: center;
        background-repeat: no-repeat;
    }
    .selected-line{
        background-image: url('../../assets/image/ic_Checkbox_Active.svg') !important;

    }
    .cell-checking{
        width: 100%;
        height: 20px;
        background-image: url('../../assets/image/ic_Check.png');
        background-repeat: no-repeat;
        background-size: contain;
        background-position: center;
    }
    .footer{
        height: 60px;
        width: 100%;
        padding: 10px 16px;
        box-sizing: border-box;
    }
    .result{
        font-size: 13px;
        font-display: OpenSan-Regular;
    }
    .count{
        font-family: OpenSan-bold;
    }
    .last-cell{
        display: flex;
        align-items: center;
    }
    .btn-edit, .btn-copy, .btn-delete{
        width: 24px;
        height: 24px;
        background-position: center;
        background-size: contain;
        cursor: pointer;
    }
    .btn-edit{
        background-image: url('../../assets/image/ic_Edit.svg');
    }
    .btn-copy{
        background-image: url('../../assets/image/ic_Duplicate_24.svg');
    }
    .btn-delete{
        background-image: url('../../assets/image/ic_Remove2.svg');
    }
    .align-right-text{
        text-align: right !important;
    }
    .col-name-revenue{
        min-width: 350px;
    }
    .col-group-revenue{
        min-width: 200px;
    }
    .col-mount-revenue{
        min-width: 200px;
    }
</style>