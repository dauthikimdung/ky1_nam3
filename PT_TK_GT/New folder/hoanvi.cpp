#include <iostream>
#include <stdio.h>
#include <conio.h>
#include <windows.h>
using namespace std;
int n,i,j;
int a[100],b[100],c[100];
void hoanvi()
{
	int k;
	for (k=1;k<=n;k++)
	if (b[k]==0)
	{
		j++;
		c[j]=a[k];
		b[k]=1;
			if (j==n)
			{
			cout<<"\n";
			for (i=1;i<=n;i++) { cout<<c[i]; } 
			}
		hoanvi();
		b[k]=0;
		j--;
	}
}
main()
{

cout<<"Nhap vao n : ";
cin>>n;
for (i=1;i<=n;i++)
 {
	 a[i]=i;
	 b[i]=0;
 }
  
j=0;
hoanvi();
}
