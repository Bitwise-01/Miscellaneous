/*
 * Date: 03/03/2018
 * Author: Ethical-H4CK3R
 * Description: Type by abusing the space key. 
 *              Just inject this code into the console of your browser while on the site.
 */

var input=document.getElementById("inputfield");
$(window).keypress(function(){
 var timer=document.getElementById("timer").innerText;
 var word=document.getElementsByClassName('highlight')[0];
 if(word){input.value=word.innerText;}else{input.disabled=true;}
 if(timer=='1:00'||timer=='0:00'){input.disabled=false;}
});
