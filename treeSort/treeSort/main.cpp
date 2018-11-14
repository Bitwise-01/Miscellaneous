#include "Node.h"
#include "Sort.h"
#include <iostream>

constexpr unsigned int MAX_NUMBERS = 9;

int main() {
	int numbers[MAX_NUMBERS] = { 4, 8, 5, 1, 9, 3, 6, 7, 2 };

	Sort sorter(numbers);
	sorter.sort();

	system("pause");
	return 0;
}