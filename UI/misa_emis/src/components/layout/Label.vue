<template>
    <div class="label">
        <label for="">{{text}}</label>
    </div>
</template>
<script>
export default {
    props:{
        text: String,
    }
}
</script>
<style lang="css" scoped>
    .label label{
        margin-top: 16px;
        display: inline-block;
        font-size: 12px;
        font-family: OpenSan-Regular;
        color: #757575;
    }
</style>