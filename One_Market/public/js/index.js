// Toggle Function
$('.toggle').click(function(){
  // Switches the Icon
  $(this).children('i').toggleClass('fa-pencil');
  // Switches the forms  
  $('.form').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
});



$('.displayP').click(function()
{
  // Switches the table  
  $('.tableP').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayP').text() == "Hide")
  {
    $(".displayP").html('Display');
  }
  else
  {
    $(".displayP").html('Hide');
  }
});



$('.displayR').click(function()
{
  // Switches the table  
  $('.tableR').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayR').text() == "Hide")
  {
    $(".displayR").html('Display');
  }
  else
  {
    $(".displayR").html('Hide');
  }
});



$('.displayC').click(function()
{
  // Switches the table  
  $('.tableC').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayC').text() == "Hide")
  {
    $(".displayC").html('Display');
  }
  else
  {
    $(".displayC").html('Hide');
  }
});



$('.displayB').click(function()
{
  // Switches the table  
  $('.tableB').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayB').text() == "Hide")
  {
    $(".displayB").html('Display');
  }
  else
  {
    $(".displayB").html('Hide');
  }
});



$('.displayCu').click(function()
{
  // Switches the table  
  $('.tableCu').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayCu').text() == "Hide")
  {
    $(".displayCu").html('Display');
  }
  else
  {
    $(".displayCu").html('Hide');
  }
});



$('.displayO').click(function()
{
  // Switches the table  
  $('.tableO').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayO').text() == "Hide")
  {
    $(".displayO").html('Display');
  }
  else
  {
    $(".displayO").html('Hide');
  }
});



$('.displayPa').click(function()
{
  // Switches the table  
  $('.tablePa').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");
  
  if($('.displayPa').text() == "Hide")
  {
    $(".displayPa").html('Display');
  }
  else
  {
    $(".displayPa").html('Hide');
  }
});


$('.displayPr').click(function()
{
  // Switches the table
  $('.tablePr').animate({
    height: "toggle",
    'padding-top': 'toggle',
    'padding-bottom': 'toggle',
    opacity: "toggle"
  }, "slow");

  if($('.displayPr').text() == "Hide")
  {
    $(".displayPr").html('Display');
  }
  else
  {
    $(".displayPr").html('Hide');
  }
});


$("[type=file]").on("change", function(){
  // Name of file and placeholder
  var file = this.files[0].name;
  var dflt = $(this).attr("placeholder");
  if($(this).val()!=""){
    $(this).next().text(file);
  } else {
    $(this).next().text(dflt);
  }
});
