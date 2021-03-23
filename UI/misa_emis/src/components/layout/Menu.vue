<template>
    <div class="menu">
        <div class="logo-box">
            <div class="logo"> </div>
            <div class="web-title">
                Khoản thu
            </div>
            <div class="toggle-btn"></div>
        </div>
        <div class="nav-content">
            <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon dashroad-icon"></div>
                <div class="nav-item-text">Tổng quan</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon plan-icon"></div>
                <div class="nav-item-text">Lập kết hoạch thu</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon manage-revenue-icon"></div>
                <div class="nav-item-text">Quản lý thu</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon manage-bill-icon"></div>
                <div class="nav-item-text">Quản lý hóa đơn</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon mountofdebt-icon"></div>
                <div class="nav-item-text">Số phải thu, phải trả</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon report-icon"></div>
                <div class="nav-item-text">Báo cáo</div>
            </div>

             <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon message-icon"></div>
                <div class="nav-item-text">Tin nhắn</div>
            </div>

            <div class="nav-item">
                <div class="select-highline"></div>
                <div class="nav-item-icon system-icon"></div>
                <div class="nav-item-text">Hệ thống</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style lang="css">
@font-face {
  font-family: OpenSan-Bold;
  src: url('../../assets/Fonts/OpenSans-Bold.ttf');
}
    .menu{
        background-color: #24344b;
        width: 260px;
        min-width: 260px;
        max-width: 260px;
        height: 100vh;
        margin:  0px;
    }
    .logo-box{
        height: 46px;
        box-shadow: 0px 0px 1px #000000;
        display: flex;
        align-items: center;
        position: relative;
    }
    .logo{
        height: 32px;
        width: 32px;
        margin-left: 10px;
        background-image: url('../../assets/image/ic_KhoanThu_56.svg');
        background-position: center;
        background-size: contain;
        background-repeat: no-repeat;
    }
    .web-title{
        font-family: OpenSan-Semibold;
        color: #ffffff;
        font-size: 15px;
        margin-left: 8px;
    }
    
    .toggle-btn{
        position: absolute;
        top: 50%;
        right: 16px;
        transform: translate(0%,-50%);
        width: 16px;
        height: 16px;
        background-repeat: no-repeat;
        background-size: contain;
        background-position: center;
        background-image: url('../../assets/image/hamburger-menu.svg');
        
    }

    .nav-content{
        margin-top: 16px;
        width: 100%
    }
    .nav-item{
        width: 100%;
        height: 46px;
        display: flex;
        align-items: center;
        background-color: #24344b;
        padding-left: 10px;
        cursor: pointer;
    }
    .nav-item:hover{
        background-color:#4D4F5C;
        border-left: 4px solid #03ae66;
        color: #03ae66;
    }
    .nav-item-icon{
        width: 32px;
        height: 32px;
        background-position: center;
        background-position: center;
        background-repeat: no-repeat;
    }
    .nav-item-text{
        color:  #ffffff;
        font-size: 13px;
        margin-left: 16px;
    }
        .dashroad-icon{
            background-image: url('../../assets/image/ic_TongQuan_32.svg');
        }
        .plan-icon{
            background-image: url('../../assets/image/ic_LapKeHoachThu_32.svg');
        }
        .manage-revenue-icon{
            background-image: url('../../assets/image/ic_QuanLyThu_32.svg');
        }
        .manage-bill-icon{
            background-image: url('../../assets/image/ic_HoaDon_32.svg');
        }
        .mountofdebt-icon{
            background-image: url('../../assets/image/ic_SoThu_32.svg');
        }
        .report-icon{
            background-image: url('../../assets/image/ic_BaoCao_32.svg');
        }
        .message-icon{
            background-image: url('../../assets/image/ic_TinNhan_32.svg');
        }
         .system-icon{
            background-image: url('../../assets/image/ic_HeThong_32.svg');
        }
</style>