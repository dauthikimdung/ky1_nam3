#include<iostream>
#include<conio.h>
#define max 1000
#include <iostream>
#include <fstream>
#include<string.h>
using namespace std;
string temp;
string s,t;
int c[max][max],b[max][max];
int n, m;
int num = 0;
string result;
// input
void Input(void){
		
	fstream read_and_write_file; // khai bao bien doc va ghi file
	
	read_and_write_file.open("input.IN"); // mo file
	getline (read_and_write_file,s); // doc tu file
	getline (read_and_write_file,t); 
	read_and_write_file.close();
	
}
// Hien thi tung buoc
void printArr(int n,int m){
	num++;
	cout << "Buoc thu "<<num<<endl;
	for(int i = 0 ; i <= n; i++){
		for(int j = 0; j <= m; j++){
			if(c[i][j] != 0)cout <<c[i][j] << " ";
			else cout <<"- ";
		}
		cout << endl;
	}
	cout << endl;
}
// Truy vet de tim ra chuoi con chung dai nhat
void truyvet()
{	
	result = "";	
	int maxlen = 0;
	int maxi,maxj; // Toa do cua phan tu cuoi cung cua chuoi chung dai nhat
	// Duyet qua tat ca cac diem trong ma tran c[][]
	for (int i = 0; i <= n; i++) { 
		for (int j = 0; j <= m; j++)
			if (c[i][j] > maxlen){ // Tim ra diem cuoi cung cua chuoi chung dai nhat			
				maxlen = c[i][j];
				maxi = i;
				maxj = j;
			}
	}
	cout << "Do dai day con chung lon nhat la: " << maxlen << endl;
	for(int i = maxi, j = maxj ;c[i][j] != 0; i--,j--)
		result += s[i];
	cout << "Day con chung lon nhat la: ";
	for(int l = result.length()-1; l >= 0 ; l --)
		cout << result[l];
}
int main()
{
	// De cho de nhin, tat ca vi tri trong ma tran co gia tri = 0
	// se hien thi la dau - 
	Input(); // Nhap chuoi
	n = s.length(); // do dai chuoi s
	m = t.length(); // do dai chuoi t
	// Khoi tao 
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		c[i][j] = 0;
	}
	// Bat dau duyet
	for (int i = 1; i <= n; i++) {
		for (int j = 1; j <= m; j++) {
			if (s[i] == t[j]) // Neu 2 ky tu trung nhau
			{
				c[i][j] = c[i - 1][j - 1] + 1;
				printArr(n,m);
			}
		}
	}		
	printArr(n,m);
	//truyvet(n, m);
	truyvet();
	return 0;
}
