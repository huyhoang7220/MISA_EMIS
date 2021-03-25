<template>
    <div class="input">
        <input type="text" ref="textbox" class="textbox" :class="{'margin-r-16':margin}">
    </div>
</template>

<script>

export default {
    props:{
        placeHolder: String,
        focus: Boolean,
        margin: Boolean,
        text: String
    },
    data(){
        return{
              ntext : this.text
        } 
    },
    watch:{
        focus:function(){
            this.$nextTick(()=>{
                this.$refs.textbox.focus();
            })
        }
    }
}
</script>

<style lang="css" scoped>
    .input{
        width: 100%;
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
    }
    .textbox:focus{
        outline: none;
        border: 1px solid #00d469;
    }
    .margin-r-16{
        margin-right: 16px;
    }
</style>