#include <string>
#include <iostream>
#include <Windows.h>

// global constants
constexpr int DEAD = 0;
constexpr int ALIVE = 1;
constexpr unsigned int MAX_SIZE = 20;
constexpr double SLEEP_TIME_IN_SECONDS = 1;

// prototypes
int  newState(int neighbors, int currentState);
void userInput(int grid[MAX_SIZE][MAX_SIZE], int& max_gen);
bool isExtinct(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size);
void modifyCells(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size);
void displayGrid(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size);
void setDefaults(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size);
bool isAlive(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y);
void setCell(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y);
void removeCell(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y);
void copyGrid(int oldGrid[MAX_SIZE][MAX_SIZE], int newGrid[MAX_SIZE][MAX_SIZE], unsigned int max_size);

int main() {

	// Coodinates: 1
	// (0, 0) + (2, 2) => (2, 2)
	// (2, 1) + (2, 2) => (4, 3)
	// (1, 1) + (2, 2) => (3, 3)
	// (0, 1) + (2, 2) => (2, 3)

	// Coordinates: 2
	// (1, 0) + (1, 1) => (2, 1)
	// (2, 1) + (1, 1) => (3, 2)
	// (0, 2) + (1, 1) => (1, 3)
	// (1, 2) + (1, 1) => (2, 3)
	// (2, 2) + (1, 1) => (3, 3)

	int gen = 0; // keeps track of our generation
	int max_gen; // holds the value of the maximum generation
	bool isLimited = true; // when it's limited, the program will count the generation
	int grid[MAX_SIZE][MAX_SIZE]; // our grid

	setDefaults(grid, MAX_SIZE); // set all of the cells to dead
	userInput(grid, max_gen);	// get user input

	// if the user wants to keep the program to run until every cell is dead
	if (max_gen == -1) {
		max_gen = 1;
		isLimited = false;
	}
			
	// while the species isn't extinct and the max generation isn't reached
	while (!isExtinct(grid, MAX_SIZE) && (gen < max_gen)) { //  change != to <
		modifyCells(grid, MAX_SIZE); 
		displayGrid(grid, MAX_SIZE);

		// display the current generation to the user
		if (isLimited) {
			std::cout << "[-] Generation #: " << (gen + 1) << std::endl;
			std::cout << "[-] Max-Generation: " << max_gen << std::endl;
		}

		Sleep((DWORD)SLEEP_TIME_IN_SECONDS * 1000);

		if (isLimited) {
			gen += 1;
		}
	}

	// display to the user the reason for terminating the loop
	if (gen >= max_gen) {
		std::cout << "The maximum generation has been reached" << std::endl;
	}
	else if(isExtinct(grid, MAX_SIZE)) {
		std::cout << "Species gone extinct in " << gen << " generations" << std::endl;
	}

	system("pause");
	return 0;
}

bool isExtinct(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size) {

	// go through every cell in the grid and try to find at least one cell that's alive

	for (unsigned int x = 0; x < max_size; x++) {
		for (unsigned int y = 0; y < max_size; y++) {

			// check if the current cell is alive
			if (grid[x][y] == ALIVE) { 
				return false;
			}
		}
	}

	return true;
}

int newState(int neighbors, int currentState) {

	// find a new state for a given cell

	int state = DEAD;

	if (currentState == ALIVE) { // only cells that are currently alive
		if (neighbors == 2 || neighbors == 3) {
			state = ALIVE;
		}
	}
	else { // only cells that are currently dead
		if (neighbors == 3) {
			state = ALIVE;
		}
	}

	return state;
}

void displayGrid(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size) {
	
	// go through all the cells in the grid and display the cells

	std::string marker;
	std::string dead = " - ";
	std::string alive = " o ";

	system("cls"); // clear the screen
	for (int y = max_size - 1; y >= 0; y--) {
		for (unsigned int x = 0; x < max_size; x++) {

			// set marker
			if (grid[x][y] == DEAD) {
				marker = dead;
			}
			else {
				marker = alive;
			}

			// display marker
			std::cout << marker;
		}

		// end of row, go to a new line
		std::cout << std::endl;
	}
}

