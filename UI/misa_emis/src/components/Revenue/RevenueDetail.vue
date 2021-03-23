<template>
    <div class="popup">
        <div class="form">
            <div class="form-left">
                
            </div>
        </div>
        <div class="blur">

        </div>
    </div>
</template>
<script>
export default {
    
}
</script>

<style lang="css" scoped>
    .form{
        position: absolute;
        top: 10%;
        left: 50%;
        transform: translate(-50%, 0%);
        width: 960px;
        height: 400px;
        background-color: #ffffff;
        z-index: 100;
    }
    .blur{
        top: 0px;
        left: 0px;
        width: 100%;
        height: 100%;
        background-color: black;
        position: absolute;
        opacity: 0.2;
        z-index: 50;
    }

</style>