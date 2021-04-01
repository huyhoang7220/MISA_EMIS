<template>
    <div class="label">
        <label for="">{{text}}<span class="required" v-if="required">*</span></label>
    </div>
</template>
<script>
export default {
    props:{
        text: String,
        required: Boolean
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
    .required{
        color: red;
        font-size: 12px;
    }
</style>