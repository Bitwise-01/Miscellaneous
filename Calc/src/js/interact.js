/* 
 * Date: 04/05/2018
 * Author: Mohamed Sheikh
 * Description: Interact with the user. I couldn't get the decimal, +/-, % to work, but the other stuff work.
 */

var mem = ''; /* non computed */
var _mem = ''; /* computed */
var lastOperator = null;
var reg = new RegExp('[0-9]');

var signs = {
	'div': '/',
	'mul': '*',
	'sub': '-',
	'add': '+',
	'percent': '%',
	'decimal': '.',
	'plusmn': '+/-',

	'clear': clear,
	'equals': compute
}

window.onload = function() {
	setEvents();
	document.getElementById('display').innerHTML = 0;
}

function setEvents() {
	var buttons = [ 
		document.getElementById('zero'), document.getElementById('one'), document.getElementById('two'), 
		document.getElementById('three'), document.getElementById('four'), document.getElementById('five'),
		document.getElementById('six'), document.getElementById('seven'), document.getElementById('eight'),
		document.getElementById('nine'), document.getElementById('clear'), document.getElementById('div'), 
		document.getElementById('mul'), document.getElementById('sub'), document.getElementById('add'), 
		document.getElementById('equals')
	]

	for(var n=0; n<buttons.length; n++) {
		buttons[n].addEventListener('click', calc);
	}
}

function calc(event) {
	var value = event.path[0].innerHTML;
    
    if (!isNumber(value)) {
    	var sign = event.path[0].id;
    	
    	if(isMathFunction(sign)) {
    		signs[sign]();
    	} else {
    		splitValues(signs[sign]);
    		lastOperator = signs[sign];
    	}
    } else {
    	processNumber(value);
    }
}

function splitValues(sign) {	
	if (!mem) return;   

    if (_mem) {
    	_mem = calculate(lastOperator, mem);
    } else {
    	_mem = mem;
    }

	mem = '';
	display(_mem);
    lastOperator = sign;
}

function calculate(sign, currentNum) {
	var value;
	var x = parseInt(_mem);
	var y = parseInt(currentNum);

    switch(sign) {
    	case '/':
    		value = (x / y);
    		break;

    	case '*':
    		value = (x * y);
    		break;

    	case '-':
    		value = (x - y);
    		break;

    	case '+':
    		value = (x + y);
    		break;
    }
    return value;
}

function display(value) {
	value = (value >= 1000) ? addCommas(value.toString()) : value;
	document.getElementById('display').innerHTML = value;
}

function addCommas(value) {
	var n = 0;
	var cNumber;
	var items = '';
	var _value = '';
	var nNumber = '';
	var numbers = [];
	var _numbers = [];

	for(var i=(value.length-1); i>=0; i--) {
		n += 1; 
		items += value[i];

		if (n == 3) {
			numbers.push(items);

			n = 0;
			items = '';
		}

		if (i == 0) {
			var num = '';
			for(var r=(items.length-1); r>=0; r--) {
				num += items[r];
			}
			numbers.push(num);
		}
	} 

	numbers = numbers.reverse();	
	for(var n=0; n<numbers.length; n++) {
		cNumber = numbers[n];
		
		if (n) {
			for(var i=(cNumber.length-1); i>=0; i--) {
				nNumber += cNumber[i];
			}			
		}

		_numbers[n] = (n) ? nNumber : cNumber;
		nNumber = '';
	}

	numbers = [];
	for(var n=0; n<_numbers.length; n++) {
		if(_numbers[n]) {
			numbers[numbers.length] = _numbers[n];
		}
	}

	return numbers;
}

function processNumber(num) {
	mem += num;
	display(mem);
}

function isMathFunction(item) {
	return (item == 'equals' || item == 'clear') ? true : false; 
}

function isNumber(item) {
	return reg.test(item);
}

function compute() {
	if (!mem) return;
	if (!_mem) return;
	if (!lastOperator) return;
	splitValues(lastOperator);
}

function reset() {
	mem = '';
	_mem = '';
	lastOperator = null;
}

function clear() {
	reset();
	display(0);
}