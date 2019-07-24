#include<iostream>
#include<conio.h>
using namespace std;
#define MAX  100 
#define TRUE 1 
#define FALSE 0 
int G[MAX][MAX], n, chuaxet[MAX], QUEUE[MAX],truoc[MAX]; 
int s=1,t=4,j;
void Init(){ 
 freopen("BFS.IN","r",stdin);
 cin>>n;
 cout<<"So dinh cua do thi n = "<<n<<endl;
 //nhap ma tran lien ke.
 for(int i=1; i<=n;i++){ 
  for(int j=1; j<=n;j++){ 
   cin>>G[i][j]; 
  } 
 } 
 for(int i=1; i<=n;i++){
  chuaxet[i]=TRUE; 
 }
} 
int xuat()
{
	cout<<t<<"<--";
	j=t;
	while(truoc[j]!=s)
	{
		cout<<truoc[j]<<"<--";
		j=truoc[j];
	}
	cout<<s<<endl;
}

void BFS(int s,int t){ 
 int u,dauQ, cuoiQ;
 dauQ=1; cuoiQ=1;QUEUE[cuoiQ]=s;chuaxet[s]=FALSE; 

 while(dauQ<=cuoiQ){ 
  u=QUEUE[dauQ];
  dauQ=dauQ+1; 
  
  for(int j=1; j<=t;j++){ 
   if(G[u][j]==1 && chuaxet[j] ){ 
    cuoiQ=cuoiQ+1; 
    QUEUE[cuoiQ]=j; 
    chuaxet[j]=FALSE; 
    truoc[j]=u;
   } 
  } 
 } 
} 
int main(void){ 
 Init(); 
   BFS(s,t); 
   xuat();
 _getch(); 
}
