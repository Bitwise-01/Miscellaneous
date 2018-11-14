#pragma once
#include "Node.h"
#include <iostream>

constexpr int MAX_NODES = 9;

class Sort
{
private:
	Node* rootNode;
	Node nodes[MAX_NODES];

	void setNodes();
	void getNodesValue(Node* node);
	void insertNode(Node* parentNode, Node* node);
public:
	Sort(int numbers[MAX_NODES]);
	void sort();
};