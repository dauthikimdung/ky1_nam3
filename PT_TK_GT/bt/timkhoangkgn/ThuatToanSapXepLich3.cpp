#include <iostream>
#include <fstream>
#include <conio.h>
#include <sstream>
using namespace std;
#define max 100
struct Activity {
	string id = "a";
	int start;
	int finish;
} Plan[100];
int n;
void setPlan();
void Init();
int main()
{
	Init();
	setPlan();
	return 0;
}
// Nhap tu file
void Init(){
	fstream in;
	in.open("in1.txt");
	in >> n; // Doc so hoat dong
	for(int i = 0; i < n; i++){
		stringstream ss;
		string str;
		ss << i+1;
		ss >> str;
		Plan[i].id += str; 
		in >> Plan[i].start >> Plan[i].finish; // Doc khoang thoi gian
	}
}
// Chon hoat dong
void setPlan()
{
	int i, j;
	Activity temp;
	//step 1
	//sort the Plan as per finishing time in ascending order
	for (i = 1; i < n; i++) {
		for (j = 0; j < n - 1; j++) {
			if (Plan[j].finish > Plan[j + 1].finish) {
				temp = Plan[j];
				Plan[j] = Plan[j + 1];
				Plan[j + 1] = temp;
			}
		}
	}

	//sorted
	cout << "Sorted Plan as per finish time (ascending order)\n";
	cout << "Activity" << "\tStart" << "\tFinish" << endl;
	for (i = 0; i < n; i++) {
		cout << "\t" << Plan[i].id << "\t" << Plan[i].start << "\t" << Plan[i].finish << endl;
	}

	//step 2
	//select the first activity
	cout << "-----Selected Plan-----\n";
	cout << "Activity" << "\tStart" << "\tFinish" << endl;
	cout <<  "\t" << Plan[0].id << "\t" << Plan[0].start << "\t" << Plan[0].finish << endl;

	//step 3
	//select next activity whose start time is greater than
	//or equal to the finish time of the previously selected activity
	i = 0;
	for (j = 1; j < n; j++) {
		if (Plan[j].start >= Plan[i].finish) {
			cout << "\t" << Plan[j].id << "\t" << Plan[j].start << "\t" << Plan[j].finish << endl;
			i = j;
		}
	}
}
