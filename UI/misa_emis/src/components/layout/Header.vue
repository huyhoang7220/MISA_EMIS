<template>
    <div class="header">
        <div class="header-left">
            <div class="header-left-text">Lập kế hoạch thu</div>
            <div class="header-left-icon"></div>
        </div>
        <div class="header-right">
            <div class="hr-item1">
                <div class="hr-item-icon"></div>
                <div class="hr-item-text">[Điểm thi] Trường mấu giáo Edu Platform1</div>
            </div>
            <div class="hr-item2">
                <select id="yearselect">
                    <option value="0">2020 - 2021</option>
                </select>
            </div>
            <div class="hr-item3">
                <div class="hr-item-icon1"></div>
                <div class="hr-item-icon2"></div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style lang="css">
    .header{
        width: 100%;
        height: 46px;
        box-shadow: 1px 1px 1px #000000;
        display: flex;
        align-items: center;
        background-color: #FFFFFF;
        justify-content: space-between;
        z-index: 20;
    }
    .header-left{
        display: flex;
    }
    .header-left-text{
        font-family: OpenSan-Semibold;
        font-size: 16px;
        margin-right: 12px;
        margin-left: 16px;
    }
    .header-left-icon{
        background-image: url('../../assets/image/ic_Info_20.svg');
        width: 24px;
        height: 24px;
        background-repeat: no-repeat;
        background-size: contain;
        background-position: center;
    }
    .header-right{
        display: flex;
        align-items: center;
        font-size: 13px;
    }
    .hr-item1,.hr-item2,.hr-item3{
        height: 32px;
    }
    .hr-item1{
        display: flex;
        align-items: center;
    }
    .hr-item-icon{
        width: 32px;
        height: 32px;
        background-image: url('../../assets/image/home.svg');
        background-position: center;
        background-repeat: no-repeat;
        background-size: cover;
        margin-right: -1px;
        z-index: 50;
    }
    .hr-item-text{
        border: 1px solid #CECECE;
        height: 30px;
        line-height: 30px;
        margin-right: 16px;
        padding: 0px 12px;
        border-radius: 0px 4px 4px 0px;
    }
    .hr-item2 select{
        height: 32px;
        border: 1px solid #CECECE;
        padding: 0px 12px;
        border-radius: 4px;
        margin-right: 16px;
    }
    .hr-item2 select:focus{
        outline: none;
    }
    .hr-item3{
        display: flex;
        height: 32px;
        border-left: 1px solid #CCCCCC;
    }
    .hr-item-icon1, .hr-item-icon2{
        width: 32px;
        height: 32px;
        background-size: contain;
        background-position: center;
        margin-left: 16px;
        background-repeat: no-repeat;
    }
    .hr-item-icon1{
        background-image: url('../../assets/image/search.svg');
        
    }
    .hr-item-icon2{
        background-image: url('../../assets/image/Avatar.png');
        margin-right: 16px;
    }
</style>