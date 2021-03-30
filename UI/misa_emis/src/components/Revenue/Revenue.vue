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
                    <NewButton title="Xóa toàn bộ các khoản thu đã chọn"
                    :Text="'Sắp lại thứ tự'"
                        :second="true"
                        />
                    <div class="trash-btn" @click="PopupDeleteMulti()">

                    </div>
                </div>
            </div>

            <div class="grid-list">
                <div class="outline-table">
                <table cellspacing="0" cellpadding="0" border="0">
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
                        <th colspan="1" style="min-width: 96px">
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
                    <tr v-for="fee in Fees" :key="fee.feeId"
                        @change="fee.selected = false"
                        :class="{'row-focus':fee.selected}">
                        <td colspan="1"><div class="select-line"
                            @click="fee.selected = !fee.selected;CheckLine(fee.feeId,fee.selected);" 
                            :class="{'selected-line':fee.selected}"></div>
                        </td>
                        <td colspan="1" @click="RowEdit(fee,GetFormatMoney(fee.amountOfFee))">
                            <div class="main-cell">
                                <div class="cell-link">{{fee.feeName}}</div>
                                <div class="important" v-if="fee.important">
                                    <div class="tooltip-cell">Đây là khoản thu mặc định của hệ thống, bạn không thể xóa.</div>
                                </div>
                            </div>
                        </td>
                        <td colspan="1" >{{fee.feeGroupName}}</td>
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
                                <div class="btn-edit" @click="RowEdit(fee)" title="Chỉnh sửa dòng dữ liệu này"></div>
                                <div class="btn-copy" title="Sao chép dòng dữ liệu này"></div>
                                <div class="btn-delete" @click="DeletePopup(fee.feeId)" title="Xóa dòng dữ liệu này"></div>
                            </div>
                        </td>
                    </tr>
                </table>
                </div>
            </div>
            <div class="footer">
                <div class="result">
                    Tổng số: <span class="count">{{CountRow()}}</span> kết quả.
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
        <!-- Popup hỏi người dùng xóa dòng vừa chọn hay không (Xóa 1 dòng) -->
        <DeletePopup 
        v-show="popup.deleteOne" 
        :text="'Bạn có chắc muốn xóa khoản thu đã chọn?'"
        :secondbtn="true"
        :firstbtn="true"
        @DeleteCancel="DeleteCancel()"
        @DeleteOne="DeleteOne"
        :FeeId="FeeId"/>

        <!-- Popup hỏi người dùng có muốn xóa những dòng đã chọn hay không -->
        <DeletePopup 
        v-show="popup.deleteMulti"
        :secondbtn="true"
        :firstbtn="true"
        :text="'Bạn có chắc muốn xóa những khoản thu đã chọn?'"
        @DeleteMulti="DeleteAllSelected()"
        @DeleteCancel="DeleteCancel()"
        />

        <DeletePopup 
        v-show="notify"
        :text="notifyText"
        :secondbtn="false"
        @ClosePopup="ClosePopup()"
        :thirdbtn="true"
        :firstbtn="false"
        />
        <!-- Preload khi xóa dữ liệu -->
        <div class="preload" v-show="loading">
        </div>
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
            /**Biến truyền vào tên của dialog  */
            Title:'',
            /**Tên nút thêm mới  */
            text: 'Thêm mới',
            /**Biến kiểm tra xem có thêm nút thứ 2 trong dialog */
            second: false,
            /**Kiểm tra checkbox ngừng theo dõi */
            selectedCheck: false,
            /** */
            show: false,
            /**Biến theo dõi sự thay đổi để forcus vào ô textbox Tên nhóm khách hàng*/
            focusOn: false,
            /**Danh sách khoản thu */
            Fees:{},
            /**Kiểm tra loại hiển thị thông báo */
            popup:{
                deleteOne: false,
                deleteMulti: false,
                deleteFail: false
            },
            /**Biến bật popup thông báo */
            notify: false,
            /**Biến truyền câu thông báo vào popup */
            notifyText: '',
            /**Đối tượng khoản thu */
            Fee:{},
            /**Biến lưu 1 giá trị khóa chính của khoản thu */
            FeeId: '',
            /**
             * Nhóm khoản thu lấy được từ server
             */
            FeeGroups:{},
            /**
             * Dữ liệu được gửi qua prop vào Form thêm , sửa
             */
            feeGroups:{},
            /**
             * Dữ liệu đơn vị khoản thu được lấy từ server
             */
            UnitFees:{},
            /**
             * Đơn vị khoản thu truyền qua props vào from thêm sửa
             */
            unitFees:{},
            /**
             * Phạm vi thu nhận được từ phía server
             */
            FeeRanges:{},
            /**
             * Phạm vi thu truyền qua props vào from thêm, sửa
             */
            feeRanges:{},
            /**Biến bật tắt preload*/
            loading : false,
            /**Danh sách khóa chính của các dòng trong lưới được đánh dấu  */
            ListFee:[]
        }
    },
    components:{
        NewButton,
        Detail,
        DeletePopup,
    },
    watch:{
        /**
         * Created by : VXKHANH
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
         * Created by : VXKHANH
         * Hàm đóng thông báo. Dành cho thông báo lỗi hoặc thành công
         * Không thực hiện thêm event gì
         */
        ClosePopup(){
            this.notify = false;
        },
        /**
         * Created by : VXKHANH
         * 
         * Hàm laod khoản thu ngừng theo dõi
         */
        LoadFeeStopFollow:async function(){
            this.selectedCheck = !this.selectedCheck;
            if(this.selectedCheck == true){
                this.Fees = await axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((result)=>{return result.data})
            }
            else{
                this.LoadData();
            }
        },
        /**
         * Cretated by: VXKHANH
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
         * Created by: VXKHANH
         * Hàm đóng form thêm, sửa 
         */
        CloseForm: async function(){
            this.show = false;
            this.focusOn = false;
            this.Fee = {}
            if(this.selectedCheck == true){
                this.Fees = await axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((result)=>{return result.data})
            }
            else{
                this.LoadData()
            }  
        },
        /**
         * Created by: VXKHANH
         * Hàm mở form để chỉnh sửa thông tin khoản thu
         * Dữ liệu được tải tự động lên form
         */
        RowEdit: function(Fee, amount){
            this.show = true;
            this.focusOn = true
            
            setTimeout(()=>{
                this.Fee = {...Fee}
                this.Fee.amountOfFee = amount
                this.feeGroups = {...this.FeeGroups},
                this.unitFees = {...this.UnitFees},
                this.feeRanges = {...this.FeeRanges}
            },0)
            this.Title="Sửa khoản thu",
            this.update = true
            
        },
        /**
         * Created by: VXKHANH
         * Hàm xóa 1 dòng. Thực hiện sau khi nhẫn nút xóa trên popup
         */
        DeletePopup(FeeId){
            this.popup.deleteOne = true;
            this.FeeId = FeeId;
        },
        /**
         * Created by: VXKHANH
         * Hàm hủy xóa 
         */
        DeleteCancel:function(){
            this.popup.deleteOne = false;
            this.popup.deleteMulti = false;
            this.popup.deleteFail = false;
            this.FeeId = '';
            this.ListFee = [];
        },
        /**
         * Created by: VXKHANH
         * Hàm xóa 1 dòng dữ liệu
         * và đóng thông báo
         */
        DeleteOne: async function(FeeId){
            var rowaffect
            rowaffect = await axios.delete('https://localhost:44341/api/v1/Fee/'+FeeId).then((response)=>{ return response.data.data;})
            
            this.popup.deleteOne = false;
            this.popup.deleteMulti = false;
            this.popup.deleteFail = false;
            this.FeeId = '';

                if(rowaffect == 1){
                    this.notifyText = "Đã xóa khoản thu!"
                    this.notify = true;

                }
                else{
                    this.notifyText = "Bạn không thể xóa dữ liệu của hệ thống!"
                    this.notify = true;
                }
                if(this.selectedCheck == true){
                    this.Fees = await axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((result)=>{return result.data})
                }
                else{
                    this.LoadData()
                }
              
            },
        /**
         * Created by: VXKHANH
         * Hàm laod lại dữ liệu khi có thay đổi (Đang theo dõi)
         */
        LoadData: async function(){
            this.loading = true
            this.Fees =  await axios.get('https://localhost:44341/api/v1/fee').then((respons)=>{
                return respons.data
            })
            this.loading = false
        },
        LoadDataStopFollow: async function(){
            this.Fees =  await axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((respons)=>{
                return respons.data
            })
        },
        /**
         * Created by: VXKHANH
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
        /**
         * Created by: VXKHANH
         * Hàm format số tiền
         */
        FormatAmountOfFee(amount, turn){
            var money = amount.toFixed(0);
            money = money.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1.');
            //var RightFormat = money.split(".")
            if(turn == 0){
                return money+"đ/Tháng"
            }
            else if(turn == 1){
                return money+"đ/Quý"
            }
            else if(turn == 2){
                return money+"đ/Học kỳ"
            }
            else{
                return money+"đ/Năm học"
            }
        },
        /**
         * Created by : VXKHANH
         * Hàm định dạng lại số tiền 
         * */
        GetFormatMoney(amount){
            var money = amount.toFixed(0);
            money = money.toString().replace(/(\d)(?=(?:\d{3})+$)/g, '$1.');
            return money
        },
        /**
         * Created by: VXKHANH
         * Hàm lấy danh sách những trường được chọn  
         * */
        CheckLine:function(feeId,selected){
            //Dùng hàm push để thêm khoản thu vừa chọn vào trong mảng
            if(selected == true){
                this.ListFee.push(feeId)
            }else{ 
                var index = this.ListFee.indexOf(feeId)
                this.ListFee.splice(index, 1);
            }
        },
        /**Hàm đếm số lượng bản ghi đang có */
        CountRow(){
            if(this.Fees.length >= 1){  
                return this.Fees.length
            }
            else{
                return 0;
            }
        },
        PopupDeleteMulti(){
            this.popup.deleteOne = false;
            this.popup.deleteMulti = true;
            this.popup.deleteFail = false;
        },
        /**
         * created by: VXKHANH
         * 
         * Hàm xóa nhiều dữ liệu 1 lúc
         */
        DeleteAllSelected: async function(){
            var rowaffect  = await axios({
                method: 'DELETE',
                url : 'https://localhost:44341/api/v1/Fee/DeleteMulti', 
                data: JSON.stringify(this.ListFee), 
                headers:{'Content-Type': 'application/json; charset=utf-8'}
            }).then((result)=>{
                return result.data.data;
            })
            this.popup.deleteOne = false;
            this.popup.deleteMulti = false;
            this.popup.deleteFail = false;
            
            if(rowaffect >= 1){
                this.notifyText = "Đã xóa những khoản thu này!"
                this.notify = true;
                this.ListFee = []
            }
            else{
                this.notifyText = "Bạn không thể xóa dữ liệu của hệ thống!"
                this.notify = true;
            }
            if(this.selectedCheck == true){
                this.Fees = await axios.get('https://localhost:44341/api/v1/fee/feestopfollow').then((result)=>{return result.data})
            }
            else{
                this.LoadData()
            }
        }
    },
    async created() {
        // this.loading = true;
        const res = await axios.get('https://localhost:44341/api/v1/fee');
        this.Fees = res.data
        const res_sub = await axios.get('https://localhost:44341/api/v1/FeeGroup')
        this.FeeGroups = res_sub.data
        const unit = await axios.get('https://localhost:44341/api/v1/UnitFee')
        this.UnitFees = unit.data
        const range = await axios.get('https://localhost:44341/api/v1/FeeRange')
        this.FeeRanges = range.data
        // this.loading = false;
    },
}
</script>

<style lang="css">
    @import '../../css/dictionary/revenue/revenue.css';
</style>