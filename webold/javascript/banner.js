//大封强推的轮播图
$(function () {
    var $div = $('.scBigImg dl');//放置大图容器
    var $nav = $('.scSmallImg li');//放置缩略图容器
    var num = -1;
    var open;
    function changeKv() {
        if(num>=$nav.length-1){
            num = 0;
        }else{
            num ++ ;
        }
        $nav.eq(num).trigger('mouseenter');
        open = setTimeout(changeKv,3000);
    }
    changeKv();
    $nav.each(function (index) {
        $(this).off('mouseenter').on('mouseenter',function () {
            clearTimeout(open);
			
            $(this).addClass('on').siblings().removeClass('on');
            $('.scBigImg dd').eq(index).addClass('on').siblings().removeClass('on');
            $('.scSmallImg').off('mouseleave').on('mouseleave',function () {
                num = index;
                setTimeout(function () {
                    changeKv();
                },3000)
            })
        });
    });
	 $div.each(function (index) {
        $(this).off('mouseenter').on('mouseenter',function () {
            clearTimeout(open);
			});
	});
});