#include<iostream>
#include<conio.h>
#define max 1000
#include <iostream>
#include <fstream>
#include<string.h>
using namespace std;
string temp;
string s,t;
int c[max][max];
int b[max][max];// mang de truy vet
int n, m;
int dem=0;
int maxlen=0;
// input
void Input(void){
		
	fstream f; // khai bao bien doc va ghi file
	f.open("input1.IN"); // mo file
	getline (f,s); // doc tu file
	getline (f,t); 
	f.close();
	
}

void truyvet(int i, int j)
{
	if (i>0&&j>0)
	{
		if (b[i][j] == 1)
		{
			truyvet(i - 1, j - 1);
			printf("%c", s[i]);
		//	dem++;
		}
		else
			if (b[i][j] == 2)
				truyvet(i - 1, j);
			else truyvet(i, j - 1);
	}
}
int tim_max()
{
	for (int i = 0; i <= n; i++) { 
		for (int j = 0; j <= m; j++)
			if (c[i][j] > maxlen){ // Tim ra diem cuoi cung cua chuoi chung dai nhat			
				maxlen = c[i][j];
				
			}
	}
	return maxlen;
}
	
int main()
{
	Input();
	n = s.length();
	m = t.length();
	// khoi tao
	for (int i = 1; i <= m; i++)
	{
		c[i][0] = 0;
	}
	for (int j = 1; j <= n; j++)
	{
		c[0][j] = 0;
	}
	for (int i = 1; i <= n; i++)
		for (int j = 1; j <= m; j++)
			if (s[i] == t[j])
			{
				c[i][j] = c[i - 1][j - 1] + 1;
				b[i][j] = 1;
			//	dem++;
			}
			else
			{
				if (c[i - 1][j] >= c[i][j - 1])
				{
					c[i][j] = c[i - 1][j];
					b[i][j] = 2;
				}
				else
				{
					c[i][j] = c[i][j - 1];
					b[i][j] = 3;
				}
			}
	truyvet(n, m);
	dem=tim_max();
	cout<<"so phan tu chung: "<<dem;
	return 0;
}
