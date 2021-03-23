<template>
        <div class="button" :class="{'second-button':second}" :style="pathImage">
            {{Text}}
        </div>
</template>

<script>

export default {
    props:['Text','second','image'],
    data() {
        return {
            primaryBtn: 'button',
            pathImage : 'background-image:url(../../assets/image/'+this.image+')',
        }
    },
    created() {
        console.log(this.Text, this.second);
    },
}
</script>

<style lang="css">
    .button{
        padding: 0px 12px;
        height: 32px;
        min-width: 96px;
        font-family: OpenSan-Semibold;
        font-size: 13px;
        color: #FFFFFF;
        margin: 0px 0px 0px 8px;
        border-radius: 4px;
        background: #03ae66;
        line-height: 32px;
        text-align: center;
        background-position: center;
        background-size: contain;
    }
    .button:hover{
        background-color: #02BF70;
        color: #FFFFFF;
        cursor: pointer;
    }
    .button:disabled{
        background-color: #e0e0e0;
        color: #a6a6a6;
        cursor: not-allowed;
    }
    .second-button{
        background-color: #FFFFFF !important;
        color: #3d3f4e;
        border: 1px solid #0FA655;
    }
    .second-button:hover{
        background-color: #f8f8f8 !important;
        cursor: pointer;
        color: #000000;
    }
    .second-button:disabled{
        background-color: #e0e0e0;
        color: #a6a6a6;
        cursor: not-allowed;
    }
</style>