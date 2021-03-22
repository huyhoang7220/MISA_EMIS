<template>
    <div class="button" v-bind:class="{'second-button':second}">
        {{text}}
    </div>
</template>

<script>
export default {
    props:{
        text: String,
        second: Boolean
    },
    data() {
        return {
            
        }
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
    }
    .button:hover{
        background-color: #02BF70;
        color: #FFFFFF;
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
    }
    .second-button:disabled{
        background-color: #e0e0e0;
        color: #a6a6a6;
        cursor: not-allowed;
    }
</style>