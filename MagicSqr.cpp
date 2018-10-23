constexpr unsigned int MAX_SIZE = 20;

#include <string>
#include <fstream>
#include <iostream>

int totalDiagonal1(int sqr[MAX_SIZE][MAX_SIZE], unsigned int size);
int totalDiagonal2(int sqr[MAX_SIZE][MAX_SIZE], unsigned int size);
void totalRows(int sqr[MAX_SIZE][MAX_SIZE], int rows[MAX_SIZE], unsigned int size);
void createSqr(int sqr[MAX_SIZE][MAX_SIZE], unsigned int& size, std::string file);
void totalColumns(int sqr[MAX_SIZE][MAX_SIZE], int columns[MAX_SIZE], unsigned int size);
bool isMagic(int rows[MAX_SIZE], int columns[MAX_SIZE], int diag1, int diag2, unsigned int size);

int main() {

	int diag1;
	int diag2;
	bool isMagical;
	std::string file;
	unsigned int size;
	int rows[MAX_SIZE];
	int columns[MAX_SIZE];
	int sqr[MAX_SIZE][MAX_SIZE];

	std::cout << "Enter the path to file: ";
	std::cin >> file;

	createSqr(sqr, size, file);
	totalRows(sqr, rows, size);
	totalColumns(sqr, columns, size);
	diag1 = totalDiagonal1(sqr, size);
	diag2 = totalDiagonal2(sqr, size);
	isMagical = isMagic(rows, columns, diag1, diag2, size);

	std::cout << "isMagical: " << ((isMagical) ? "True" : "False")  << std::endl;
	system("pause");
	return 0;
}

int totalDiagonal1(int sqr[MAX_SIZE][MAX_SIZE], unsigned int size) {

	int total = 0;
	for (unsigned int row = 0; row < size; row++) {
		total += sqr[row][row];
	}

	return total;
}

int totalDiagonal2(int sqr[MAX_SIZE][MAX_SIZE], unsigned int size) {

	int total = 0;
	unsigned int column = (size - 1);
	for (unsigned int row = 0; row < size; row++) {
		total += sqr[row][column];
		column -= 1;
	}

	return total;
}

void totalRows(int sqr[MAX_SIZE][MAX_SIZE], int rows[MAX_SIZE], unsigned int size) {

	int total;
	unsigned int n = 0; 

	for (unsigned int row = 0; row < size; row++) {
		total = 0;
		for (unsigned int column = 0; column < size; column++) {
			total += sqr[row][column];
		}
		rows[n] = total;
		n += 1;
	}
}

void createSqr(int sqr[MAX_SIZE][MAX_SIZE], unsigned int& size, std::string file) {

	int num;
	unsigned int row = 0;
	bool sizeAssigned = false;

	std::ifstream infile;
	infile.open(file);

	while (infile >> num) {

		if (!sizeAssigned) {
			size = num;
			sizeAssigned = true;
		}
		else {
			for (unsigned int column = 0; column < size; column++) {
				sqr[row][column] = num;

				if (column != (size - 1)) {
					infile >> num;
				}
			}
			row += 1;
		}
	}

	infile.close();
}

void totalColumns(int sqr[MAX_SIZE][MAX_SIZE], int columns[MAX_SIZE], unsigned int size) {

	int total;
	unsigned int n = 0;

	for (unsigned int row = 0; row < size; row++) {
		total = 0;
		for (unsigned int column = 0; column < size; column++) {
			total += sqr[column][row];
		}
		columns[n] = total;
		n += 1;
	}
}

bool isMagic(int rows[MAX_SIZE], int columns[MAX_SIZE], int diag1, int diag2, unsigned int size) {
	
	bool isMagical = true;

	if (diag1 != diag2) {
		isMagical = false; 
	}

	if (isMagical) {
		for (unsigned int n = 0; n < size; n++) {
			if (rows[n] != diag1) {
				isMagical = false;
			}
		}
	}

	if (isMagical) {
		for (unsigned int n = 0; n < size; n++) {
			if (columns[n] != diag1) {
				isMagical = false;
			}
		}
	}

	return isMagical;
}