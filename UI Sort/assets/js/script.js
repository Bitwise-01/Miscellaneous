window.onload = function() {
	var submit = document.getElementById("submit");
	submit.addEventListener("click", doAlgorithm);
}

function doAlgorithm() {
    var nlist = '';
	var result = document.getElementById("result");
	var line = document.getElementById("sorted-line");
    var unsorted = document.getElementById("unsorted").value;
	var sorted_text = document.getElementById("sorted-text");
    
    if (unsorted) {
    	var treeSort = new Tree(unsorted);
        var list = treeSort.sort();

    	for(var n=0; n<list.length; n++) {
    		nlist += (n != (list.length-1)) ? list[n] + ", " : list[n];
    	}	
    }
       
    if (unsorted && nlist) {
    	result.value = nlist;
    	line.style.opacity = 1;
    	result.style.opacity = 1;
    	sorted_text.style.opacity = 1;
    } 
}

class Node {
	constructor(node) {
    	this.number = node;
      	this.leftNode = null;
      	this.rightNode = null;
      	this.nodes = {'left': [], 'right': []};
	}

	add(newNode, node=null) {
		if (!node) {
			var number = (!(this.number instanceof Node)) ? this.number : this.number.number;

			/* prevent repeats */
			if (newNode.number == number) {
				return;
			}

			if (newNode.number < number) {
            	if (!this.leftNode) {
            		this.leftNode = newNode;
            	} else {
            		this.add(newNode, this.leftNode);
            	}
			} else {
				if (!this.rightNode) {
					this.rightNode = newNode;
				} else {
					this.add(newNode, this.rightNode);
				}
			}
		} else {
			/* prevent repeats */
			if (newNode.number == node.number) {
				return;
			}

			if (newNode.number < node.number) {
				if (!node.leftNode) {
					node.leftNode = newNode;
				} else {
					node.add(newNode, node.leftNode);
				}
			} else {
				if (!node.rightNode) {
					node.rightNode = newNode;
				} else {
					node.add(newNode, newNode.leftNode);
				}
			}
		}

     }

	retrieveLeftNodes(node = null) {
		if (!node) {
			if (this.leftNode) {
				this.retrieveLeftNodes(this.leftNode);
			}
		} else {
			if (node.leftNode) {
				this.retrieveLeftNodes(node.leftNode)
			}

			this.nodes['left'].push(node.number);
			if (node.rightNode) {
				this.retrieveLeftNodes(node.rightNode);
			}
		}
	}

	retrieveRightNodes(node = null) {

		if (!node) {
			if (this.rightNode) {
				this.retrieveRightNodes(this.rightNode);
			}
		} else {
			if (node.leftNode) {
				this.retrieveRightNodes(node.leftNode);
			} 

			this.nodes['right'].push(node.number);
			if (node.rightNode) {
				this.retrieveRightNodes(node.rightNode);
			}
		}
	}
}

class Tree {
	constructor(string_numbers) {
		this.numbers = this.toNode(this.toList(string_numbers));
		this.root = this.numbers[Math.floor(this.numbers.length/2)];

        /* add nodes into the root node */
		for(var n=0; n<this.numbers.length; n++) {
			this.root.add(this.numbers[n]);
		}
	}

	toList(string) {
		var nlist = [];
		var list = string.split(',');
		
		for(var n=0; n<list.length; n++) {
			if(list[n].trim()) {
				nlist.push(parseInt(list[n]));
			}
		}
		return nlist;
	}

	toNode(nlist) {
		var list = [];

		for(var n=0; n<nlist.length; n++) {
			var node = new Node(nlist[n]);
			list.push(node);
		}		
		return list;
	}

	sort() {
		this.root.retrieveLeftNodes();
		this.root.retrieveRightNodes();
		this.root.nodes['left'].push(this.root.number);
		return this.root.nodes['left'].concat(this.root.nodes['right']);
	}
}