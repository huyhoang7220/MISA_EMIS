<template>
    <div class="popup">
        <div class="popup-content">
            <div class="popup-title">Thông báo</div>
            <div class="popup-message">{{text}}</div>
            <div class="popup-btn">
                <Button :Text="'Không'" :second="true" v-if="secondbtn" :minwidth="true" @click="DeleteCancel()"/>
                <Button :Text="'Xóa'" :second="false" :minwidth="true" @click="DeleteOne()"/>
            </div>
            <div class="btn-close-form"
                @click="DeleteCancel()">
            </div>
        </div>
        <div class="blur"></div>
    </div>
</template>

<script>
import Button from '../layout/Button.vue'
export default {
    props:{
        secondbtn:Boolean,
        text:String,
        FeeId: String
    },
    components:{
        Button,
    },
    methods:{
        DeleteCancel:function(){
            this.$emit('DeleteCancel');
        },
        DeleteOne:function(){
            this.$emit('DeleteOne',this.FeeId)
        }
    }
}
</script>

<style lang="css" scoped>
    .popup-content{
        font-family: OpenSan-Regular;
        position: relative;
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
    .popup-content{
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        min-width: 300px;
        padding: 24px 16px 16px 16px;
        z-index: 300;
        background-color: #ffffff;
    }
    .popup-title{
        font-family: OpenSan-Semibold;
        font-size: 15px;
        line-height: 32px;
    }
    .popup-message{
        font-size: 13px;
        margin-top: 16px;
        margin-bottom: 16px;
    }
    .popup-btn{
        display: flex;
        justify-content: flex-end;
        align-content: center;
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
</style>