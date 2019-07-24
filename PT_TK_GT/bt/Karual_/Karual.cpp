#include<iostream>
#include<conio.h>
using namespace std;
#define MAXINT 1000 
// Canh
typedef struct Egde{
	int x,y;
};
int A[50][50];
int n;
void Input(void){
	 freopen("input1.txt", "r", stdin);
	 cin>>n;
	 cout<<"So dinh cua do thi: "<< n <<endl;
// khoi tao mang A
	for (int i = 1; i <= n; i++){
		for (int j = 1; j <= n; j++){
		    cin >> A[i][j];
		    cout << A[i][j] << " ";
		    if (A[i][j] == 0)
		    	A[i][j] = MAXINT;
		}
		cout << endl;
	}
}
void Kruskal(int A[50][50],int n)
{
	char *D= new char[n];// mang chua ten cay khung cua dinh
	Egde *L= new Egde[n-1]; // Khoi tao mang chua canh
	int min; // tim canh nho nhat
	int dem=0; // dem so canh
	int sum=0;// tong duong di
	int t=0;// t la so cay.
	int temp; 
	for(int i=0;i<n;i++){
		D[i]=0;
	}
	do
	{
		min=MAXINT;
		for(int i=1;i<=n;i++)// ca vong for chi ra dc 1 canh
		{
			for( int j=1; j<=n ;j++)
			{
				if(A[i][j] > 0 && min > A[i][j] && (D[i] == 0 || D[i] != D[j])) // Tim canh co trong so nho nhat va hai dinh ko tao thanh 1 chu trinh
				{
					min=A[i][j]; // canh trong so nho nhat
					L[dem].x=i; // chua dinh i
					L[dem].y=j; // chua dinh j				
				}
		    }
		}		
				// tao ra cay moi
				if(D[L[dem].x] == 0 && D[L[dem].y] == 0) //D[i]= k thì i thuoc cay khung thu k
				{
					t++;
					D[L[dem].x]=D[L[dem].y]=t;
				}
				// dua dinh tuong ung vao cay
				else if(D[L[dem].x] == 0 && D[L[dem].y] != 0)
				{
					
					D[L[dem].x] = D[L[dem].y];
				}
				// dua dinh tuong ung vao cay
				else if(D[L[dem].x] != 0 && D[L[dem].y] == 0)
				{
					
					D[L[dem].y] = D[L[dem].x];
				}
				// ghep hai dinh thanh 1 cay
				else if(D[L[dem].x] != D[L[dem].y] && D[L[dem].y]!=0)
				{
					temp=D[L[dem].x];
					for(int i=0;i<n;i++) // Tim tat ca cac dinh 
					{
						if(temp==D[i]) // Cung cay khung voi dinh L[dem].x va cho vao cay khung cua dinh L[dem].y
						{
							D[i]=D[L[dem].y];							
						}
					}
				}
			
		sum=sum+min;// tong trong so cua duong di
		dem++;// tang so canh cua  cay khung
	//	cout << dem << " " << L[dem].x << " " << L[dem].y << endl;
	} while(dem < n-1);// chua duyet het canh
	cout << endl;
	for(int i = dem-1; i >= 0; i--)
		cout << L[i].x << " " << L[i].y << " " << A[L[i].x][L[i].y] << endl;// dinh va canh tuong ung cua do thi
}
int main()
{
	Input();
	Kruskal(A,n);
	
}
