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
                    @click="LoadFeeStopFollow()"
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
                            <div class="btn-filter"><input type="text"></div>
                        </th>
                        <th colspan="1" class="col-group-revenue">
                            <div class="th-text">Nhóm khoản thu</div>
                            <div class="btn-filter"><input type="text"></div>
                        </th>
                        <th colspan="1" class="col-mount-revenue">
                            <div class="th-text">Mức thu</div>
                            <div class="btn-filter"><input type="text"></div>
                        </th>
                        <th colspan="1" style="min-width: 80px">
                            <div class="th-text">Kỳ thu</div>
                            <div class="btn-filter">
                                <select >
                                    <option value="0">Tháng</option>
                                    <option value="1">Quý</option>
                                    <option value="2">Kỳ học</option>
                                    <option value="3">Năm</option>
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
                        <td colspan="1" class="align-right-text">{{FormatAmountOfFee(fee.amountOfFee,fee.turnFee)}}</td>
                        <td colspan="1" class="td-to-check">{{ TurnFeeFormat(fee.turnFee) }}</td>
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
                                <div class="btn-delete" @click="DeletePopup(fee.feeId)"></div>
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
        :feeGroups="feeGroups"
        :feeRanges="feeRanges"
        :unitFees="unitFees"
        :Title="Title"
        :update="update"
        @LoadData="LoadData()"
        />
        <DeletePopup 
        v-show="popup.deleteOne" 
        :text="'Bạn có chắc muốn xóa khoản thu đã chọn?'"
        :secondbtn="true"
        @DeleteCancel="DeleteCancel()"
        @DeleteOne="DeleteOne"
        :FeeId="FeeId"/>
        <DeletePopup 
        v-show="popup.deleteMulti"
        :text="'Bạn có chắc muốn xóa những khoản thu đã chọn?'"
        :secondbtn="true"
        @DeleteCancel="DeleteCancel()"
        />
    </div>
</template>

<script>
import axios from 'axios'
import NewButton from '../layout/Button.vue'
import Detail from './RevenueDetail.vue'
import DeletePopup from '../popup/DeletePopup.vue'
export default {
    data() {
        return {
            /**
             * update : true=> sửa,
             * update: false => thêm
             * 
             */
            update: false,  
            Title:'',
            text: 'Thêm mới',
            second: false,
            selectedCheck: false,
            show: false,
            focusOn: false,
            Fees:{},
            popup:{
                deleteOne: false,
                deleteMulti: false,
                deleteFail: false
            },
            Fee:{},
            FeeId: '',
            FeeGroups:{},
            feeGroups:{},
            UnitFees:{},
            unitFees:{},
            FeeRanges:{},
            feeRanges:{}
        }
    },
    components:{
        NewButton,
        Detail,
        DeletePopup,
    },
    watch:{
        /**
         * hàm theo dõi sự thay đổi  của biến focus 
         * Nếu biến này thay đổi thì Thực hiện focus đến ô Tên khoản thu
         */
        focusOn:function(){
            this.$nextTick(()=>{
                this.$refs.detail.$refs.feeName.focus();
            })
        }
    },
    methods:{
        /**
         * Hàm laod khoản thu ngừng theo dõi
         */
        LoadFeeStopFollow:function(){
            this.selectedCheck = !this.selectedCheck;
            if(this.selectedCheck == true){
                axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((result)=>{this.Fees = result.data.data})
            }
            else{
                this.LoadData();
            }
        },
        /**
         * Hàm mở form để thêm khoản thu mới
         */
        OpenForm: function(){
            this.show = true;
            this.Fee = {}
            this.focusOn = true
            setTimeout(()=>{
                this.Fee = {}
                this.feeGroups = {...this.FeeGroups},
                this.unitFees = {...this.UnitFees},
                this.feeRanges = {...this.FeeRanges}
            },0)
            this.Title="Thêm khoản thu"
            this.update = false
        },
        /**
         * Hàm đóng form thêm, sửa 
         */
        CloseForm:function(){
            this.show = false;
            this.focusOn = false;
            this.Fee = {}
            this.selectedCheck = false;
            setTimeout(()=>{
                    this.LoadData();
                },1000
            )
            
        },
        /**
         * Hàm mở form để chỉnh sửa thông tin khoản thu
         * Dữ liệu được tải tự động lên form
         */
        RowEdit: function(Fee){
            this.show = true;
            this.focusOn = true
            setTimeout(()=>{
                this.Fee = {...Fee}
                this.feeGroups = {...this.FeeGroups},
                this.unitFees = {...this.UnitFees},
                this.feeRanges = {...this.FeeRanges}
            },0)
            this.Title="Sửa khoản thu",
            this.update = true
            
        },
        DeletePopup(FeeId){
            this.popup.deleteOne = true;
            this.FeeId = FeeId;
        },

        DeleteCancel:function(){
            this.popup.deleteOne = false;
            this.popup.deleteMulti = false;
            this.popup.deleteFail = false;
            this.FeeId = '';
        },
        /**
         * Hàm xóa 1 dòng dữ liệu
         * và đóng thông báo
         */
        DeleteOne:function(FeeId){
            var rowaffect = axios.delete('https://localhost:44341/api/v1/Fee/'+FeeId)
            console.log(rowaffect);
            this.popup = false
            this.FeeId = '';
            this.LoadData();
        },
        /**
         * Hàm laod lại dữ liệu khi có thay đổi
         */
        LoadData:function(){
            axios.get('https://localhost:44341/api/v1/fee').then((res)=>{this.Fees = res.data; console.log(this.Fees)});
        },
        /**
         * Hàm format kỳ thu
         */
        TurnFeeFormat:function(turn){
            if(turn == 0){
                return "Tháng"
            }
            else if(turn == 1){
                return "Quý"
            }
            else if(turn == 2){
                return "Học kỳ"
            }
            else{
                return "Năm học"
            }
        },
        FormatAmountOfFee(amount, turn){
            if(turn == 0){
                return amount+"đ/Tháng"
            }
            else if(turn == 1){
                return amount+"đ/Quý"
            }
            else if(turn == 2){
                return amount+"đ/Học kỳ"
            }
            else{
                return amount+"đ/Năm học"
            }
        }
    },
    async created() {
        const res = await axios.get('https://localhost:44341/api/v1/fee');
        this.Fees = res.data
        const res_sub = await axios.get('https://localhost:44341/api/v1/FeeGroup')
        this.FeeGroups = res_sub.data
        const unit = await axios.get('https://localhost:44341/api/v1/UnitFee')
        this.UnitFees = unit.data
        const range = await axios.get('https://localhost:44341/api/v1/FeeRange')
        this.FeeRanges = range.data
    },
}
</script>

<style lang="css">
    @import '../../css/dictionary/revenue/revenue.css';
</style>