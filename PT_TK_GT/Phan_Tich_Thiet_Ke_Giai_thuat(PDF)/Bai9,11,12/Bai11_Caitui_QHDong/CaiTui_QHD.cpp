#include<iostream>
#include<stdio.h>
#include<conio.h>
 
void docfile(int a[],int &n,int &w)
{
    FILE *f;
    f=fopen("balo1.txt","rt");
    fscanf(f,"%d%d",&n,&w);
    for(int i=1;i<=n;i++){
    	fscanf(f,"%d",&a[i]);
    	printf("%2d",a[i]);
	}
       
        fclose(f);
}
 
void ghifile(int Chon[],int A[],int n)
{
    FILE *f;
    f=fopen("kqbalo1.txt","wt");
    for(int i=1;i<=n;i++)
        if(Chon[i]==1){
        	printf("%3d",A[i]);
        	fprintf(f,"%3d",A[i]);
		}
    
 
}
 
int Max(int a, int b)
{
    if(a>b)
        return a;
    return b;
}
 
int main()
{
    int Fx[101][101];//bang
    int A[101];//A mang trong luong
    int Chon[101];
    int n;
    int W;
     
    docfile(A,n,W);
     
    //Chua chon mon hang nao gan bang 0.
    for (int k=1;k<=W;k++)
    Fx[0][k]=0;
 
    // Tao bang
    for (int k=1;k<=n;k++)//k so mon hang, v khoi luong toi da
    {
        for (int v=1;v<=W;v++)
        {
             
            if (v>=A[k])
            {
                Fx[k][v]=Max(Fx[k-1][v-A[k]]+A[k],Fx[k-1][v]);
            }
            else
            {
                Fx[k][v]=Fx[k-1][v];
            }
        }
    }
 
    // Kiem tra bang tim ra cac mon hang duoc chon
    int v=W;
    int k=n;
 
    while( v>0)
    {
        for(int k=n;k>=0;k--)
        {
            if(Fx[k][v]>Fx[k-1][v])
            {
                Chon[k]=1;
                v=Fx[k][v]-A[k];
            }
        }
    }
     
    //In cac mon duoc chon
    ghifile(Chon,A,n);
}
