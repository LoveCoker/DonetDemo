define(function (require, exports, module) {
    exports.Init = function () {
        module.bindRegisterBlur();
        this.loadEvents();
    }
    //绑定失去焦点事件
    module.bindRegisterBlur = function () {
        //验证账号
        $("input[name=name]").blur(function () {
            let exit= module.ajaxPost(ensureAccountAddress, $(this).val());
            if (exit) {

            }
        })
        //验证Email
        $("input[name=email]").blur(function () {
            let exit = module.ajaxPost(ensureEmailAddress, $(this).val())
            if (exit) {

            }
        })
        //验证密码
        $("input[name=pwdEnsure]").blur(function () {
            let pwd = $("input[name=pwd]").val();
            let pwdEnsure = $(this).val();
            if (pwd == "" || pwdEnsure == "" || pwd != pwdEnsure) {

            }
        })
    }
    module.ajaxPost = function (url, data) {
        $.ajax({
            type: "POST",
            url: url + '?t=' + Math.random(),
            data: { value: data },
            dataType: "json",
            success: function (result) {
                if (result != null && result.exit == false) {
                    return true;
                } else {
                    return false;
                }
            },
            error: function () {
                return false;
            }
        });
    }
    //各种事件
    exports.loadEvents = function() {
        //绑定点击切换验证码事件
        $('#img').on('click', function (e) {
            var str = $("#img").attr("src") + "1";
            $("#img").attr("src", str);
        });
    };
})