#pragma once

class Node
{
private:
	int number;
	Node* leftnode;
	Node* rightnode;

	bool _isLeftNodeSet;
	bool _isRightNodeSet;

public:
	Node();
	Node(int number);
		
	Node* getLeftNode();
	Node* getRightNode();

	int getNumber();
	bool isLeftNodeSet();
	bool isRightNodeSet();

	void setLeftNode(Node* node);
	void setRightNode(Node* node);
};