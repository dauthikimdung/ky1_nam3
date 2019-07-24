#include <conio.h>
#include <stdio.h>
#include<iostream>
using namespace std;
#define MAX  100 
#define TRUE 1 
#define FALSE 0 
/* tim tat caduong di tu s->t bang phuong phap quay lui.
 dung mang truoc[u]=s luu dinh s la dinh truoc u.
 neu ko tim dc duong di thi quay lui di duong khac
*/
int G[MAX][MAX], n, chuaxet[MAX],truoc[MAX]; 
int t,j,s;// s la diem bat dau, t la diem ket thuc
//G[i][j]=1 : ton tai duong di tu i->j
void Init(){ // do thi co huong
	freopen("input1.txt", "r", stdin); 
	cin>>n; 
	cout<<"So dinh cua ma tran n = "<<n<<endl;
	 //nhap ma tran lien ke.
		for(int i=1; i<=n;i++)
		{ 
			for(int j=1; j<=n;j++)
			{ 
			   cin>>G[i][j]; 
			} 
	 } 
} 
int xuat()
{
	// in 1 duong di tu s->t
	cout<<t<<"<--";
	j=t;
	while(truoc[j]!=s)
	{
		cout<<truoc[j]<<"<--";
		j=truoc[j];
	}
	cout<<s<<endl;
}
// tim truoc[] chua tat ca cac dih truoc dinh cuoi
// moi lan goi DFS(s,t) tim dc dinh u ke s là gan dinh truoc u=s
void DFS(int G[][MAX], int n, int s, int chuaxet[],int t){ 

	int u; 
	chuaxet[s]=FALSE; // dinh s da dc xet
	for(u=1; u<=n; u++){  // duyet tat ca cac dinh 
	if(G[s][u]==1 && chuaxet[u]) // neu u chua xet va u noi voi s
	  {
	  	truoc[u]=s; // truoc u la dinh s
	  	if(u==t) xuat(); // u la dinh cuoi thi in ket qua
	  	else 
	  		DFS(G,n,u,chuaxet,t); //truyen u la s di tu u->t
	  	chuaxet[u]=TRUE; //  khoi tao tao lai dinh u chua dc xet
	  }
	  
	  
	   
	 } 
} 
int main(void){ 
	cout<<"Dinh bat dau: ";cin>>s;
	cout<<"Dinh ket thuc: ";cin>>t;
	Init(); 
	for(int i=1; i<=n; i++) 
		chuaxet[i]=TRUE; // khoi tao cac dinh deu chua xet
	DFS( G,n, s, chuaxet,t);  // di tu s-> t
	getch(); 
}
