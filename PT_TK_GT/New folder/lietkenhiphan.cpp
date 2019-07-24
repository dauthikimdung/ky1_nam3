#include <conio.h>
#include <stdio.h>
#include<iostream>
using namespace std;
void nhiphan(int i);
int x[30],k,i;
 int n;
void printresult()
{
        for(int j=0; j<n; j++)
        cout<<x[j];
      cout<<"\n";
 
}
 
int main()
{
 
  
cout<<"\Nhap vao do dai cua day: ";
  cin>>n;
  nhiphan(0);
  getch();
}
 
void nhiphan(int i)
{
  int k;
    for ( k=0; k<=1; k++)
        {
            x[i] = k;
        if (i== n-1)
                printresult();
        else
            nhiphan(i+1);
 
        }
}
