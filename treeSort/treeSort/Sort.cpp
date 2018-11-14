#include "Sort.h"

Sort::Sort(int numbers[MAX_NODES]) {
	for (unsigned int n = 0; n < MAX_NODES; n++) {
		nodes[n] = numbers[n];

		if (!n) {
			rootNode = &nodes[n];
		}
	}

	setNodes();
}

void Sort::setNodes() {
	for (unsigned int n = 1; n < MAX_NODES; n++) {
		insertNode(rootNode, &nodes[n]);
	}
}

void Sort::insertNode(Node* parentNode, Node* node) {

	if (parentNode->getNumber() > node->getNumber()) {

		if (!parentNode->isLeftNodeSet()) {
			parentNode->setLeftNode(node);
		}
		else {
			insertNode(parentNode->getLeftNode(), node);
		}

	}
	else {

		if (!parentNode->isRightNodeSet()) {
			parentNode->setRightNode(node);
		}
		else {
			insertNode(parentNode->getRightNode(), node);
		}

	}
}

void Sort::sort() {
	getNodesValue(rootNode);
}

void Sort::getNodesValue(Node* node) {
	if (node->isLeftNodeSet()) {
		getNodesValue(node->getLeftNode());
	}

	std::cout << "number: " << node->getNumber() << std::endl;

	if (node->isRightNodeSet()) {
		getNodesValue(node->getRightNode());
	}
}