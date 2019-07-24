#include<iostream>
#include<conio.h>
#include<fstream>
#define TRUE 1 
#define FALSE  0 
#define MAX  10000 
using namespace std;
int h;
int a[100][100];//ma tran trong so cua do thi
int x;//so dinh
int y;//so canh
int socanh;//so canh cua cay khung nho nhat
int w;//tong do dai duong di
int chuaxet[100];
int canh[100][3];//ds canh cua cay khung nho nhat
void input(void) {
	int i, j, k;
	fstream input;
	input.open("file1.in");
	input >> x >> y;
	cout << "So dinh la: " << x << endl;
	cout << "So canh la: " << y << endl;
	cout<<"--- bat dau duyet-----"<<endl;
	// khoi tao ma tran trong so
	for (i = 1; i <= x; i++) {
		chuaxet[i] = TRUE;// danh dau cac dinh la chua duyet
		for (j = 1; j <= y; j++)
			a[i][j] = MAX;
	}	
	for (int p = 1; p <= y; p++) {
		input >> i >> j >> k;
		a[i][j] = k;
		a[j][i] = k;
	}
	
}
void duyet(void) {
	int k,l;// hai dinh duyet o moi buoc
	int top, min;// min la khoang cach nho nhat giua 2 dinh.
	int t;// bien tam
	int s[100];//mang chua cac dinh cua cay khung nho nhat
	top = 1;// bien dem khoi tao =1
	s[top] = h;//them dinh bat dau vao mang chua cac dinh duyet s[]
	chuaxet[h] = FALSE;
	while (socanh<x - 1) {
		min = MAX;
		cout<< "cac dinh da di qua: ";
		//tim canh min voi cac dinh trong s[]
		for (int i = 1; i <= top; i++) {
			t = s[i]; //gan bien tam t = dinh da duyet s[i]
			cout << t << " "; // in cac dinh da duyet
			for (int j = 1; j <= x; j++) { // tim dinh l gan dinh tam t nhat
				if (chuaxet[j] && min>a[t][j])
				 {
					min = a[t][j]; // canh nho nhat tiep theo cua cay khung
					k = t;// k va l la hai dinh cua canh nho nhat tiep theo
					l = j;
				}
			}
		}
		cout << endl;
		cout << "Cay khung nho nhat hien tai la:" << endl;
		int q, p; // dinh cua canh thu i
		for (int i = 1; i <= socanh; i++) {
			q = canh[i][1];
			p = canh[i][2];
			cout << q << " " << p << " " << a[q][p] << endl;
		}
		cout << endl << "----------------------------" << endl;

		socanh++;
		w = w + min;
		//thêm vào danh sách canh cua cây khung.
		canh[socanh][1] = k;
		canh[socanh][2] = l;
		canh[socanh][3] = a[k][l];
		chuaxet[l] = FALSE;
		top++;
		s[top] = l;// them dinh moi vao cay khung
	}
	// dinh duyet cuoi cung
	cout<< "cac dinh da di qua: ";
	for (int i = 1; i <= top; i++) {
		t = s[i];
		cout << t << " ";
	}
	cout << endl;
	cout << "Cay khung nho nhat hien tai" << endl;
	int q, p;
	for (int i = 1; i <= socanh; i++) {
		q = canh[i][1];
		p = canh[i][2];
		cout << q << " " << p << " " << a[q][p] << endl;
	}
	cout << endl << "-----------------------" << endl;
}
void Result(void) {
	cout << "Do dai ngan nhat la:" << w << endl;
	cout << "Cac canh cua cay khung nho nhat" << endl;
	for (int i = 1; i <= socanh; i++)
		cout << canh[i][1] << " " << canh[i][2] << "  voi trong so la: " << canh[i][3] << endl;
}
int main() {
	input();
	cout<<"Nhap dinh bat dau: ";
	cin>>h;
	duyet();
	Result();
	getch();
	return 1;
}