void userInput(int grid[MAX_SIZE][MAX_SIZE], int& max_gen) {
	int cellsToAdd;
	unsigned int x;
	unsigned int y;
	int cellsAdded = 0;

	std::cout << "Enter the maximum generation or -1 for unlimited generations: ";
	std::cin >> max_gen;

	std::cout << "Enter the number of cells to bring to live: ";
	std::cin >> cellsToAdd;

	// keep ask the user until we reach the amount of cells they requested
	while (cellsAdded < cellsToAdd) {
		std::cout << "Enter the x y for cell " << cellsAdded + 1 << ": ";
		std::cin >> x >> y;
		
		if (x < MAX_SIZE && y < MAX_SIZE) {
			std::cout << "(" << x << ", " << y << ")\n" << std::endl;

			// continue only if the coordinates given haven't already been assigned
			if (!isAlive(grid, x, y)) {
				setCell(grid, x, y);
				cellsAdded += 1;
			}

			// whether or not the user enters an non-assign coordinates, we will continue to print the grid
			displayGrid(grid, MAX_SIZE); 
		}
		else {

			// tell the user that they have gone outside the limits
			std::cout << "Error: check your coordinates, you only have a grid size of: "
				<< MAX_SIZE - 1 << "X" << MAX_SIZE - 1 << "\n" << std::endl;
		}
	}
}

bool isAlive(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y) {

	// check whether or not a coordinate is already set to alive; that way the user can't enter the same coordinates

	if (grid[x][y] == ALIVE) {
		return true;
	}
	else {
		return false;
	}
}

void setDefaults(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size) {

	// set every cell to DEAD state

	for (unsigned int y = 0; y < MAX_SIZE; y++) {
		for (unsigned int x = 0; x < MAX_SIZE; x++) {
			grid[x][y] = DEAD;
		}
	}
}

void modifyCells(int grid[MAX_SIZE][MAX_SIZE], unsigned int max_size) {

	// holds the coordinates of the neighbors of the current cell
	// (x, y) is the current cell and (_x, _y) is the neighbor cell
	int _x;
	int _y; 
	
	int neighbors; // keeps track of all the neiggbors around the current cell
	int currentState; // holds the current state of the current cell
	int newGrid[MAX_SIZE][MAX_SIZE];
	copyGrid(grid, newGrid, max_size);

	for (unsigned int x = 0; x < max_size; x++) {
		for (unsigned int y = 0; y < max_size; y++) {

			
			// find the neighbors 
			neighbors = 0;
			for (int a = -1; a < 2; a++) {
				for (int b = -1; b < 2; b++) {

					/*
					 x = 5
					 y = 3

					 _x = x + a
					 _y = y + b

					 current coordinates: (5, 3)
					 neighbors:
						((5 + -1), (3 + -1)) => (4, 2)
						((5 + -1), (3 +  0)) => (4, 0)
						((5 + -1), (3 +  1)) => (4, 4)

						((5 + 0), (3 + -1))  => (5, 4)
						((5 + 0), (3 +  0))  => (5, 3) // we ignore this case, because that is the current cell
						((5 + 0), (3 +  1))  => (5, 4)

						((5 + 1), (3 + -1))  => (6, 2)
						((5 + 1), (3 +  0))  => (6, 3)
						((5 + 1), (3 +  1))  => (6, 4)

					*/
									   					 
					// assign the coordinate of the neighbor
					_x = x + a;
					_y = y + b;					

					if (
						 !(_x == x && _y == y) // make sure the coordinates we got for neighor isn't the coordinates of the current cell
						           && 
						  (_x < MAX_SIZE && _y < MAX_SIZE) // make sure our coordinates aren't outside the scope
						           && 
						  (_x >= 0 && _y >= 0) // make sure are coordinates aren't negative
					) { // when every condition is met
						if (newGrid[_x][_y] == ALIVE) {
							neighbors += 1;
						}
					}
				}
			}
			
			currentState = grid[x][y];
			if (newState(neighbors, currentState)) { // call the the function newState and if it returns True then set this current cell to alive state
				if (currentState == DEAD) { // only do this when the current cell is dead, we don't want to waste time
					setCell(grid, x, y);
				}
			}
			else {
				if (currentState == ALIVE) { // only do this if is already not alive
					removeCell(grid, x, y);
				}
			}
		}
	}

}

void setCell(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y) {
	grid[x][y] = ALIVE;
}

void removeCell(int grid[MAX_SIZE][MAX_SIZE], unsigned int x, unsigned int y) {
	grid[x][y] = DEAD;
}

void copyGrid(int oldGrid[MAX_SIZE][MAX_SIZE], int newGrid[MAX_SIZE][MAX_SIZE], unsigned int max_size) {
	for (unsigned int x = 0; x < max_size; x++) {
		for (unsigned int y = 0; y < max_size; y++) {
			newGrid[x][y] = oldGrid[x][y];
		}
	}
}
