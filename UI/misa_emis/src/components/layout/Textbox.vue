<template>
    <div class="input">
        <input type="text" class="textbox">
    </div>
</template>

<script>

export default {
    props:{
        placeHolder: String,
        focus: Boolean
    }
}
</script>

<style lang="css" scoped>
    .input{
        display: flex;
    }
    .textbox{
        font-family: OpenSan-Regular;
        height: 32px;
        box-sizing: border-box;
        background-color: #ffffff;
        border: 1px solid #CCCCCC;
        border-radius: 4px;
        padding: 0px 12px;
        flex-grow: 1;
        flex-shrink: 1;
        flex-basis: 0%;
        margin-right: 16px;
    }
    .textbox:focus{
        outline: none;
        border: 1px solid #00d469;
    }
   
</style>