#include "Node.h"
#include <iostream>

Node::Node() {}

Node::Node(int number)
{
	this->number = number;
	_isLeftNodeSet = false;
	_isRightNodeSet = false;
}

int Node::getNumber() {
	return number;
}

Node* Node::getLeftNode() {
	return leftnode;
}

Node* Node::getRightNode() {
	return rightnode;
}

bool Node::isLeftNodeSet() {
	return _isLeftNodeSet;
}

bool Node::isRightNodeSet() {
	return _isRightNodeSet;
}

void Node::setLeftNode(Node* node) {
	leftnode = node;
	_isLeftNodeSet = true;
}

void Node::setRightNode(Node* node) {
	rightnode = node;
	_isRightNodeSet = true;
}