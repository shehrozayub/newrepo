function validationCheck(name) {
	var handle= $('input[name='+name+']');
	var text=document.getElementsByName(name)[0].value;

	if(text=="")
	{
	handle.addClass(' animated shake').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend',
		function()
		{
			$(this).removeClass(' animated shake')
		}
		);
	handle.attr('placeholder','Field Can Not Be Empty!')
	}
}

function validationCheckAccountID(name) {
    var handle = $('input[name=' + name + ']');
    var text = document.getElementsByName(name)[0].value;

    if (text == "") {
        handle.addClass(' animated shake').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend',
            function () {
                $(this).removeClass(' animated shake')
            }
            );
        handle.attr('placeholder', 'Field Can Not Be Empty!')
    }

    else {
        var d = { "acc": text };
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "/Accounts/getName",
            data: d,
            
            success: function(resp){
                document.getElementById('viewName').innerHTML = resp.nameToShow;
            }
        })   
    }

    }
