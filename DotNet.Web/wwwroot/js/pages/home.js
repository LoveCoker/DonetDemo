define(function (require, exports, module) {
    exports.Init = function () {
        module.bindRegisterBlur();
    }
    //绑定失去焦点事件
    module.bindRegisterBlur = function () {
        console.log("1");
    }
})